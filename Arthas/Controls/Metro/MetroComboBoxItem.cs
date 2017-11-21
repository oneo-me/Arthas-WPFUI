﻿using Arthas.Utility.Element;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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

        public static DependencyProperty ReloadCommandProperty
= DependencyProperty.Register(
    "ReloadCommand",
    typeof(ICommand),
    typeof(MetroComboBoxItem));

        public static DependencyProperty SaveCommandProperty
            = DependencyProperty.Register(
                "SaveCommand",
                typeof(ICommand),
                typeof(MetroComboBoxItem));

        public ICommand ReloadCommand
        {
            get
            {
                return (ICommand)GetValue(ReloadCommandProperty);
            }

            set
            {
                SetValue(ReloadCommandProperty, value);
            }
        }

        public ICommand SaveCommand
        {
            get
            {
                return (ICommand)GetValue(SaveCommandProperty);
            }

            set
            {
                SetValue(SaveCommandProperty, value);
            }
        }
    }
}