using System.Runtime.InteropServices;
using System;

internal static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Surface
    {
        public SDL.SurfaceFlags flags;
        public SDL.PixelFormat format;
        public int width;
        public int height;
        public int pitch;
        public IntPtr pixels;
        private int refcount;
        private IntPtr reserved;
    }
}