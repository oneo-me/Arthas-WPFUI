using System.Windows;
using System.Windows.Controls;

namespace Arthas.Controls;

public class MetroTabControl : TabControl
{
    void SelectionState()
    {
        VisualStateManager.GoToState(this, "SelectionStart", false);
        VisualStateManager.GoToState(this, "SelectionEnd", false);
    }

    protected override DependencyObject GetContainerForItemOverride()
    {
        return new MetroTabItem();
    }

    public MetroTabControl()
    {
        Loaded += delegate
        {
            VisualStateManager.GoToState(this, "SelectionLoaded", false);
        };
        SelectionChanged += delegate(object _, SelectionChangedEventArgs e)
        {
            if (e.Source is MetroTabControl)
                SelectionState();
        };
    }

    static MetroTabControl()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(MetroTabControl), new FrameworkPropertyMetadata(typeof(MetroTabControl)));
    }
}
