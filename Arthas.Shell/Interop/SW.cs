using System.Diagnostics.CodeAnalysis;

namespace Arthas.Shell.Interop;

/// <summary>
///     ShowWindow options
/// </summary>
[SuppressMessage("ReSharper", "InconsistentNaming")]
enum SW
{
    SHOWMINIMIZED = 2,
    SHOWMAXIMIZED = 3
}
