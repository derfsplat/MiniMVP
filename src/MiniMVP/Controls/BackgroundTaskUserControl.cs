using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MiniMVP.Controls
{
    public partial class BackgroundTaskUserControl : UserControl
    {
        public BackgroundTaskUserControl()
        {
            InitializeComponent();
        }

        public string WaitDescription
        {
            get { return lblWaitDescription.Text; }
            set { lblWaitDescription.Text = value; }
        }
    }
}
