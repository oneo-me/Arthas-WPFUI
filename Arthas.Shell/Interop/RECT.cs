using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace Arthas.Shell.Interop;

[StructLayout(LayoutKind.Sequential, Pack = 0)]
[Serializable]
[SuppressMessage("ReSharper", "InconsistentNaming")]
struct RECT
{
    public int Left { get; set; }

    public int Top { get; set; }

    public int Right { get; set; }

    public int Bottom { get; set; }

    public int Width => Right - Left;

    public int Height => Bottom - Top;

    public void Offset(int dx, int dy)
    {
        Left += dx;
        Top += dy;
        Right += dx;
        Bottom += dy;
    }
}
