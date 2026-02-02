using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct Texture
    {
        internal SDL.PixelFormat format;
        internal int width;
        internal int height;
        private int refcount;
    }
}