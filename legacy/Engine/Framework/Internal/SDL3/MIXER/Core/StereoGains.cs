using System.Runtime.InteropServices;

internal static unsafe partial class SDL_mixer
{
    [StructLayout(LayoutKind.Sequential)]
    public struct StereoGains
    {
        public float left;
        public float right;
    }
}