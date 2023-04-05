using System.Windows;
using Arthas.Controls;
using OpenView;

namespace Arthas.Binder;

public abstract class MetroDialogModel<TUserControl> : DialogModel<TUserControl> where TUserControl : View, new()
{
    protected override Window CreateWindowOverride()
    {
        return new MetroWindow();
    }
}
