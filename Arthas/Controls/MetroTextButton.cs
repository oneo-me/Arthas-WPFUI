using Arthas.Utility.Element;
using System.Windows.Controls;

namespace Arthas.Controls.Metro
{
    public class MetroTextButton : Button
    {
        static MetroTextButton()
        {
            ElementBase.DefaultStyle<MetroTextButton>(DefaultStyleKeyProperty);
        }
    }
}