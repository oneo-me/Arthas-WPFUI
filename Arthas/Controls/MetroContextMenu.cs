using Arthas.Utility.Element;
using System.Windows.Controls;

namespace Arthas.Controls.Metro
{
    public class MetroContextMenu : ContextMenu
    {
        public MetroContextMenu()
        {
            Utility.Refresh(this);
        }

        static MetroContextMenu()
        {
            ElementBase.DefaultStyle<MetroContextMenu>(DefaultStyleKeyProperty);
        }
    }
}