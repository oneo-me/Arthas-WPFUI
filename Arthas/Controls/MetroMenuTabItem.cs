using Arthas.Utility.Element;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Arthas.Controls.Metro
{
    public class MetroMenuTabItem : TabItem
    {
        public static readonly DependencyProperty IconProperty = ElementBase.Property<MetroMenuTabItem, ImageSource>(nameof(IconProperty), null);
        public static readonly DependencyProperty IconMoveProperty = ElementBase.Property<MetroMenuTabItem, ImageSource>(nameof(IconMoveProperty), null);
        public static readonly DependencyProperty TextHorizontalAlignmentProperty = ElementBase.Property<MetroMenuTabItem, HorizontalAlignment>(nameof(TextHorizontalAlignmentProperty), HorizontalAlignment.Right);

        public ImageSource Icon { get { return (ImageSource)GetValue(IconProperty); } set { SetValue(IconProperty, value); } }
        public ImageSource IconMove { get { return (ImageSource)GetValue(IconMoveProperty); } set { SetValue(IconMoveProperty, value); } }
        public HorizontalAlignment TextHorizontalAlignment { get { return (HorizontalAlignment)GetValue(TextHorizontalAlignmentProperty); } set { SetValue(TextHorizontalAlignmentProperty, value); } }

        static MetroMenuTabItem()
        {
            ElementBase.DefaultStyle<MetroMenuTabItem>(DefaultStyleKeyProperty);
        }
    }
}