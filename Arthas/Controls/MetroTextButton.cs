using System.Windows;
using System.Windows.Controls;

namespace Arthas.Controls;

public class MetroTextButton : Button
{
    static MetroTextButton()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(MetroTextButton), new FrameworkPropertyMetadata(typeof(MetroTextButton)));
    }
}
