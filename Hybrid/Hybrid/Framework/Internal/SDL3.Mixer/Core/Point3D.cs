using System.Runtime.InteropServices;

internal static unsafe partial class SDL_mixer
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct Point3D
    {
        internal float x;
        internal float y;
        internal float z;
    }
}