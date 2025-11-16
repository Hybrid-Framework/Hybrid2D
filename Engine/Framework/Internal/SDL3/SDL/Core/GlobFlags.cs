using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    [Flags]
    public enum GlobFlags : uint
    {
        CaseSensitive = 0,
        CaseInsensitive = 0x1,
    }
}