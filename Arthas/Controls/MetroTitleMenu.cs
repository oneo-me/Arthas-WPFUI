using Arthas.Utility.Element;
using System.Windows.Controls;

namespace Arthas.Controls.Metro
{
    public class MetroTitleMenu : Menu
    {
        public MetroTitleMenu()
        {
            Utility.Refresh(this);
        }

        static MetroTitleMenu()
        {
            ElementBase.DefaultStyle<MetroTitleMenu>(DefaultStyleKeyProperty);
        }
    }
}