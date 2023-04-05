using System.Windows;
using System.Windows.Controls;

namespace Arthas.Controls;

public class MetroGroup : GroupBox
{
    static MetroGroup()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(MetroGroup), new FrameworkPropertyMetadata(typeof(MetroGroup)));
    }
}
