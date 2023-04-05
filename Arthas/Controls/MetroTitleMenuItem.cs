using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Arthas.Utility.Element;

namespace Arthas.Controls;

public class MetroTitleMenuItem : MenuItem
{
    public new static readonly DependencyProperty IconProperty = ElementBase.Property<MetroTitleMenuItem, ImageSource>(nameof(IconProperty), null);

    public new ImageSource Icon
    {
        get => (ImageSource)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    static MetroTitleMenuItem()
    {
        ElementBase.DefaultStyle<MetroTitleMenuItem>(DefaultStyleKeyProperty);
    }
}
