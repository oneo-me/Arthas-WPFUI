using Arthas.Utility.Element;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Arthas.Controls.Metro
{
    public class MetroSwitch : ToggleButton
    {
        public static readonly DependencyProperty TextHorizontalAlignmentProperty = ElementBase.Property<MetroSwitch, HorizontalAlignment>(nameof(TextHorizontalAlignmentProperty), HorizontalAlignment.Left);
        public static readonly DependencyProperty CornerRadiusProperty = ElementBase.Property<MetroSwitch, CornerRadius>(nameof(CornerRadiusProperty), new CornerRadius(10));
        public static readonly DependencyProperty BorderCornerRadiusProperty = ElementBase.Property<MetroSwitch, CornerRadius>(nameof(BorderCornerRadiusProperty), new CornerRadius(12));

        public HorizontalAlignment TextHorizontalAlignment { get { return (HorizontalAlignment)GetValue(TextHorizontalAlignmentProperty); } set { SetValue(TextHorizontalAlignmentProperty, value); } }
        public CornerRadius CornerRadius { get { return (CornerRadius)GetValue(CornerRadiusProperty); } set { SetValue(CornerRadiusProperty, value); } }
        public CornerRadius BorderCornerRadius { get { return (CornerRadius)GetValue(BorderCornerRadiusProperty); } set { SetValue(BorderCornerRadiusProperty, value); } }

        public MetroSwitch()
        {
            Loaded += delegate { ElementBase.GoToState(this, (bool)IsChecked ? "OpenLoaded" : "CloseLoaded"); };
        }

        protected override void OnChecked(RoutedEventArgs e)
        {
            base.OnChecked(e);
            ElementBase.GoToState(this, "Open");
        }

        protected override void OnUnchecked(RoutedEventArgs e)
        {
            base.OnChecked(e);
            ElementBase.GoToState(this, "Close");
        }

        static MetroSwitch()
        {
            ElementBase.DefaultStyle<MetroSwitch>(DefaultStyleKeyProperty);
        }
        public static DependencyProperty ReloadCommandProperty
= DependencyProperty.Register(
    "ReloadCommand",
    typeof(ICommand),
    typeof(MetroSwitch));

        public static DependencyProperty SaveCommandProperty
            = DependencyProperty.Register(
                "SaveCommand",
                typeof(ICommand),
                typeof(MetroSwitch));

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