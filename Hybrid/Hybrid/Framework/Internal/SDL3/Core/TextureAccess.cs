using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    internal enum TextureAccess
    {
        Static = 0,
        Streaming = 1,
        Target = 2,
    }
}