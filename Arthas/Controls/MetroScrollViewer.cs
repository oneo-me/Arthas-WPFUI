using Arthas.Utility.Element;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Arthas.Controls.Metro
{
    public class MetroScrollViewer : ScrollViewer
    {
        public static readonly DependencyProperty FloatProperty = ElementBase.Property<MetroScrollViewer, bool>(nameof(FloatProperty));
        public static readonly DependencyProperty AutoLimitMouseProperty = ElementBase.Property<MetroScrollViewer, bool>(nameof(AutoLimitMouseProperty));
        public static readonly DependencyProperty VerticalMarginProperty = ElementBase.Property<MetroScrollViewer, Thickness>(nameof(VerticalMarginProperty));
        public static readonly DependencyProperty HorizontalMarginProperty = ElementBase.Property<MetroScrollViewer, Thickness>(nameof(HorizontalMarginProperty));

        public bool Float { get { return (bool)GetValue(FloatProperty); } set { SetValue(FloatProperty, value); } }
        public bool AutoLimitMouse { get { return (bool)GetValue(AutoLimitMouseProperty); } set { SetValue(AutoLimitMouseProperty, value); } }
        public Thickness VerticalMargin { get { return (Thickness)GetValue(VerticalMarginProperty); } set { SetValue(VerticalMarginProperty, value); } }
        public Thickness HorizontalMargin { get { return (Thickness)GetValue(HorizontalMarginProperty); } set { SetValue(HorizontalMarginProperty, value); } }

        public MetroScrollViewer()
        {
            Utility.Refresh(this);
        }

        static MetroScrollViewer()
        {
            ElementBase.DefaultStyle<MetroScrollViewer>(DefaultStyleKeyProperty);
        }
    }
}