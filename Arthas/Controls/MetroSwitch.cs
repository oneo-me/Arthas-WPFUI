using System.Windows;
using System.Windows.Controls.Primitives;
using Arthas.Utility.Element;

namespace Arthas.Controls;

public class MetroSwitch : ToggleButton
{
    public static readonly DependencyProperty TextHorizontalAlignmentProperty = ElementBase.Property<MetroSwitch, HorizontalAlignment>(nameof(TextHorizontalAlignmentProperty), HorizontalAlignment.Left);
    public static readonly DependencyProperty CornerRadiusProperty = ElementBase.Property<MetroSwitch, CornerRadius>(nameof(CornerRadiusProperty), new(10));
    public static readonly DependencyProperty BorderCornerRadiusProperty = ElementBase.Property<MetroSwitch, CornerRadius>(nameof(BorderCornerRadiusProperty), new(12));

    public HorizontalAlignment TextHorizontalAlignment
    {
        get => (HorizontalAlignment)GetValue(TextHorizontalAlignmentProperty);
        set => SetValue(TextHorizontalAlignmentProperty, value);
    }

    public CornerRadius CornerRadius
    {
        get => (CornerRadius)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }

    public CornerRadius BorderCornerRadius
    {
        get => (CornerRadius)GetValue(BorderCornerRadiusProperty);
        set => SetValue(BorderCornerRadiusProperty, value);
    }

    public MetroSwitch()
    {
        Loaded += delegate
        {
            ElementBase.GoToState(this, (bool)IsChecked ? "OpenLoaded" : "CloseLoaded");
        };
    }

    protected override void OnChecked(RoutedEventArgs e)
    {
        base.OnChecked(e);
        ElementBase.GoToState(this, "Open");
    }

    protected override void OnUnchecked(RoutedEventArgs e)
    {
        base.OnChecked(e);
        ElementBase.GoToState(this, "Close");
    }

    static MetroSwitch()
    {
        ElementBase.DefaultStyle<MetroSwitch>(DefaultStyleKeyProperty);
    }
}
