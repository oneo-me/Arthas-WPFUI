using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Arthas.Controls.Metro
{
    /*
    public class MetroTextBlock : ContentControl
    {

        public static readonly DependencyProperty SpacingProperty = ElementBase.Property<MetroTextBlock, Thickness>(nameof(SpacingProperty), new Thickness(0.25));
        public Thickness Spacing
        {
            get { return (Thickness)GetValue(SpacingProperty); }
            set { SetValue(SpacingProperty, value); }
        }
        public static readonly DependencyProperty TextProperty = ElementBase.Property<MetroTextBlock, string>(nameof(TextProperty), "");
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        static MetroTextBlock()
        {
            ElementBase.DefaultStyle<MetroTextBlock>(DefaultStyleKeyProperty);
        }
    }
    */
    public class MetroTextBlock : TextBlock
    {
        public static DependencyProperty ReloadCommandProperty
= DependencyProperty.Register(
   "ReloadCommand",
   typeof(ICommand),
   typeof(MetroTextBlock));

        public static DependencyProperty SaveCommandProperty
            = DependencyProperty.Register(
                "SaveCommand",
                typeof(ICommand),
                typeof(MetroTextBlock));

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