using System.Windows;
using System.Windows.Controls;

namespace Arthas.Controls;

public class MetroButton : Button
{
    static MetroButton()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(MetroButton), new FrameworkPropertyMetadata(typeof(MetroButton)));
    }

    public static readonly DependencyProperty ButtonStateProperty = DependencyProperty.Register(nameof(ButtonState), typeof(MetroButtonState), typeof(MetroButton), new(MetroButtonState.None));

    public MetroButtonState ButtonState
    {
        get => (MetroButtonState)GetValue(ButtonStateProperty);
        set => SetValue(ButtonStateProperty, value);
    }
}
