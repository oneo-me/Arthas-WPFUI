using System.Windows.Controls;
using Arthas.Utility.Element;

namespace Arthas.Controls;

public class MetroContextMenu : ContextMenu
{
    static MetroContextMenu()
    {
        ElementBase.DefaultStyle<MetroContextMenu>(DefaultStyleKeyProperty);
    }
}
