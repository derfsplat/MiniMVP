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
	public partial class SampleDialog : Dialog<IPresentSampleDialog>, ISampleDialogView
	{
		public SampleDialog()
		{
			InitializeComponent();
		}

		#region ISampleDialogView Members

		public string TitleText
		{
			get { return textBox1.Text; }
		}

		#endregion
	}

	public interface ISampleDialogView : IDialog
	{
		string TitleText { get; }
	}
}
