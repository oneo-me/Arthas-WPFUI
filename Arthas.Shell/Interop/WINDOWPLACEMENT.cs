using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace Arthas.Shell.Interop;

[Serializable]
[StructLayout(LayoutKind.Sequential)]
[SuppressMessage("ReSharper", "InconsistentNaming")]
class WINDOWPLACEMENT
{
    public int length = Marshal.SizeOf(typeof(WINDOWPLACEMENT));
    public int flags;
    public SW showCmd;
    public POINT minPosition;
    public POINT maxPosition;
    public RECT normalPosition;
}
