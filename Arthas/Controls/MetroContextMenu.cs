using System.Windows;
using System.Windows.Controls;

namespace Arthas.Controls;

public class MetroContextMenu : ContextMenu
{
    static MetroContextMenu()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(MetroContextMenu), new FrameworkPropertyMetadata(typeof(MetroContextMenu)));
    }
}
