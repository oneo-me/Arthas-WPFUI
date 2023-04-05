using System.Windows;
using System.Windows.Controls;

namespace Arthas.Controls;

public class MetroCaptionMenuItem : MenuItem
{
    static MetroCaptionMenuItem()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(MetroCaptionMenuItem), new FrameworkPropertyMetadata(typeof(MetroCaptionMenuItem)));
    }

    protected override DependencyObject GetContainerForItemOverride()
    {
        return new MetroMenuItem();
    }
}
