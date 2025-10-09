using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    public struct UserEvent
    {
        public uint type;
        public uint reserved;
        public ulong timestamp;
        public uint windowID;
        public int code;
        public IntPtr data1;
        public IntPtr data2;
    }
}