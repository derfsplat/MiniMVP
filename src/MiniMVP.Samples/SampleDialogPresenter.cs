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
	  private readonly IMainForm owner;
	  SimpleDataModel model;

		public SampleDialogPresenter(Func<ISampleDialogView> viewFactory, IMainForm owner)
			: base(viewFactory)
		{
		  this.owner = owner;
		}

	  #region IPresentSampleDialog Members

		public DialogResult ShowDialog(SimpleDataModel model)
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
		DialogResult ShowDialog(SimpleDataModel model);
		SimpleDataModel TitleModel { get; }
	}
}
