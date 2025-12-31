using System.Runtime.InteropServices;
using System;

internal static unsafe partial class SDL
{
    // Has Gamepad
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_HasGamepad();
    public static bool HasGamepad()
    {
        return SDL_HasGamepad();
    }
    
    // Get Gamepad Name for ID
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern byte* SDL_GetGamepadNameForID(uint gamepadID);
    public static string GetGamepadNameForID(uint gamepadID)
    {
        return Utf8ToString(SDL_GetGamepadNameForID(gamepadID));
    }
    
    // Gamepad Connected
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GamepadConnected(SDL.Gamepad* gamepad);
    public static bool GamepadConnected(SDL.Gamepad* gamepad)
    {
        return SDL_GamepadConnected(gamepad);
    }
    
    // Get Gamepad Type For ID
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.GamepadType SDL_GetGamepadTypeForID(uint gamepadID);
    public static SDL.GamepadType GetGamepadTypeForID(uint gamepadID)
    {
        return SDL_GetGamepadTypeForID(gamepadID);
    }
    
    // Get Gamepad Type
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.GamepadType SDL_GetGamepadType(SDL.Gamepad* gamepad);
    public static SDL.GamepadType GetGamepadType(SDL.Gamepad* gamepad)
    {
        return SDL_GetGamepadType(gamepad);
    }
    
    // Get Gamepad From ID
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Gamepad* SDL_GetGamepadFromID(uint gamepadID);
    public static SDL.Gamepad* GetGamepadFromID(uint gamepadID)
    {
        return SDL_GetGamepadFromID(gamepadID);
    }
    
    // Get Gamepad ID
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern uint SDL_GetGamepadID(SDL.Gamepad* gamepad);
    public static uint GetGamepadID(SDL.Gamepad* gamepad)
    {
        return SDL_GetGamepadID(gamepad);
    }
    
    // Set Gamepad Events Enabled
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_SetGamepadEventsEnabled(SDL.Bool enabled);
    public static void SetGamepadEventsEnabled(bool enabled)
    {
        SDL_SetGamepadEventsEnabled(enabled);
    }
    
    // Gamepad Events Enabled
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GamepadEventsEnabled();
    public static bool GamepadEventsEnabled()
    {
        return SDL_GamepadEventsEnabled();
    }
    
    // Rumble Gamepad
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RumbleGamepad(SDL.Gamepad* gamepad, ushort low, ushort high, uint ms);
    public static bool RumbleGamepad(SDL.Gamepad* gamepad, ushort low, ushort high, uint ms)
    {
        return SDL_RumbleGamepad(gamepad, low, high, ms);
    }
    
    // Rumble Gamepad Triggers
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RumbleGamepadTriggers(SDL.Gamepad* gamepad, ushort left, ushort right, uint ms);
    public static bool RumbleGamepadTriggers(SDL.Gamepad* gamepad, ushort left, ushort right, uint ms)
    {
        return SDL_RumbleGamepadTriggers(gamepad, left, right, ms);
    }
    
    // Open Gamepad
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Gamepad* SDL_OpenGamepad(uint gamepadID);
    public static SDL.Gamepad* OpenGamepad(uint gamepadID)
    {
        return SDL_OpenGamepad(gamepadID);
    }
    
    // Close Gamepad
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_CloseGamepad(SDL.Gamepad* gamepad);
    public static void CloseGamepad(SDL.Gamepad* gamepad)
    {
        SDL_CloseGamepad(gamepad);
    }
    
    // Get Gamepads
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_GetGamepads(out int count);
    public static uint[] GetGamepads(out int count)
    {
        IntPtr ptr = SDL_GetGamepads(out count);

        if (ptr == IntPtr.Zero || count == 0)
            return Array.Empty<uint>();

        uint[] ids = new uint[count];
        Marshal.Copy(ptr, (int[])(object)ids, 0, count);
        SDL_free(ptr);
        return ids;
    }
}