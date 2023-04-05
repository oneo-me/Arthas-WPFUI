using System.Windows;
using System.Windows.Controls;

namespace Arthas.Controls;

public class MetroBorder : Border
{
    static MetroBorder()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(MetroBorder), new FrameworkPropertyMetadata(typeof(MetroBorder)));
    }
}
