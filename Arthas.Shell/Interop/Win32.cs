using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Arthas.Shell.Interop;

static class Win32
{
    [DllImport("dwmapi.dll", EntryPoint = "DwmIsCompositionEnabled", PreserveSig = false)]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool _DwmIsCompositionEnabled();

    static readonly bool _isOsVistaOrNewer = new Version(6, 0) <= Environment.OSVersion.Version;

    public static bool DwmIsCompositionEnabled()
    {
        return _isOsVistaOrNewer && _DwmIsCompositionEnabled();
    }

    public static WS GetWindowStyle(IntPtr hWnd)
    {
        return (WS)GetWindowLongPtr(hWnd, GWL.STYLE);
    }

    public static WS SetWindowStyle(IntPtr hWnd, WS dwNewLong)
    {
        return (WS)SetWindowLongPtr(hWnd, GWL.STYLE, (IntPtr)dwNewLong);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static IntPtr GetWindowLongPtr(IntPtr hwnd, GWL nIndex)
    {
        var ret = IntPtr.Size == 8
            ? GetWindowLongPtr64(hwnd, nIndex)
            : GetWindowLongPtr32(hwnd, nIndex);

        if (ret == IntPtr.Zero)
            throw new Win32Exception();

        return ret;
    }

    [DllImport("user32.dll", EntryPoint = "GetWindowLong", SetLastError = true)]
    static extern IntPtr GetWindowLongPtr32(IntPtr hWnd, GWL nIndex);

    [DllImport("user32.dll", EntryPoint = "GetWindowLongPtr", SetLastError = true)]
    static extern IntPtr GetWindowLongPtr64(IntPtr hWnd, GWL nIndex);

    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool GetWindowPlacement(IntPtr hwnd, [In] [Out] WINDOWPLACEMENT lpwndpl);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static WINDOWPLACEMENT GetWindowPlacement(IntPtr hwnd)
    {
        WINDOWPLACEMENT wndpl = new();

        if (GetWindowPlacement(hwnd, wndpl))
            return wndpl;

        throw new Win32Exception();
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static IntPtr SetWindowLongPtr(IntPtr hwnd, GWL nIndex, IntPtr dwNewLong)
    {
        if (IntPtr.Size == 8)
            return SetWindowLongPtr64(hwnd, nIndex, dwNewLong);

        return new(SetWindowLongPtr32(hwnd, nIndex, dwNewLong.ToInt32()));
    }

    [DllImport("user32.dll", EntryPoint = "SetWindowLong", SetLastError = true)]
    static extern int SetWindowLongPtr32(IntPtr hWnd, GWL nIndex, int dwNewLong);

    [DllImport("user32.dll", EntryPoint = "SetWindowLongPtr", SetLastError = true)]
    static extern IntPtr SetWindowLongPtr64(IntPtr hWnd, GWL nIndex, IntPtr dwNewLong);

    [DllImport("user32.dll", EntryPoint = "SetWindowPos", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool _SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, SWP uFlags);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, SWP uFlags)
    {
        if (!_SetWindowPos(hWnd, hWndInsertAfter, x, y, cx, cy, uFlags))
            throw new Win32Exception();
    }

    [DllImport("user32.dll", SetLastError = true)]
    public static extern IntPtr SendMessage(IntPtr hWnd, WM msg, IntPtr wParam, IntPtr lParam);
}
