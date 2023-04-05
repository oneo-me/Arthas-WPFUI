using System.Windows.Controls;
using Arthas.Utility.Element;

namespace Arthas.Controls;

public class MetroScrollViewer : ScrollViewer
{
    static MetroScrollViewer()
    {
        ElementBase.DefaultStyle<MetroScrollViewer>(DefaultStyleKeyProperty);
    }
}
