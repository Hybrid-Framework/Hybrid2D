using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FPoint
    {
        public float x;
        public float y;
    }
}