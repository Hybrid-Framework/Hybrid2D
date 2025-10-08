using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Point
    {
        public int x;
        public int y;
    }
}