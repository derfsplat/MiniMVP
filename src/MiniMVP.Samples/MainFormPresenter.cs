using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniMVP.Samples
{
	public class MainFormPresenter : Presenter<IViewMainForm>, IPresentMainForm
	{
		IPresentSampleDialog dialogPresenter;
		
		public MainFormPresenter(Func<IViewMainForm> mainFormFactory, IPresentSampleDialog dialogPresenter)
			: base(mainFormFactory)
		{
			this.dialogPresenter = dialogPresenter;
		}

		#region IPresentMainForm Members

		public void ShowDialogSample()
		{
			if(dialogPresenter.ShowDialog(View, new SimpleDataModel() { Title = View.Title }) == DialogResult.OK)
				View.Title = dialogPresenter.TitleModel.Title;
		}

		#endregion
	}

	public interface IPresentMainForm : IPresent
	{
		void ShowDialogSample();
	}
}
