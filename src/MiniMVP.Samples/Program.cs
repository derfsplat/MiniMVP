using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniMVP.Samples
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

      MainForm mainForm = new MainForm();
      IoC.Register<Func<MainForm>>(() => mainForm);
			IoC.Register<Func<ISampleDialogView>>(() => new SampleDialog());
      //TODO: create main form helper/view as 1st class citizen in mvp framework to remove need for mainForm ref here
      IoC.Register<IMainForm>(mainForm);
      IoC.Register<IPresentSampleDialog>(
        new SampleDialogPresenter(IoC.Get<Func<ISampleDialogView>>(), IoC.Get<IMainForm>()));

      IoC.Register<IPresentMainForm>(new MainFormPresenter(IoC.Get<Func<MainForm>>(), IoC.Get<IPresentSampleDialog>()));

			var mfPresenter = IoC.Get<IPresentMainForm>();
			mfPresenter.Show();

      
      Application.Run(mfPresenter.MainForm);
		}

		static class IoC
		{
			static Dictionary<Type, object> container = new Dictionary<Type, object>();

			public static void Register<T>(T instance)
			{
				if(instance == null) throw new ArgumentNullException("instance");

				container.Add(typeof(T), instance);
			}

			public static T Get<T>()
			{
				if(container.ContainsKey(typeof(T)))
					return (T)container[typeof(T)];
				else
					throw new KeyNotFoundException(typeof(T).ToString());
			}
		}
	}
}
