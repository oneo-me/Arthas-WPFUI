using Arthas.Utility.Element;
using System.Windows.Controls;

namespace Arthas.Controls
{
    public class MetroTextButton : Button
    {
        static MetroTextButton()
        {
            ElementBase.DefaultStyle<MetroTextButton>(DefaultStyleKeyProperty);
        }
    }
}