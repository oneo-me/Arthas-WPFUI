using System.Windows.Forms;

namespace Arthas.Shell;

static class ScreenHelper
{
    public static Screen FormWindow(MetroWindowBase window)
    {
        return Screen.FromHandle(window.Handle);
    }
}
