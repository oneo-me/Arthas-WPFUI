using System.Windows;
using System.Windows.Controls;

namespace Arthas.Controls;

public class MetroCaptionMenu : Menu
{
    static MetroCaptionMenu()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(MetroCaptionMenu), new FrameworkPropertyMetadata(typeof(MetroCaptionMenu)));
    }

    protected override DependencyObject GetContainerForItemOverride()
    {
        return new MetroCaptionMenuItem();
    }
}
