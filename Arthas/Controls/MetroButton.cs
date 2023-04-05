using System.Windows;
using System.Windows.Controls;
using Arthas.Utility.Element;

namespace Arthas.Controls;

public enum ButtonState
{
    None,
    Red,
    Green
}

public class MetroButton : Button
{
    public static readonly DependencyProperty MetroButtonStateProperty = ElementBase.Property<MetroButton, ButtonState>(nameof(MetroButtonStateProperty), ButtonState.None);

    public ButtonState MetroButtonState
    {
        get => (ButtonState)GetValue(MetroButtonStateProperty);
        set => SetValue(MetroButtonStateProperty, value);
    }

    static MetroButton()
    {
        ElementBase.DefaultStyle<MetroButton>(DefaultStyleKeyProperty);
    }
}
