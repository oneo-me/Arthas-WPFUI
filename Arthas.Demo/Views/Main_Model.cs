using System.Windows;
using Arthas.Binder;
using Arthas.Controls;

namespace Arthas.Demo.Views;

public class Main_Model : MetroWindowModel<Main>
{
    public override string Title => "Arthas.Demo";

    protected override void OnWindowInitialized(Window window)
    {
        base.OnWindowInitialized(window);

        window.Width = 1200;
        window.Height = 860;

        if (window is MetroWindow metroWindow)
            metroWindow.CaptionContent = new Caption_Model().CreateView();
    }
}
