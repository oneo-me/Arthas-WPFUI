using System;
using System.Diagnostics.CodeAnalysis;

namespace Arthas.Shell.Interop;

[Flags]
[SuppressMessage("ReSharper", "InconsistentNaming")]
enum WVR
{
    HREDRAW = 0x0100,
    VREDRAW = 0x0200,
    VALIDRECTS = 0x0400,
    REDRAW = HREDRAW | VREDRAW
}
