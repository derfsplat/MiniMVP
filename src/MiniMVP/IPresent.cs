using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MiniMVP
{
    /// <summary>
    /// Base interface for all presenters
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPresent
    {
        
    }

    public interface IPresentMdiChild : IPresent
    {
        void Show();
    }

    public interface IPresentDialog : IPresent
    {
        DialogResult Show();
    }
}
