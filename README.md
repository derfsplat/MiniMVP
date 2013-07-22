MiniMVP
=======

Lightweight WinForms MVP framework designed to provide separation guidance and testability but mostly get out of your way.

Example - Simple Dialog
-----------------------------------
__Create marker interface for your view:__
```csharp
	public interface ISampleDialogView : IDialog
	{
	}
```
- Inheriting form IDialog allows the presenter to handle the grunt work of instansiating, binding, showing, and cleaning up your form.  See [here](https://github.com/derfsplat/MiniMVP/blob/master/src/MiniMVP/Presenter.cs#L111) for more info.

__Create `SimpleDialogPresenter` inheriting from `DialogPresenter` and a marker interface:__
```csharp
	public class SampleDialogPresenter : DialogPresenter<ISampleDialogView>, IPresentSampleDialog
	{
		public SampleDialogPresenter(Func<ISampleDialogView> viewFactory)
			: base(viewFactory)
		{

		}
	}

	public interface IPresentSampleDialog : IPresentDialog
	{
	}
```
- Note the use of generics: `DialogPresenter<ISimpleDialogView>`.  By doing this we get `ISimpleDialogView` included for free in the `View` base class variable.
- The presenter constructors require view "factories" so that we do not need to incur a penalty for view instansiation until it's actually needed- that is, until it's ddisplayed to the user.

__Create `SimpleDialog` as a new form in your project:__
```csharp
	public partial class SampleDialog : Dialog<IPresentSampleDialog>, ISampleDialogView
	{
		public SampleDialog()
		{
			InitializeComponent();
		}
	}
```
- Inheriting from `Dialog<IPresentSampleDialog>` gets us our presenter for free as the base class variable `Presenter` inside the view.  This allows us to do more complex view->presenter interaction, for example:
```csharp
		private void tsShowDialog_Click(object sender, EventArgs e)
		{
			Presenter.ShowDialogSample();
		}
```
Seen [here](https://github.com/derfsplat/MiniMVP/blob/master/src/MiniMVP.Samples/MainForm.cs#L22).

That's it.  You're ready to go.
