using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using MiniMVP.Contrib;

namespace MiniMVP
{
    public abstract class DialogPresenter<TView> : IPresentDialog, INotifyPropertyChanged
        where TView: IDialog
    {
        protected Func<TView> viewFactory;

        public DialogPresenter(Func<TView> view)
        {
            this.viewFactory = view;
        }

        /// <summary>
        /// When dialog is visible, this property will contain the visible instance of the view
        /// </summary>
        public TView View
        {
            get;
            private set;
        }

        protected virtual void OnBeforeShow(CancelEventArgs args, TView view)
        {

        }

        protected virtual void OnAfterShow(TView view)
        {

        }

        public DialogResult Show()
        {
            using (var view = viewFactory())
            {
                View = view;

                CancelEventArgs cargs = new CancelEventArgs(false);
                OnBeforeShow(cargs, view);
                if (cargs.Cancel) return DialogResult.Cancel;

                if (!view.IsBound)
                {
                  var bindMethod = view.GetType().GetMethod("Bind", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                  if (bindMethod.IsGenericMethod)
                    bindMethod = bindMethod.MakeGenericMethod(typeof(IPresent));

                  bindMethod.Invoke(view, new object[] { this });
                }

                var dr = view.ShowDialog(view.Owner);

                OnAfterShow(view);

                View = default(TView);

                return dr;
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null) PropertyChanged(this, e);
        }

        public void NotifyPropertyChanged(string propertyName)
        {
            NotifyPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        ///   Notifies subscribers of the property change.
        /// </summary>
        /// <typeparam name = "TProperty">The type of the property.</typeparam>
        /// <param name = "property">The property expression.</param>
        public void NotifyPropertyChanged<TProperty>(Expression<Func<TProperty>> property)
        {
            NotifyPropertyChanged(property.GetMemberInfo().Name);
        }
        #endregion
    }
}

