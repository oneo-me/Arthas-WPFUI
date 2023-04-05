using System.Windows;
using System.Windows.Controls;
using Arthas.Utility.Element;

namespace Arthas.Controls;

public enum ProgressBarState
{
    None,
    Error,
    Wait
}

public class MetroProgressBar : ProgressBar
{
    public static readonly DependencyProperty ProgressBarStateProperty = ElementBase.Property<MetroProgressBar, ProgressBarState>(nameof(ProgressBarStateProperty));
    public static readonly DependencyProperty CornerRadiusProperty = ElementBase.Property<MetroProgressBar, CornerRadius>(nameof(CornerRadiusProperty));
    public static readonly DependencyProperty TitleProperty = ElementBase.Property<MetroProgressBar, string>(nameof(TitleProperty));
    public static readonly DependencyProperty HintProperty = ElementBase.Property<MetroProgressBar, string>(nameof(HintProperty));
    public static readonly DependencyProperty ProgressBarHeightProperty = ElementBase.Property<MetroProgressBar, double>(nameof(ProgressBarHeightProperty));
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

    public string Hint
    {
        get => (string)GetValue(HintProperty);
        set => SetValue(HintProperty, value);
    }

    public double ProgressBarHeight
    {
        get => (double)GetValue(ProgressBarHeightProperty);
        set => SetValue(ProgressBarHeightProperty, value);
    }

    public HorizontalAlignment TextHorizontalAlignment
    {
        get => (HorizontalAlignment)GetValue(TextHorizontalAlignmentProperty);
        set => SetValue(TextHorizontalAlignmentProperty, value);
    }

    public MetroProgressBar()
    {
        ValueChanged += delegate
        {
            if (Hint == null || Hint.EndsWith(" %"))
                Hint = (int)(Value / Maximum * 100) + " %";
        };
    }

    static MetroProgressBar()
    {
        ElementBase.DefaultStyle<MetroProgressBar>(DefaultStyleKeyProperty);
    }
}
