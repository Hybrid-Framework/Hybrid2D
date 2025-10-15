using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    public struct CommonEvent
    {
        public uint type;
        public uint reserved;
        public ulong timestamp;
    }
}