using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Texture
    {
        public SDL.PixelFormat format;
        public int w;
        public int h;
        private int refcount;
    }
}