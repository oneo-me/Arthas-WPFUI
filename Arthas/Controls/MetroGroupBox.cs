using Arthas.Utility.Element;
using System.Windows.Controls;

namespace Arthas.Controls.Metro
{
    public class MetroGroupBox : GroupBox
    {
        static MetroGroupBox()
        {
            ElementBase.DefaultStyle<MetroGroupBox>(DefaultStyleKeyProperty);
        }
    }
}