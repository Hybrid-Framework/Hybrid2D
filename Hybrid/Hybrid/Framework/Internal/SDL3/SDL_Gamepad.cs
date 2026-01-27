using System.Runtime.InteropServices;
using System;

internal static unsafe partial class SDL
{
    // Has Gamepad
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_HasGamepad();
    internal static bool HasGamepad()
    {
        return SDL_HasGamepad();
    }
    
    // Get Gamepad Name for ID
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern byte* SDL_GetGamepadNameForID(uint gamepadID);
    internal static string GetGamepadNameForID(uint gamepadID)
    {
        return Utf8ToString(SDL_GetGamepadNameForID(gamepadID));
    }
    
    // Gamepad Connected
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GamepadConnected(SDL.Gamepad* gamepad);
    internal static bool GamepadConnected(SDL.Gamepad* gamepad)
    {
        return SDL_GamepadConnected(gamepad);
    }
    
    // Get Gamepad Type For ID
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.GamepadType SDL_GetGamepadTypeForID(uint gamepadID);
    internal static SDL.GamepadType GetGamepadTypeForID(uint gamepadID)
    {
        return SDL_GetGamepadTypeForID(gamepadID);
    }
    
    // Get Gamepad Type
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.GamepadType SDL_GetGamepadType(SDL.Gamepad* gamepad);
    internal static SDL.GamepadType GetGamepadType(SDL.Gamepad* gamepad)
    {
        return SDL_GetGamepadType(gamepad);
    }
    
    // Get Gamepad From ID
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Gamepad* SDL_GetGamepadFromID(uint gamepadID);
    internal static SDL.Gamepad* GetGamepadFromID(uint gamepadID)
    {
        return SDL_GetGamepadFromID(gamepadID);
    }
    
    // Get Gamepad ID
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern uint SDL_GetGamepadID(SDL.Gamepad* gamepad);
    internal static uint GetGamepadID(SDL.Gamepad* gamepad)
    {
        return SDL_GetGamepadID(gamepad);
    }
    
    // Set Gamepad Events Enabled
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_SetGamepadEventsEnabled(SDL.Bool enabled);
    internal static void SetGamepadEventsEnabled(bool enabled)
    {
        SDL_SetGamepadEventsEnabled(enabled);
    }
    
    // Gamepad Events Enabled
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GamepadEventsEnabled();
    internal static bool GamepadEventsEnabled()
    {
        return SDL_GamepadEventsEnabled();
    }
    
    // Rumble Gamepad
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RumbleGamepad(SDL.Gamepad* gamepad, ushort low, ushort high, uint ms);
    internal static bool RumbleGamepad(SDL.Gamepad* gamepad, ushort low, ushort high, uint ms)
    {
        return SDL_RumbleGamepad(gamepad, low, high, ms);
    }
    
    // Rumble Gamepad Triggers
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RumbleGamepadTriggers(SDL.Gamepad* gamepad, ushort left, ushort right, uint ms);
    internal static bool RumbleGamepadTriggers(SDL.Gamepad* gamepad, ushort left, ushort right, uint ms)
    {
        return SDL_RumbleGamepadTriggers(gamepad, left, right, ms);
    }
    
    // Open Gamepad
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Gamepad* SDL_OpenGamepad(uint gamepadID);
    internal static SDL.Gamepad* OpenGamepad(uint gamepadID)
    {
        return SDL_OpenGamepad(gamepadID);
    }
    
    // Close Gamepad
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_CloseGamepad(SDL.Gamepad* gamepad);
    internal static void CloseGamepad(SDL.Gamepad* gamepad)
    {
        SDL_CloseGamepad(gamepad);
    }
    
    // Gamepad Has Axis
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GamepadHasAxis(SDL.Gamepad* gamepad, SDL.GamepadAxis axis);
    internal static bool GamepadHasAxis(SDL.Gamepad* gamepad, SDL.GamepadAxis axis)
    {
        return SDL_GamepadHasAxis(gamepad, axis);
    }
    
    // Gamepad Has Button
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GamepadHasButton(SDL.Gamepad* gamepad, SDL.GamepadButton button);
    internal static bool GamepadHasButton(SDL.Gamepad* gamepad, SDL.GamepadButton button)
    {
        return SDL_GamepadHasButton(gamepad, button);
    }
    
    // Get Gamepad Player Index For ID
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern int SDL_GetGamepadPlayerIndexForID(uint gamepadID);
    internal static int GetGamepadPlayerIndexForID(uint gamepadID)
    {
        return SDL_GetGamepadPlayerIndexForID(gamepadID);
    }
    
    // Get Gamepad Player Index
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern int SDL_GetGamepadPlayerIndex(SDL.Gamepad* gamepad);
    internal static int GetGamepadPlayerIndex(SDL.Gamepad* gamepad)
    {
        return SDL_GetGamepadPlayerIndex(gamepad);
    }
    
    // Get Gamepads
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_GetGamepads(out int count);
    internal static uint[] GetGamepads(out int count)
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