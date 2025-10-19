using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Texture
    {
        public SDL.PixelFormat format;
        public int width;
        public int height;
        private int refcount;
    }
}