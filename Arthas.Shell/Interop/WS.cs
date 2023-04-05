using System;
using System.Diagnostics.CodeAnalysis;

namespace Arthas.Shell.Interop;

/// <summary>
///     WindowStyle values, WS_*
/// </summary>
[Flags]
[SuppressMessage("ReSharper", "InconsistentNaming")]
enum WS : uint
{
    CHILD = 0x40000000,
    CLIPCHILDREN = 0x02000000,
    BORDER = 0x00800000,
    DLGFRAME = 0x00400000,
    CAPTION = BORDER | DLGFRAME
}
