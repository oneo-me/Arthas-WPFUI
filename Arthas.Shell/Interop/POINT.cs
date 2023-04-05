using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace Arthas.Shell.Interop;

[Serializable]
[StructLayout(LayoutKind.Sequential)]
[SuppressMessage("ReSharper", "InconsistentNaming")]
struct POINT
{
    public int X { get; set; }
    public int Y { get; set; }
}
