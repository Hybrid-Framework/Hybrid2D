using System.Runtime.InteropServices;

public static unsafe partial class SDL_mixer
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Point3D
    {
        public float x;
        public float y;
        public float z;
    }
}