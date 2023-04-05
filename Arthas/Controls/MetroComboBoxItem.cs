using System.Windows.Controls;
using Arthas.Utility.Element;

namespace Arthas.Controls;

public class MetroComboBoxItem : ComboBoxItem
{
    static MetroComboBoxItem()
    {
        ElementBase.DefaultStyle<MetroComboBoxItem>(DefaultStyleKeyProperty);
    }
}
