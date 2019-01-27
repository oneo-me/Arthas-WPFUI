using Arthas.Utility.Element;
using System.Windows.Controls;

namespace Arthas.Controls.Metro
{
    public class MetroComboBoxItem : ComboBoxItem
    {
        public MetroComboBoxItem()
        {
            Utility.Refresh(this);
        }

        static MetroComboBoxItem()
        {
            ElementBase.DefaultStyle<MetroComboBoxItem>(DefaultStyleKeyProperty);
        }
    }
}