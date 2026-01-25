using System.Runtime.InteropServices;
using System;

internal static unsafe partial class SDL
{
    // Get Touch Devices
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_GetTouchDevices(out int count);
    internal static IntPtr GetTouchDevices(out int count)
    {
        return SDL_GetTouchDevices(out count);
    }
    
    // Get Touch Device Name
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern byte* SDL_GetTouchDeviceName(ulong touchDeviceID);
    internal static string GetTouchDeviceName(ulong touchDeviceID)
    {
        return Utf8ToString(SDL_GetTouchDeviceName(touchDeviceID));
    }
    
    // Get Touch Fingers
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_GetTouchFingers(ulong deviceID, out int count);
    internal static IntPtr GetTouchFingers(ulong deviceID, out int count)
    {
        return SDL_GetTouchFingers(deviceID, out count);
    }
}