using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Security;
using System.Windows;
using System.Windows.Shell;
using Arthas.Shell.Interop;

namespace Arthas.Shell;

[SuppressMessage("ReSharper", "InconsistentNaming")]
class MetroWindowChrome
{
    readonly MetroWindowBase window;

    [SecuritySafeCritical]
    public MetroWindowChrome(MetroWindowBase window)
    {
        this.window = window;

        window.SetCurrentValue(Window.AllowsTransparencyProperty, false);
        window.SetCurrentValue(Window.WindowStyleProperty, WindowStyle.None);
    }

    public void OnSourceInitialized()
    {
        WindowChrome.SetWindowChrome(window, new()
        {
            CaptionHeight = 0,
            CornerRadius = new(0),
            GlassFrameThickness = new(1),
            NonClientFrameEdges = NonClientFrameEdges.None,
            ResizeBorderThickness = new(6),
            UseAeroCaptionButtons = false
        });

        if (window.SizeToContent != SizeToContent.Manual && window.WindowState == WindowState.Normal)
            window.InvalidateMeasure();

        window.HwndSource?.AddHook(WindowProc);

        UpdateFrameState(true);
        HandleMaximize();
    }

    bool isCleanedUp;

    public void OnClosed()
    {
        if (isCleanedUp)
            return;

        isCleanedUp = true;

        window.HwndSource?.RemoveHook(WindowProc);
    }

    public void OnStateChanged()
    {
        HandleMaximize();
    }

    static IntPtr HWND_NOTOPMOST { get; } = new(-2);

    void HandleMaximize()
    {
        if (window.WindowState != WindowState.Maximized)
            return;

        if (window.SizeToContent != SizeToContent.Manual)
            window.SetCurrentValue(Window.SizeToContentProperty, SizeToContent.Manual);

        if (window.Handle == IntPtr.Zero)
            return;

        var workingArea = ScreenHelper.FormWindow(window).WorkingArea;
        Win32.SetWindowPos(window.Handle, HWND_NOTOPMOST, workingArea.Left, workingArea.Top, workingArea.Width,
            workingArea.Height, SWP.SHOWWINDOW);
    }

    [SecurityCritical]
    IntPtr WindowProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
    {
        return (WM)msg switch
        {
            WM.NCPAINT    => HandleNCPAINT(out handled),
            WM.DPICHANGED => HandleDPICHANGED(lParam, out handled),
            WM.NCCALCSIZE => HandleNCCALCSIZE(wParam, lParam, out handled),
            _             => IntPtr.Zero
        };
    }

    [SecurityCritical]
    static IntPtr HandleNCPAINT(out bool handled)
    {
        handled = false;

        return IntPtr.Zero;
    }

    static bool MinimizeAnimation => SystemParameters.MinimizeAnimation && Win32.DwmIsCompositionEnabled();

    bool dpiChanged;

    [SecurityCritical]
    IntPtr HandleDPICHANGED(IntPtr lParam, out bool handled)
    {
        dpiChanged = true;

        if (_GetHwndState() == WindowState.Normal)
        {
            var rect = (RECT)Marshal.PtrToStructure(lParam, typeof(RECT))!;
            rect.Bottom += 1;
            Marshal.StructureToPtr(rect, lParam, true);
        }

        handled = false;

        return IntPtr.Zero;
    }

    [SecurityCritical]
    IntPtr HandleNCCALCSIZE(IntPtr wParam, IntPtr lParam, out bool handled)
    {
        // lParam is an [in, out] that can be either a RECT* (wParam == FALSE) or an NCCALCSIZE_PARAMS*.
        // Since the first field of NCCALCSIZE_PARAMS is a RECT and is the only field we care about
        // we can unconditionally treat it as a RECT.

        if (dpiChanged)
        {
            dpiChanged = false;
            handled = true;

            return IntPtr.Zero;
        }

        if (MinimizeAnimation
            && _GetHwndState() == WindowState.Maximized)
        {
            var workingArea = ScreenHelper.FormWindow(window).WorkingArea;

            var rc = (RECT)Marshal.PtrToStructure(lParam, typeof(RECT))!;
            rc.Left = workingArea.Left;
            rc.Top = workingArea.Top;
            rc.Right = workingArea.Right;
            rc.Bottom = workingArea.Bottom;

            Marshal.StructureToPtr(rc, lParam, true);
        }

        handled = true;

        // Per MSDN for NCCALCSIZE, always return 0 when wParam == FALSE
        //
        // Returning 0 when wParam == TRUE is not appropriate - it will preserve
        // the old client area and align it with the upper-left corner of the new
        // client area. So we simply ask for a redraw (WVR_REDRAW)

        var retVal = IntPtr.Zero;

        if (wParam.ToInt32() != 0) // wParam == TRUE
            // Using the combination of WVR.VALIDRECTS and WVR.REDRAW gives the smoothest
            // resize behavior we can achieve here.
            retVal = new((int)(WVR.VALIDRECTS | WVR.REDRAW));

        return retVal;
    }

    [SecurityCritical]
    void UpdateFrameState(bool force)
    {
        if (window.Handle == IntPtr.Zero || window.HwndSource?.IsDisposed != false)
            return;

        if (!force)
            return;

        if (window.HwndSource.IsDisposed) // If the window got closed very early
            return;

        if (MinimizeAnimation)
            ModifyStyle(0, WS.CAPTION);
        else
            ModifyStyle(WS.CAPTION, 0);

        Win32.SetWindowPos(window.Handle, IntPtr.Zero, 0, 0, 0, 0,
            SWP.FRAMECHANGED | SWP.NOSIZE | SWP.NOMOVE | SWP.NOZORDER | SWP.NOOWNERZORDER | SWP.NOACTIVATE);
    }

    /// <summary>
    ///     Get the WindowState as the native HWND knows it to be.  This isn't necessarily the same as what Window thinks.
    /// </summary>
    [SecurityCritical]
    WindowState _GetHwndState()
    {
        var wpl = Win32.GetWindowPlacement(window.Handle);

        return wpl.showCmd switch
        {
            SW.SHOWMINIMIZED => WindowState.Minimized,
            SW.SHOWMAXIMIZED => WindowState.Maximized,
            _                => WindowState.Normal
        };
    }

    /// <summary>Add and remove a native WindowStyle from the HWND.</summary>
    /// <param name="removeStyle">The styles to be removed.  These can be bitwise combined.</param>
    /// <param name="addStyle">The styles to be added.  These can be bitwise combined.</param>
    /// <returns>Whether the styles of the HWND were modified as a result of this call.</returns>
    /// <SecurityNote>
    ///     Critical : Calls critical methods
    /// </SecurityNote>
    [SecurityCritical]
    void ModifyStyle(WS removeStyle, WS addStyle)
    {
        var dwStyle = Win32.GetWindowStyle(window.Handle);
        var dwNewStyle = (dwStyle & ~removeStyle) | addStyle;

        if (dwStyle == dwNewStyle)
            return;

        Win32.SetWindowStyle(window.Handle, dwNewStyle);
    }
}
