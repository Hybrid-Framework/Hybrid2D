using System.Runtime.InteropServices;
using System;

internal static unsafe partial class SDL
{
    // Open Joystick
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Joystick* SDL_OpenJoystick(uint joystickID);
    internal static SDL.Joystick* OpenJoystick(uint joystickID)
    {
        return SDL_OpenJoystick(joystickID);
    }
    
    // Close Joystick
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_CloseJoystick(SDL.Joystick* joystick);
    internal static void CloseJoystick(SDL.Joystick* joystick)
    {
        SDL_CloseJoystick(joystick);
    }
    
    // Joystick Connected
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_JoystickConnected(SDL.Joystick* joystick);
    internal static bool JoystickConnected(SDL.Joystick* joystick)
    {
        return SDL_JoystickConnected(joystick);
    }
    
    // Get Gamepad Joystick
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Joystick* SDL_GetGamepadJoystick(SDL.Gamepad* gamepad);
    internal static SDL.Joystick* GetJoystickFromGamepad(SDL.Gamepad* gamepad)
    {
        return SDL_GetGamepadJoystick(gamepad);
    }
    
    // Is Gamepad
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_IsGamepad(uint joystickID);
    internal static bool IsGamepad(uint joystickID)
    {
        return SDL_IsGamepad(joystickID);
    }
    
    // Has Joystick
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_HasJoystick();
    internal static bool HasJoystick()
    {
        return SDL_HasJoystick();
    }
    
    // Get Joystick Name For ID
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern byte* SDL_GetJoystickNameForID(uint joystickID);
    internal static string GetJoystickNameForID(uint joystickID)
    {
        return Utf8ToString(SDL_GetJoystickNameForID(joystickID));
    }
    
    // Get Joystick From ID
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Joystick* SDL_GetJoystickFromID(uint joystickID);
    internal static SDL.Joystick* GetJoystickFromID(uint joystickID)
    {
        return SDL_GetJoystickFromID(joystickID);
    }
    
    // Get Joystick ID
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern uint SDL_GetJoystickID(SDL.Joystick* joystick);
    internal static uint GetJoystickID(SDL.Joystick* joystick)
    {
        return SDL_GetJoystickID(joystick);
    }
    
    // Get Joystick Type
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.JoystickType SDL_GetJoystickType(SDL.Joystick* joystick);
    internal static SDL.JoystickType GetJoystickType(SDL.Joystick* joystick)
    {
        return SDL_GetJoystickType(joystick);
    }
    
    // Set Joystick Events Enabled
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_SetJoystickEventsEnabled(SDL.Bool enabled);
    internal static void SetJoystickEventsEnabled(bool enabled)
    {
        SDL_SetJoystickEventsEnabled(enabled);
    }
    
    // Joystick Events Enabled
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_JoystickEventsEnabled();
    internal static bool JoystickEventsEnabled()
    {
        return SDL_JoystickEventsEnabled();
    }
    
    // Rumble Joystick
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RumbleJoystick(SDL.Joystick* joystick, ushort low, ushort high, uint ms);
    internal static bool RumbleJoystick(SDL.Joystick* joystick, ushort low, ushort high, uint ms)
    {
        return SDL_RumbleJoystick(joystick, low, high, ms);
    }
    
    // Rumble Joystick Triggers
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RumbleJoystickTriggers(SDL.Joystick* joystick, ushort left, ushort right, uint ms);
    internal static bool RumbleJoystickTriggers(SDL.Joystick* joystick, ushort left, ushort right, uint ms)
    {
        return SDL_RumbleJoystickTriggers(joystick, left, right, ms);
    }
    
    // Get Joysticks
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_GetJoysticks(out int count);
    internal static uint[] GetJoysticks(out int count)
    {
        IntPtr ptr = SDL_GetJoysticks(out count);

        if (ptr == IntPtr.Zero || count == 0)
            return Array.Empty<uint>();

        uint[] ids = new uint[count];
        Marshal.Copy(ptr, (int[])(object)ids, 0, count);
        SDL_free(ptr);
        return ids;
    }
}