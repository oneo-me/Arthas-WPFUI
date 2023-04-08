using System.Windows;
using System.Windows.Controls;

namespace Arthas.Controls;

public class MetroMenuSeparator : Separator
{
    static MetroMenuSeparator()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(MetroMenuSeparator), new FrameworkPropertyMetadata(typeof(MetroMenuSeparator)));
    }
}
