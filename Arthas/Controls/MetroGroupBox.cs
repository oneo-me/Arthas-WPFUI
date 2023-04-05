using System.Windows.Controls;
using Arthas.Utility.Element;

namespace Arthas.Controls;

public class MetroGroupBox : GroupBox
{
    static MetroGroupBox()
    {
        ElementBase.DefaultStyle<MetroGroupBox>(DefaultStyleKeyProperty);
    }
}
