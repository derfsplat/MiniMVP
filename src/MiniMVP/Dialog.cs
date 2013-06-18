using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MiniMVP
{
    public class Dialog : View
    {
    }

    public class Dialog<T> : View<T>
        where T: IPresent
    {
        public new void Show()
        {
            base.ShowDialog();
        }

        public new void Show(IWin32Window owner)
        {
            base.ShowDialog(owner);
        }
    }
}
