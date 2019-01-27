using Arthas.Utility.Element;
using System.Windows.Controls;

namespace Arthas.Controls.Metro
{
    public class MetroMenuSeparator : Separator
    {
        static MetroMenuSeparator()
        {
            ElementBase.DefaultStyle<MetroMenuSeparator>(DefaultStyleKeyProperty);
        }
    }
}