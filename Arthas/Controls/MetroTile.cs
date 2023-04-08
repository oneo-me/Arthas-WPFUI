using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

#pragma warning disable 1591

namespace Arthas.Controls;

public class MetroTile : ContentControl
{
    static MetroTile()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(MetroTile), new FrameworkPropertyMetadata(typeof(MetroTile)));
    }

    public static readonly DependencyProperty TileBackgroundProperty =
        DependencyProperty.Register(nameof(TileBackground), typeof(VisualBrush), typeof(MetroTile));

    public VisualBrush TileBackground
    {
        get => (VisualBrush)GetValue(TileBackgroundProperty);
        private set => SetValue(TileBackgroundProperty, value);
    }

    public static readonly DependencyProperty TileProperty =
        DependencyProperty.Register(nameof(Tile), typeof(FrameworkElement), typeof(MetroTile),
            new FrameworkPropertyMetadata(null, OnTileChanged));

    public FrameworkElement? Tile
    {
        get => (FrameworkElement)GetValue(TileProperty);
        set => SetValue(TileProperty, value);
    }

    public static readonly DependencyProperty TileSizeProperty =
        DependencyProperty.Register(nameof(TileSize), typeof(Size), typeof(MetroTile),
            new FrameworkPropertyMetadata(new Size(100, 100), OnTileChanged));

    public Size TileSize
    {
        get => (Size)GetValue(TileSizeProperty);
        set => SetValue(TileSizeProperty, value);
    }

    static void OnTileChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        ((MetroTile)d).OnTileChanged();
    }

    void OnTileChanged()
    {
        if (Tile is null)
            return;

        Tile.Width = TileSize.Width;
        Tile.Height = TileSize.Height;

        TileBackground = new()
        {
            TileMode = TileMode.Tile,
            ViewportUnits = BrushMappingMode.Absolute,
            Visual = Tile,
            Viewport = new(TileSize)
        };
    }
}
