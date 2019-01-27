using Arthas.Utility.Element;
using System.Windows.Controls;

namespace Arthas.Controls
{
    public class MetroGroupBox : GroupBox
    {
        static MetroGroupBox()
        {
            ElementBase.DefaultStyle<MetroGroupBox>(DefaultStyleKeyProperty);
        }
    }
}