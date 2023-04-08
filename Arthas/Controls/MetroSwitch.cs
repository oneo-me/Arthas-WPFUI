using System.Windows;
using System.Windows.Controls.Primitives;

namespace Arthas.Controls;

public class MetroSwitch : ToggleButton
{
    public static readonly DependencyProperty TextHorizontalAlignmentProperty = DependencyProperty.Register(nameof(TextHorizontalAlignment), typeof(HorizontalAlignment), typeof(MetroSwitch), new(HorizontalAlignment.Left));

    public HorizontalAlignment TextHorizontalAlignment
    {
        get => (HorizontalAlignment)GetValue(TextHorizontalAlignmentProperty);
        set => SetValue(TextHorizontalAlignmentProperty, value);
    }

    public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(MetroSwitch), new(new CornerRadius(10)));

    public CornerRadius CornerRadius
    {
        get => (CornerRadius)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }

    public static readonly DependencyProperty BorderCornerRadiusProperty = DependencyProperty.Register(nameof(BorderCornerRadius), typeof(CornerRadius), typeof(MetroSwitch), new(new CornerRadius(12)));

    public CornerRadius BorderCornerRadius
    {
        get => (CornerRadius)GetValue(BorderCornerRadiusProperty);
        set => SetValue(BorderCornerRadiusProperty, value);
    }

    public MetroSwitch()
    {
        Loaded += delegate
        {
            VisualStateManager.GoToState(this, IsChecked is true ? "OpenLoaded" : "CloseLoaded", false);
        };
    }

    protected override void OnChecked(RoutedEventArgs e)
    {
        base.OnChecked(e);
        VisualStateManager.GoToState(this, "Open", false);
    }

    protected override void OnUnchecked(RoutedEventArgs e)
    {
        base.OnChecked(e);
        VisualStateManager.GoToState(this, "Close", false);
    }

    static MetroSwitch()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(MetroSwitch), new FrameworkPropertyMetadata(typeof(MetroSwitch)));
    }
}
