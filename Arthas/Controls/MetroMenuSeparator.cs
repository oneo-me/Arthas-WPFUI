using System.Windows.Controls;
using Arthas.Utility.Element;

namespace Arthas.Controls;

public class MetroMenuSeparator : Separator
{
    static MetroMenuSeparator()
    {
        ElementBase.DefaultStyle<MetroMenuSeparator>(DefaultStyleKeyProperty);
    }
}
