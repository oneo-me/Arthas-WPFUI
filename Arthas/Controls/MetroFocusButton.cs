using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Arthas.Controls;

public class MetroFocusButton : Button
{
    public static readonly DependencyProperty MouseMoveForegroundProperty = ElementBase.Property<MetroFocusButton, Brush>(nameof(MouseMoveForegroundProperty));
    public static readonly DependencyProperty MouseMoveBorderBrushProperty = ElementBase.Property<MetroFocusButton, Brush>(nameof(MouseMoveBorderBrushProperty));
    public new static readonly DependencyProperty BorderThicknessProperty = ElementBase.Property<MetroFocusButton, double>(nameof(BorderThicknessProperty));
    public static readonly DependencyProperty MouseMoveBorderThicknessProperty = ElementBase.Property<MetroFocusButton, double>(nameof(MouseMoveBorderThicknessProperty));
    public static readonly DependencyProperty StrokeDashArrayProperty = ElementBase.Property<MetroFocusButton, DoubleCollection>(nameof(StrokeDashArrayProperty));
    public static readonly DependencyProperty MouseMoveStrokeDashArrayProperty = ElementBase.Property<MetroFocusButton, DoubleCollection>(nameof(MouseMoveStrokeDashArrayProperty));
    public static readonly DependencyProperty CornerRadiusProperty = ElementBase.Property<MetroFocusButton, double>(nameof(CornerRadiusProperty));

    public Brush MouseMoveForeground
    {
        get => (Brush)GetValue(MouseMoveForegroundProperty);
        set => SetValue(MouseMoveForegroundProperty, value);
    }

    public Brush MouseMoveBorderBrush
    {
        get => (Brush)GetValue(MouseMoveBorderBrushProperty);
        set => SetValue(MouseMoveBorderBrushProperty, value);
    }

    public new double BorderThickness
    {
        get => (double)GetValue(BorderThicknessProperty);
        set => SetValue(BorderThicknessProperty, value);
    }

    public double MouseMoveBorderThickness
    {
        get => (double)GetValue(MouseMoveBorderThicknessProperty);
        set => SetValue(MouseMoveBorderThicknessProperty, value);
    }

    public DoubleCollection StrokeDashArray
    {
        get => (DoubleCollection)GetValue(StrokeDashArrayProperty);
        set => SetValue(StrokeDashArrayProperty, value);
    }

    public DoubleCollection MouseMoveStrokeDashArray
    {
        get => (DoubleCollection)GetValue(MouseMoveStrokeDashArrayProperty);
        set => SetValue(MouseMoveStrokeDashArrayProperty, value);
    }

    public double CornerRadius
    {
        get => (double)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }

    static MetroFocusButton()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(MetroFocusButton), new FrameworkPropertyMetadata(typeof(MetroFocusButton)));
    }
}
