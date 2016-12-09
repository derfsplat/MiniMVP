using System.Windows.Forms;

namespace MiniMVP
{
  public interface IHostWinForms : IMainForm
  {
    Form MdiHost { get; }
  }
}
