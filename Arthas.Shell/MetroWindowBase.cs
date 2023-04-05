using System;
using System.Windows;
using System.Windows.Interop;
using Arthas.Shell.Interop;

namespace Arthas.Shell;

public class MetroWindowBase : Window
{
    readonly MetroWindowChrome _chrome;

    protected MetroWindowBase()
    {
        _chrome = new(this);

        WindowStartupLocation = WindowStartupLocation.CenterScreen;

        CommandBindings.Add(new(SystemCommands.MinimizeWindowCommand, delegate
        {
            SystemCommands.MinimizeWindow(this);
        }));

        CommandBindings.Add(new(SystemCommands.MaximizeWindowCommand, delegate
        {
            ChangWindowState();
        }));

        CommandBindings.Add(new(SystemCommands.RestoreWindowCommand, delegate
        {
            ChangWindowState();
        }));

        CommandBindings.Add(new(SystemCommands.CloseWindowCommand, delegate
        {
            SystemCommands.CloseWindow(this);
        }));

        ContentRendered += OnContentRendered;
    }

    void OnContentRendered(object? sender, EventArgs e)
    {
        ContentRendered -= OnContentRendered;
        Activate();
    }

    protected void ChangWindowState()
    {
        switch (ResizeMode)
        {
            case ResizeMode.CanResize:
            case ResizeMode.CanResizeWithGrip:

                break;

            default:

                return;
        }

        switch (WindowState)
        {
            case WindowState.Normal:

                SystemCommands.MaximizeWindow(this);

                break;

            case WindowState.Maximized:

                SystemCommands.RestoreWindow(this);

                break;
        }
    }

    public IntPtr Handle { get; private set; }
    public IntPtr OwnerHandle { get; private set; }
    public HwndSource? HwndSource { get; private set; }

    protected override void OnSourceInitialized(EventArgs e)
    {
        var windowInteropHelper = new WindowInteropHelper(this);
        windowInteropHelper.EnsureHandle();

        Handle = windowInteropHelper.Handle;
        OwnerHandle = windowInteropHelper.Owner;
        HwndSource = HwndSource.FromHwnd(Handle);

        _chrome.OnSourceInitialized();

        base.OnSourceInitialized(e);
    }

    protected override void OnStateChanged(EventArgs e)
    {
        base.OnStateChanged(e);
        _chrome.OnStateChanged();
    }

    public bool IsClosed { get; private set; }

    protected override void OnClosed(EventArgs e)
    {
        base.OnClosed(e);
        IsClosed = true;
        Owner.BringToFront();
        _chrome.OnClosed();
    }

    protected override void OnDeactivated(EventArgs e)
    {
        base.OnDeactivated(e);
        TopMostHack();
    }

    protected override void OnLostFocus(RoutedEventArgs e)
    {
        base.OnLostFocus(e);
        TopMostHack();
    }

    void TopMostHack()
    {
        if (!Topmost)
            return;

        SetCurrentValue(TopmostProperty, false);
        SetCurrentValue(TopmostProperty, true);
    }

    protected void SendCaptionMessage()
    {
        Win32.SendMessage(Handle, WM.NCLBUTTONDOWN, (IntPtr)HT.CAPTION, IntPtr.Zero);
    }
}
