using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniMVP.Samples
{
	public partial class MainForm : View<IPresentMainForm>, IViewMainForm
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void tsShowDialog_Click(object sender, EventArgs e)
		{
			Presenter.ShowDialogSample();
		}

		public override void Bind(IPresentMainForm presenter)
		{
			base.Bind(presenter);
		}

		#region IViewMainForm Members

		public string Title
		{
			get
			{
				return this.Text;
			}
			set
			{
				this.Text = value;
			}
		}

		#endregion
	}

	public interface IViewMainForm : IView
	{
		string Title { get; set; }
	}
}
