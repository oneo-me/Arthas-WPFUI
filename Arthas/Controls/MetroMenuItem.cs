﻿using System.Windows;
using System.Windows.Controls;

namespace Arthas.Controls;

public class MetroMenuItem : MenuItem
{
    static MetroMenuItem()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(MetroMenuItem), new FrameworkPropertyMetadata(typeof(MetroMenuItem)));
    }

    protected override DependencyObject GetContainerForItemOverride()
    {
        return new MetroMenuItem();
    }
}
