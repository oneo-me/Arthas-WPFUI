using Arthas.Controls.Metro;
using Arthas.Utility.Media;
using System.ComponentModel;
using System.Windows;

namespace Arthas.Controls
{
    public class Utility
    {
        /// <summary>
        /// 刷新样式
        /// </summary>
        /// <param name="control"></param>
        public static void Refresh(FrameworkElement control)
        {
            if (control == null)
            {
                return;
            }
            if (!DesignerProperties.GetIsInDesignMode(control))
            {
                if (control.IsLoaded)
                {
                    SetColor(control);
                }
                else
                {
                    control.Loaded += delegate { SetColor(control); };
                }
            }
        }

        static void SetColor(FrameworkElement control)
        {
            var mw = Window.GetWindow(control) is MetroWindow ? Window.GetWindow(control) as MetroWindow : null;
            if (mw != null)
            {
                if (control is MetroTitleMenu) { (control as MetroTitleMenu).Background = mw.BorderBrush; }
                if (control is MetroTitleMenuItem) { (control as MetroTitleMenuItem).Background = mw.BorderBrush; }
                if (control is MetroMenuItem) { (control as MetroMenuItem).Background = mw.BorderBrush; }
                if (control is MetroContextMenu) { (control as MetroContextMenu).Background = mw.BorderBrush; }
                if (control is MetroTextBox) { (control as MetroTextBox).BorderBrush = mw.BorderBrush; }
                if (control is MetroButton) { (control as MetroButton).Background = mw.BorderBrush; }
                if (control is MetroMenuTabControl) { (control as MetroMenuTabControl).BorderBrush = mw.BorderBrush; }
                if (control is MetroRichTextBox) { (control as MetroRichTextBox).MouseMoveThemeBorderBrush = mw.BorderBrush; }
                if (control is MetroCanvasGrid) { if ((control as MetroCanvasGrid).IsApplyTheme) (control as MetroCanvasGrid).Background = new RgbaColor(mw.BorderBrush).OpaqueSolidColorBrush; }
                if (control is MetroColorPicker) { (control as MetroColorPicker).BorderBrush = mw.BorderBrush; }
            }
        }
    }
}