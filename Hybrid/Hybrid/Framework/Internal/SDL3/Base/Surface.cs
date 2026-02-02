using System.Runtime.InteropServices;
using System;

internal static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct Surface
    {
        internal SDL.SurfaceFlags flags;
        internal SDL.PixelFormat format;
        internal int width;
        internal int height;
        internal int pitch;
        internal IntPtr pixels;
        private int refcount;
        private IntPtr reserved;
    }
}