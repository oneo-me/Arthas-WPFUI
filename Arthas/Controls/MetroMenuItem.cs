using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Arthas.Utility.Element;

namespace Arthas.Controls;

public class MetroMenuItem : MenuItem
{
    public new static readonly DependencyProperty IconProperty = ElementBase.Property<MetroMenuItem, ImageSource>(nameof(IconProperty), null);

    public new ImageSource Icon
    {
        get => (ImageSource)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    static MetroMenuItem()
    {
        ElementBase.DefaultStyle<MetroMenuItem>(DefaultStyleKeyProperty);
    }
}
