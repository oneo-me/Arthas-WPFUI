using System.Windows.Controls;
using Arthas.Utility.Element;

namespace Arthas.Controls;

public class MetroTextButton : Button
{
    static MetroTextButton()
    {
        ElementBase.DefaultStyle<MetroTextButton>(DefaultStyleKeyProperty);
    }
}
