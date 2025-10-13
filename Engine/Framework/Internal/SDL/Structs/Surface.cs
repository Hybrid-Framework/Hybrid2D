using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Surface
    {
        public SDL.SurfaceFlags flags;
        public SDL.PixelFormat format;
        public int w;
        public int h;
        public int pitch;
        public byte* pixels;
        private int refcount;
        private IntPtr reserved;
    }
}