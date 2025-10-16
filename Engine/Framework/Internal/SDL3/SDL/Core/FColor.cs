using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    [StructLayout(LayoutKind.Sequential)]
    public struct FColor
    {
        public float r;
        public float g;
        public float b;
        public float a;
    }
}