using System.Windows;
using Arthas.Binder;

namespace Arthas.Demo.Views;

public class Main_Model : MetroWindowModel<Main>
{
    public override string Title => "Arthas.Demo";

    protected override void OnWindowInitialized(Window window)
    {
        base.OnWindowInitialized(window);

        window.Width = 1200;
        window.Height = 860;
    }
}
