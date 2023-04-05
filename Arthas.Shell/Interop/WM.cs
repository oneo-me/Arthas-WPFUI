using System.Diagnostics.CodeAnalysis;

namespace Arthas.Shell.Interop;

/// <summary>
///     Window message values, WM_*
/// </summary>
[SuppressMessage("ReSharper", "InconsistentNaming")]
enum WM
{
    NCCALCSIZE = 0x0083,
    NCPAINT = 0x0085,
    NCLBUTTONDOWN = 0x00A1,
    DPICHANGED = 0x02E0
}
