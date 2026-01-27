using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Color32
    {
        public byte r;
        public byte g;
        public byte b;
        public byte a;
    }
}