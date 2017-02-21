using Arthas.Utility.Element;
using System.Windows;
using System.Windows.Controls;

namespace Arthas.Controls.Metro
{
    public class MetroCanvasGrid : ContentControl
    {
        internal static readonly DependencyProperty ViewportProperty = ElementBase.Property<MetroCanvasGrid, Rect>(nameof(ViewportProperty));
        internal Rect Viewport { get { return (Rect)GetValue(ViewportProperty); } set { SetValue(ViewportProperty, value); } }



        public static readonly DependencyProperty GridOpacityProperty = ElementBase.Property<MetroCanvasGrid, double>(nameof(GridOpacityProperty));
        public static readonly DependencyProperty GridSizeProperty = ElementBase.Property<MetroCanvasGrid, double>(nameof(GridSizeProperty));
        public static readonly DependencyProperty CornerRadiusProperty = ElementBase.Property<MetroCanvasGrid, CornerRadius>(nameof(CornerRadiusProperty));

        public double GridOpacity { get { return (double)GetValue(GridOpacityProperty); } set { SetValue(GridOpacityProperty, value); } }
        public double GridSize { get { return (double)GetValue(GridSizeProperty); } set { SetValue(GridSizeProperty, value); SizeChange(); } }
        public CornerRadius CornerRadius { get { return (CornerRadius)GetValue(CornerRadiusProperty); } set { SetValue(CornerRadiusProperty, value); } }

        public bool IsApplyTheme { get; set; } = true;

        void SizeChange()
        {
            Viewport = new Rect(0.0, 0.0, GridSize * 2 / ActualWidth, GridSize * 2 / ActualHeight);
        }

        public MetroCanvasGrid()
        {
            Utility.Refresh(this);
            Loaded += delegate { SizeChange(); };
            SizeChanged += delegate { SizeChange(); };
        }

        static MetroCanvasGrid()
        {
            ElementBase.DefaultStyle<MetroCanvasGrid>(DefaultStyleKeyProperty);
        }
    }
}