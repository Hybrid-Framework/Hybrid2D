using System.Runtime.InteropServices;
using System;

internal static unsafe partial class SDL
{
    // Open Haptic
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Haptic* SDL_OpenHaptic(uint hapticID);
    public static SDL.Haptic* OpenHaptic(uint hapticID)
    {
        return SDL_OpenHaptic(hapticID);
    }
    
    // Close Haptic
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_CloseHaptic(SDL.Haptic* haptic);
    public static void CloseHaptic(SDL.Haptic* haptic)
    {
        SDL_CloseHaptic(haptic);
    }
    
    // Get Haptic Name for ID
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern byte* SDL_GetHapticNameForID(uint gamepadID);
    public static string GetHapticNameForID(uint gamepadID)
    {
        return Utf8ToString(SDL_GetHapticNameForID(gamepadID));
    }
    
    // Get Haptic ID
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern uint SDL_GetHapticID(SDL.Haptic* haptic);
    public static uint GetHapticID(SDL.Haptic* haptic)
    {
        return SDL_GetHapticID(haptic);
    }
    
    // Get Haptic From ID
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Haptic* SDL_GetHapticFromID(uint hapticID);
    public static SDL.Haptic* GetHapticFromID(uint hapticID)
    {
        return SDL_GetHapticFromID(hapticID);
    }
    
    // Is Mouse Haptic
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_IsMouseHaptic();
    public static bool IsMouseHaptic()
    {
        return SDL_IsMouseHaptic();
    }
    
    // Is Joystick Haptic
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_IsJoystickHaptic(SDL.Joystick* joystick);
    public static bool IsJoystickHaptic(SDL.Joystick* joystick)
    {
        return SDL_IsJoystickHaptic(joystick);
    }
    
    // Haptic Rumble Supported
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_HapticRumbleSupported(SDL.Haptic* haptic);
    public static bool HapticRumbleSupported(SDL.Haptic* haptic)
    {
        return SDL_HapticRumbleSupported(haptic);
    }
    
    // Haptic Rumble
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_PlayHapticRumble(SDL.Haptic* haptic, float strength, uint ms);
    public static bool PlayHapticRumble(SDL.Haptic* haptic, float strength, uint ms)
    {
        return SDL_PlayHapticRumble(haptic, Maths.Clamp(strength, 0, 1), ms);
    }
    
    // Get Haptics
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_GetHaptics(out int count);
    public static uint[] GetHaptics(out int count)
    {
        IntPtr ptr = SDL_GetHaptics(out count);

        if (ptr == IntPtr.Zero || count == 0)
            return Array.Empty<uint>();

        uint[] ids = new uint[count];
        Marshal.Copy(ptr, (int[])(object)ids, 0, count);
        SDL_free(ptr);
        return ids;
    }
}