using System.Windows;
using Arthas.Demo.Views;

namespace Arthas.Demo;

public partial class App
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var mainModel = new Main_Model();
        var window = mainModel.CreateWindow();
        MainWindow = window;
        MainWindow.Show();
    }
}
