using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MiniMVP
{
    public interface IViewBase : IDisposable, IWin32Window
    {
        Func<bool> CanClose { get; set; }

        /// <summary>
        /// True if <see cref="Bind(T Presenter)"/> has been called and the view is now bound to its presenter
        /// </summary>
        bool IsBound { get; }

        void Show();

        void Show(IWin32Window owner);
    }

    public interface IView : IViewBase
    {
		IWin32Window Owner { get; }

		event FormClosedEventHandler FormClosed;

        void Bind<T>(T presenter) where T : IPresent;
    }
}
