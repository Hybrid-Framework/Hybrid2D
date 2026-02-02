using System.Runtime.InteropServices;

internal static unsafe partial class SDL_mixer
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct StereoGains
    {
        internal float left;
        internal float right;

        internal StereoGains(float left, float right)
        {
            this.left = left;
            this.right = right;
        }
    }
}