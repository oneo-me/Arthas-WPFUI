using Arthas.Utility.Element;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Arthas.Controls.Metro
{
    public class MetroSwitch : Button
    {
        public static readonly DependencyProperty IsOpenProperty = ElementBase.Property<MetroSwitch, bool>(nameof(IsOpenProperty), false);
        public static readonly DependencyProperty TextHorizontalAlignmentProperty = ElementBase.Property<MetroSwitch, HorizontalAlignment>(nameof(TextHorizontalAlignmentProperty), HorizontalAlignment.Left);
        public static readonly DependencyProperty CornerRadiusProperty = ElementBase.Property<MetroSwitch, CornerRadius>(nameof(CornerRadiusProperty), new CornerRadius(10));
        public static readonly DependencyProperty BorderCornerRadiusProperty = ElementBase.Property<MetroSwitch, CornerRadius>(nameof(BorderCornerRadiusProperty), new CornerRadius(12));

        public bool IsOpen { get { return (bool)GetValue(IsOpenProperty); } set { SetValue(IsOpenProperty, value); GoToState(); } }
        public HorizontalAlignment TextHorizontalAlignment { get { return (HorizontalAlignment)GetValue(TextHorizontalAlignmentProperty); } set { SetValue(TextHorizontalAlignmentProperty, value); } }
        public CornerRadius CornerRadius { get { return (CornerRadius)GetValue(CornerRadiusProperty); } set { SetValue(CornerRadiusProperty, value); } }
        public CornerRadius BorderCornerRadius { get { return (CornerRadius)GetValue(BorderCornerRadiusProperty); } set { SetValue(BorderCornerRadiusProperty, value); } }

        public event EventHandler StateChanged;
        public MetroSwitch()
        {
            Loaded += delegate { ElementBase.GoToState(this, IsOpen ? "OpenLoaded" : "CloseLoaded"); };
            Click += delegate { IsOpen = !IsOpen; if (StateChanged != null) { StateChanged(this,null); } };
        }

        void GoToState()
        {
            ElementBase.GoToState(this, IsOpen ? "Open" : "Close");
        }

        static MetroSwitch()
        {
            ElementBase.DefaultStyle<MetroSwitch>(DefaultStyleKeyProperty);
        }
    }
}