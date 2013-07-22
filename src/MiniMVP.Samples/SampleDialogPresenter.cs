using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniMVP.Samples
{
	public class SampleDialogPresenter : DialogPresenter<ISampleDialogView>, IPresentSampleDialog
	{
		SimpleDataModel model;

		public SampleDialogPresenter(Func<ISampleDialogView> viewFactory)
			: base(viewFactory)
		{

		}

		#region IPresentSampleDialog Members

		//todo: have mainform implement IHostWinForms iface so we can get owner via IHOstWinForms dep passed to ctor
		public DialogResult ShowDialog(IWin32Window owner, SimpleDataModel model)
		{
			this.model = model;

			using(var view = viewFactory())
			{
				view.CanClose = () =>
					{
						if(string.IsNullOrWhiteSpace(view.TitleText))
						{
							MessageBox.Show("no no mr. smith no here.");
							return false;
						}

						model.Title = view.TitleText;
						return true;
					};

				return view.ShowDialog(owner);
			}
		}

		public SimpleDataModel TitleModel
		{
			get
			{
				return model;
			}
		}

		#endregion
	}

	public interface IPresentSampleDialog : IPresentDialog
	{
		DialogResult ShowDialog(IWin32Window owner, SimpleDataModel model);
		SimpleDataModel TitleModel { get; }
	}
}
