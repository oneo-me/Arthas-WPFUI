using System.Windows;
using System.Windows.Controls;

namespace Arthas.Controls;

public class MetroScrollViewer : ScrollViewer
{
    static MetroScrollViewer()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(MetroScrollViewer), new FrameworkPropertyMetadata(typeof(MetroScrollViewer)));
    }
}
