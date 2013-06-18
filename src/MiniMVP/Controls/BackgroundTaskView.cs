using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MiniMVP.Controls
{
    public partial class BackgroundTaskView : Form, IBackgroundTaskView
    {
        public BackgroundTaskView()
        {
            InitializeComponent();
        }

        public string WaitDescription
        {
            get { return backgroundTaskUserControl.WaitDescription; }
            set { backgroundTaskUserControl.WaitDescription = value; }
        }
    }
}
