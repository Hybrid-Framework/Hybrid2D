using System.Runtime.InteropServices;

public static unsafe partial class SDL_mixer
{
    [StructLayout(LayoutKind.Sequential)]
    public struct StereoPosition
    {
        public float x;
        public float y;
        public float z;
    }
}