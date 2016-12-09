using System.Windows.Forms;

namespace MiniMVP
{
  /// <summary>
  /// Interface to represent main host window. Useful for setting owner on dialogs/message boxes
  /// </summary>
  public interface IMainForm : IWin32Window
  {
  }
}
