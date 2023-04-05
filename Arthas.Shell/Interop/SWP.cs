using System;
using System.Diagnostics.CodeAnalysis;

namespace Arthas.Shell.Interop;

/// <summary>
///     SetWindowPos options
/// </summary>
[Flags]
[SuppressMessage("ReSharper", "InconsistentNaming")]
enum SWP : uint
{
    /// <summary>
    ///     Applies new frame styles set using the SetWindowLong function. Sends a WM_NCCALCSIZE message to the window, even if
    ///     the
    ///     window's size is not being changed. If this flag is not specified, WM_NCCALCSIZE is sent only when the window's
    ///     size is
    ///     being changed.
    /// </summary>
    FRAMECHANGED = 0x0020,

    /// <summary>
    ///     Does not activate the window. If this flag is not set, the window is activated and moved to the top of either the
    ///     topmost or non-topmost group (depending on the setting of the hWndInsertAfter parameter).
    /// </summary>
    NOACTIVATE = 0x0010,

    /// <summary>
    ///     Retains the current position (ignores X and Y parameters).
    /// </summary>
    NOMOVE = 0x0002,

    /// <summary>
    ///     Does not change the owner window's position in the Z order.
    /// </summary>
    NOOWNERZORDER = 0x0200,

    /// <summary>
    ///     Retains the current size (ignores the cx and cy parameters).
    /// </summary>
    NOSIZE = 0x0001,

    /// <summary>
    ///     Retains the current Z order (ignores the hWndInsertAfter parameter).
    /// </summary>
    NOZORDER = 0x0004,

    /// <summary>
    ///     Displays the window.
    /// </summary>
    SHOWWINDOW = 0x0040
}
