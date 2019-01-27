using Arthas.Utility.Element;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Arthas.Controls.Metro
{
    public class MetroMenuItem : MenuItem
    {
        public static readonly new DependencyProperty IconProperty = ElementBase.Property<MetroMenuItem, ImageSource>(nameof(IconProperty), null);

        public new ImageSource Icon { get { return (ImageSource)GetValue(IconProperty); } set { SetValue(IconProperty, value); } }

        public MetroMenuItem()
        {
            Utility.Refresh(this);
        }

        static MetroMenuItem()
        {
            ElementBase.DefaultStyle<MetroMenuItem>(DefaultStyleKeyProperty);
        }
    }
}