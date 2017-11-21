using Arthas.Utility.Element;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Arthas.Controls.Metro
{
    public class MetroTabItem : TabItem
    {
        public static readonly DependencyProperty IconProperty = ElementBase.Property<MetroTabItem, ImageSource>(nameof(IconProperty), null);

        public ImageSource Icon { get { return (ImageSource)GetValue(IconProperty); } set { SetValue(IconProperty, value); } }

        static MetroTabItem()
        {
            ElementBase.DefaultStyle<MetroTabItem>(DefaultStyleKeyProperty);
        }
        public static DependencyProperty ReloadCommandProperty
= DependencyProperty.Register(
    "ReloadCommand",
    typeof(ICommand),
    typeof(MetroTabItem));

        public static DependencyProperty SaveCommandProperty
            = DependencyProperty.Register(
                "SaveCommand",
                typeof(ICommand),
                typeof(MetroTabItem));

        public ICommand ReloadCommand
        {
            get
            {
                return (ICommand)GetValue(ReloadCommandProperty);
            }

            set
            {
                SetValue(ReloadCommandProperty, value);
            }
        }

        public ICommand SaveCommand
        {
            get
            {
                return (ICommand)GetValue(SaveCommandProperty);
            }

            set
            {
                SetValue(SaveCommandProperty, value);
            }
        }
    }
}