using Arthas.Utility.Element;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Arthas.Controls.Metro
{
    public class MetroComboBox : ComboBox
    {
        public static readonly DependencyProperty TitleProperty = ElementBase.Property<MetroComboBox, string>(nameof(TitleProperty), "");
        public static readonly DependencyProperty IconProperty = ElementBase.Property<MetroComboBox, ImageSource>(nameof(IconProperty), null);

        public string Title { get { return (string)GetValue(TitleProperty); } set { SetValue(TitleProperty, value); } }
        public ImageSource Icon { get { return (ImageSource)GetValue(IconProperty); } set { SetValue(IconProperty, value); } }

        public MetroComboBox()
        {
            Utility.Refresh(this);
        }

        static MetroComboBox()
        {
            ElementBase.DefaultStyle<MetroComboBox>(DefaultStyleKeyProperty);
        }
    }
}