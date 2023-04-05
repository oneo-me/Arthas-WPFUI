using System.Windows;

namespace Arthas.Shell;

public static class Extensions
{
    public static void BringToFront(this Window? window)
    {
        if (window is null)
            return;

        try
        {
            if (!window.IsVisible)
                return;

            window.Activate();
            window.Focus();
        }
        catch
        {
            // ignored
        }
    }
}
