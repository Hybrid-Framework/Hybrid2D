using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Color
    {
        public byte r;
        public byte g;
        public byte b;
        public byte a;
    }
}