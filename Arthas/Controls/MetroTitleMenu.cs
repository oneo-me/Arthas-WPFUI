using System.Windows.Controls;
using Arthas.Utility.Element;

namespace Arthas.Controls;

public class MetroTitleMenu : Menu
{
    static MetroTitleMenu()
    {
        ElementBase.DefaultStyle<MetroTitleMenu>(DefaultStyleKeyProperty);
    }
}
