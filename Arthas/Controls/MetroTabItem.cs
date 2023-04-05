using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Arthas.Utility.Element;

namespace Arthas.Controls;

public class MetroTabItem : TabItem
{
    public static readonly DependencyProperty IconProperty = ElementBase.Property<MetroTabItem, ImageSource>(nameof(IconProperty), null);

    public ImageSource Icon
    {
        get => (ImageSource)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    static MetroTabItem()
    {
        ElementBase.DefaultStyle<MetroTabItem>(DefaultStyleKeyProperty);
    }
}
