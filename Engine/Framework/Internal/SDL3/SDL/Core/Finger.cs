using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Finger
    {
        public ulong id;
        public float x;
        public float y;
        public float pressure;
    }
}