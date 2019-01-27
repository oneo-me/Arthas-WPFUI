using Arthas.Utility.Element;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Arthas.Controls.Metro
{
    public class MetroTitleMenuItem : MenuItem
    {
        public static readonly new DependencyProperty IconProperty = ElementBase.Property<MetroTitleMenuItem, ImageSource>(nameof(IconProperty), null);

        public new ImageSource Icon { get { return (ImageSource)GetValue(IconProperty); } set { SetValue(IconProperty, value); } }

        public MetroTitleMenuItem()
        {
            Utility.Refresh(this);
        }

        static MetroTitleMenuItem()
        {
            ElementBase.DefaultStyle<MetroTitleMenuItem>(DefaultStyleKeyProperty);
        }
    }
}