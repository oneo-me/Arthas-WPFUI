using System.Windows;
using System.Windows.Controls;
using Arthas.Utility.Element;

namespace Arthas.Controls;

public class MetroCanvasGrid : ContentControl
{
    public static readonly DependencyProperty ViewportProperty = ElementBase.Property<MetroCanvasGrid, Rect>(nameof(ViewportProperty));

    public Rect Viewport
    {
        get => (Rect)GetValue(ViewportProperty);
        set => SetValue(ViewportProperty, value);
    }

    public static readonly DependencyProperty GridOpacityProperty = ElementBase.Property<MetroCanvasGrid, double>(nameof(GridOpacityProperty));
    public static readonly DependencyProperty GridSizeProperty = ElementBase.Property<MetroCanvasGrid, double>(nameof(GridSizeProperty));
    public static readonly DependencyProperty CornerRadiusProperty = ElementBase.Property<MetroCanvasGrid, CornerRadius>(nameof(CornerRadiusProperty));

    public double GridOpacity
    {
        get => (double)GetValue(GridOpacityProperty);
        set => SetValue(GridOpacityProperty, value);
    }

    public CornerRadius CornerRadius
    {
        get => (CornerRadius)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }

    public bool IsApplyTheme { get; set; } = true;

    static MetroCanvasGrid()
    {
        ElementBase.DefaultStyle<MetroCanvasGrid>(DefaultStyleKeyProperty);
    }
}
