using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MiniMVP
{
    public abstract class View : Form, IView
    {
        public View()
        {
            CanClose = () => true;
            IsBound = false;
        }

        public Func<bool> CanClose
        {
            get;
            set;
        }

        private IPresent presenter;
        protected virtual IPresent Presenter
        {
            get
            {
                return presenter;
            }
            set
            {
                this.presenter = value;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = !CanClose();

            base.OnFormClosing(e);
        }

        public bool IsBound
        {
            get;
            protected set;
        }

        public virtual void Bind<T>(T presenter) where T : IPresent
        {
            this.Presenter = presenter;
            IsBound = true;
        }

		public new IWin32Window Owner
		{
			get { return base.Owner; }
		}
	}

    public abstract class View<T> : View, IView
        where T: IPresent
    {
        public virtual void Bind(T presenter)
        {
            this.Presenter = presenter;
            IsBound = true;
        }
        
        protected new T Presenter
        {
            get
            {
                return (T)base.Presenter;
            }
            private set
            {
                base.Presenter = value;
            }
        }
    }
}
