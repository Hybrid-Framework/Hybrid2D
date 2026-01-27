using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Color
    {
        public float r;
        public float g;
        public float b;
        public float a;
    }
}