using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    // Get Touch Fingers
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_GetTouchFingers(ulong deviceID, out int count);
    public static IntPtr GetTouchFingers(ulong deviceID, out int count)
    {
        return SDL_GetTouchFingers(deviceID, out count);
    }
}