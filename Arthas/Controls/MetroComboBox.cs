using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Arthas.Utility.Element;

namespace Arthas.Controls;

public class MetroComboBox : ComboBox
{
    public static readonly DependencyProperty TitleProperty = ElementBase.Property<MetroComboBox, string>(nameof(TitleProperty), "");
    public static readonly DependencyProperty IconProperty = ElementBase.Property<MetroComboBox, ImageSource>(nameof(IconProperty), null);

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public ImageSource Icon
    {
        get => (ImageSource)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    static MetroComboBox()
    {
        ElementBase.DefaultStyle<MetroComboBox>(DefaultStyleKeyProperty);
    }
}
