using System.Windows;
using System.Windows.Controls;
using Arthas.Utility.Element;

namespace Arthas.Controls;

public class MetroTabControl : TabControl
{
    void SelectionState()
    {
        ElementBase.GoToState(this, "SelectionStart");
        ElementBase.GoToState(this, "SelectionEnd");
    }

    protected override DependencyObject GetContainerForItemOverride()
    {
        return new MetroTabItem();
    }

    public MetroTabControl()
    {
        Loaded += delegate
        {
            ElementBase.GoToState(this, "SelectionLoaded");
        };
        SelectionChanged += delegate(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is MetroTabControl)
                SelectionState();
        };
    }

    static MetroTabControl()
    {
        ElementBase.DefaultStyle<MetroTabControl>(DefaultStyleKeyProperty);
    }
}
