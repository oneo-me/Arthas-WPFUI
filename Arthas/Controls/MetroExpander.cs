using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Arthas.Controls;

public class MetroExpander : ContentControl
{
    public static readonly DependencyProperty IsExpandedProperty = ElementBase.Property<MetroExpander, bool>(nameof(IsExpandedProperty));
    public static readonly DependencyProperty CanHideProperty = ElementBase.Property<MetroExpander, bool>(nameof(CanHideProperty));
    public static readonly DependencyProperty HeaderProperty = ElementBase.Property<MetroExpander, string>(nameof(HeaderProperty));
    public static readonly DependencyProperty HintProperty = ElementBase.Property<MetroExpander, string>(nameof(HintProperty));
    public static readonly DependencyProperty HintBackgroundProperty = ElementBase.Property<MetroExpander, Brush>(nameof(HintBackgroundProperty));
    public static readonly DependencyProperty HintForegroundProperty = ElementBase.Property<MetroExpander, Brush>(nameof(HintForegroundProperty));
    public static readonly DependencyProperty IconProperty = ElementBase.Property<MetroExpander, ImageSource>(nameof(IconProperty), null);

    public bool IsExpanded
    {
        get => (bool)GetValue(IsExpandedProperty);
        set
        {
            SetValue(IsExpandedProperty, value);
            VisualStateManager.GoToState(this, IsExpanded ? "Expand" : "Normal", false);
        }
    }

    public bool CanHide
    {
        get => (bool)GetValue(CanHideProperty);
        set => SetValue(CanHideProperty, value);
    }

    public string Header
    {
        get => (string)GetValue(HeaderProperty);
        set => SetValue(HeaderProperty, value);
    }

    public string Hint
    {
        get => (string)GetValue(HintProperty);
        set => SetValue(HintProperty, value);
    }

    public Brush HintBackground
    {
        get => (Brush)GetValue(HintBackgroundProperty);
        set => SetValue(HintBackgroundProperty, value);
    }

    public Brush HintForeground
    {
        get => (Brush)GetValue(HintForegroundProperty);
        set => SetValue(HintForegroundProperty, value);
    }

    public ImageSource Icon
    {
        get => (ImageSource)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    public MetroExpander()
    {
        Loaded += delegate
        {
            if (Content == null)
                IsExpanded = false;
            else if (!CanHide)
                IsExpanded = true;

            VisualStateManager.GoToState(this, IsExpanded ? "StartExpand" : "StartNormal", false);
        };
    }

    static MetroExpander()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(MetroExpander), new FrameworkPropertyMetadata(typeof(MetroExpander)));
    }
}
