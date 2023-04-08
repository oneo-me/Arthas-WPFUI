using System.Windows;
using System.Windows.Controls;

namespace Arthas.Controls;

public class MetroProgressBar : ProgressBar
{
    static MetroProgressBar()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(MetroProgressBar), new FrameworkPropertyMetadata(typeof(MetroProgressBar)));
    }

    public static readonly DependencyProperty ProgressBarStateProperty = ElementBase.Property<MetroProgressBar, ProgressBarState>(nameof(ProgressBarStateProperty));
    public static readonly DependencyProperty CornerRadiusProperty = ElementBase.Property<MetroProgressBar, CornerRadius>(nameof(CornerRadiusProperty));
    public static readonly DependencyProperty TitleProperty = ElementBase.Property<MetroProgressBar, string>(nameof(TitleProperty));
    public static readonly DependencyProperty TextHorizontalAlignmentProperty = ElementBase.Property<MetroProgressBar, HorizontalAlignment>(nameof(TextHorizontalAlignmentProperty));

    public ProgressBarState ProgressBarState
    {
        get => (ProgressBarState)GetValue(ProgressBarStateProperty);
        set => SetValue(ProgressBarStateProperty, value);
    }

    public CornerRadius CornerRadius
    {
        get => (CornerRadius)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public HorizontalAlignment TextHorizontalAlignment
    {
        get => (HorizontalAlignment)GetValue(TextHorizontalAlignmentProperty);
        set => SetValue(TextHorizontalAlignmentProperty, value);
    }
}
