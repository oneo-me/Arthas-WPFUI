using System.Windows;
using System.Windows.Controls;

namespace Arthas.Controls;

public class MetroGridTile : ContentControl
{
    static MetroGridTile()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(MetroGridTile),
            new FrameworkPropertyMetadata(typeof(MetroGridTile)));
    }

    public static readonly DependencyProperty TileSizeProperty =
        DependencyProperty.Register(nameof(TileSize), typeof(Size), typeof(MetroGridTile));

    public Size TileSize
    {
        get => (Size)GetValue(TileSizeProperty);
        set => SetValue(TileSizeProperty, value);
    }

    public static readonly DependencyProperty TileOpacityProperty =
        DependencyProperty.Register(nameof(TileOpacity), typeof(double), typeof(MetroGridTile));

    public double TileOpacity
    {
        get => (double)GetValue(TileOpacityProperty);
        set => SetValue(TileOpacityProperty, value);
    }
}
