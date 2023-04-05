using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Arthas.Shell;

namespace Arthas.Controls;

public class MetroWindow : MetroWindowBase
{
    static MetroWindow()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(MetroWindow), new FrameworkPropertyMetadata(typeof(MetroWindow)));
    }

    public static readonly DependencyProperty CaptionBackgroundProperty = DependencyProperty.Register(nameof(CaptionBackground), typeof(Brush), typeof(MetroWindow));

    public Brush? CaptionBackground
    {
        get => (Brush?)GetValue(CaptionBackgroundProperty);
        set => SetValue(CaptionBackgroundProperty, value);
    }

    public static readonly DependencyProperty CaptionForegroundProperty = DependencyProperty.Register(nameof(CaptionForeground), typeof(Brush), typeof(MetroWindow));

    public Brush? CaptionForeground
    {
        get => (Brush?)GetValue(CaptionForegroundProperty);
        set => SetValue(CaptionForegroundProperty, value);
    }

    public static readonly DependencyProperty CaptionContentProperty = DependencyProperty.Register(nameof(CaptionContent), typeof(object), typeof(MetroWindow));

    public object? CaptionContent
    {
        get => GetValue(CaptionContentProperty);
        set => SetValue(CaptionContentProperty, value);
    }

    Grid? PART_Caption;

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();

        PART_Caption = GetTemplateChild(nameof(PART_Caption)) as Grid;

        if (PART_Caption is null)
            return;

        PART_Caption.MouseLeftButtonDown += ElementOnMouseLeftButtonDown;
    }

    void ElementOnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (Handle == IntPtr.Zero)
            return;

        if (e.ClickCount == 2)
            ChangWindowState();

        else
            SendCaptionMessage();
    }
}
