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
	public abstract class Presenter<TView> : IPresent, INotifyPropertyChanged
		where TView : IView
	{
		protected Func<TView> viewFactory;

		public Presenter(Func<TView> viewFactory)
		{
			this.viewFactory = viewFactory;
		}

		/// <summary>
		/// When dialog is visible, this property will contain the visible instance of the view
		/// </summary>
		public TView View
		{
			get;
			protected set;
		}

		protected virtual void OnBeforeShow(CancelEventArgs args, TView view)
		{

		}

		protected virtual void OnAfterShow(TView view)
		{

		}

		public void Show()
		{
			View = viewFactory();
			ShowInternal(() => View.Show(View.Owner));
		}

		protected void ShowInternal(Action showForm)
		{
			CancelEventArgs cargs = new CancelEventArgs(false);
			OnBeforeShow(cargs, View);
			if(cargs.Cancel) return;

			if(!View.IsBound)
			{
				var bindMethod = View.GetType().GetMethod("Bind", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
				if(bindMethod == null) throw new InvalidOperationException("TView must override Bind.");

				if(bindMethod.IsGenericMethod)
					bindMethod = bindMethod.MakeGenericMethod(typeof(IPresent));

				bindMethod.Invoke(View, new object[] { this });
			}

			View.FormClosed += (s, e) =>
			{
				OnAfterShow(View);
				View = default(TView);
			};

			showForm();
		}

		#region INotifyPropertyChanged Members

		public event PropertyChangedEventHandler PropertyChanged;

		public void NotifyPropertyChanged(PropertyChangedEventArgs e)
		{
			if(PropertyChanged != null) PropertyChanged(this, e);
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

    public abstract class DialogPresenter<TView> : Presenter<TView>, IPresentDialog, INotifyPropertyChanged
        where TView: IDialog
    {

		public DialogPresenter(Func<TView> viewFactory)
			: base(viewFactory)
		{
		}

		#region IPresentDialog Members

		public new DialogResult Show()
		{
			using(var view = viewFactory())
			{
				View = view;

				DialogResult dr = DialogResult.None;
				ShowInternal(() => dr = View.ShowDialog(View.Owner));
				
				View = default(TView);

				return dr;
			}
		}

		#endregion
	}
}

