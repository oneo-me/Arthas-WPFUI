using Arthas.Utility.Element;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Arthas.Controls.Metro
{
    public class MetroFocusButton : Button
    {
        public static readonly DependencyProperty MouseMoveForegroundProperty = ElementBase.Property<MetroFocusButton, Brush>(nameof(MouseMoveForegroundProperty));
        public static readonly DependencyProperty MouseMoveBorderBrushProperty = ElementBase.Property<MetroFocusButton, Brush>(nameof(MouseMoveBorderBrushProperty));
        public static readonly new DependencyProperty BorderThicknessProperty = ElementBase.Property<MetroFocusButton, double>(nameof(BorderThicknessProperty));
        public static readonly DependencyProperty MouseMoveBorderThicknessProperty = ElementBase.Property<MetroFocusButton, double>(nameof(MouseMoveBorderThicknessProperty));
        public static readonly DependencyProperty StrokeDashArrayProperty = ElementBase.Property<MetroFocusButton, DoubleCollection>(nameof(StrokeDashArrayProperty));
        public static readonly DependencyProperty MouseMoveStrokeDashArrayProperty = ElementBase.Property<MetroFocusButton, DoubleCollection>(nameof(MouseMoveStrokeDashArrayProperty));
        public static readonly DependencyProperty CornerRadiusProperty = ElementBase.Property<MetroFocusButton, double>(nameof(CornerRadiusProperty));

        public Brush MouseMoveForeground { get { return (Brush)GetValue(MouseMoveForegroundProperty); } set { SetValue(MouseMoveForegroundProperty, value); } }
        public Brush MouseMoveBorderBrush { get { return (Brush)GetValue(MouseMoveBorderBrushProperty); } set { SetValue(MouseMoveBorderBrushProperty, value); } }
        public new double BorderThickness { get { return (double)GetValue(BorderThicknessProperty); } set { SetValue(BorderThicknessProperty, value); } }
        public double MouseMoveBorderThickness { get { return (double)GetValue(MouseMoveBorderThicknessProperty); } set { SetValue(MouseMoveBorderThicknessProperty, value); } }
        public DoubleCollection StrokeDashArray { get { return (DoubleCollection)GetValue(StrokeDashArrayProperty); } set { SetValue(StrokeDashArrayProperty, value); } }
        public DoubleCollection MouseMoveStrokeDashArray { get { return (DoubleCollection)GetValue(MouseMoveStrokeDashArrayProperty); } set { SetValue(MouseMoveStrokeDashArrayProperty, value); } }
        public double CornerRadius { get { return (double)GetValue(CornerRadiusProperty); } set { SetValue(CornerRadiusProperty, value); } }

        static MetroFocusButton()
        {
            ElementBase.DefaultStyle<MetroFocusButton>(DefaultStyleKeyProperty);
        }
    }
}