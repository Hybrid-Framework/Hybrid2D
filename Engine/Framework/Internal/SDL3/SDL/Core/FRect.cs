using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FRect
    {
        public float x;
        public float y;
        public float w;
        public float h;
    }
}