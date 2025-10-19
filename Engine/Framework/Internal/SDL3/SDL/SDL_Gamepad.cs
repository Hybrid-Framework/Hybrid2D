using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    // Has Gamepad
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_HasGamepad();
    public static bool HasGamepad()
    {
        return SDL_HasGamepad();
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
    
    // Get Gamepad From Player Index
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Gamepad* SDL_GetGamepadFromPlayerIndex(int player);
    public static SDL.Gamepad* GetGamepadFromPlayerIndex(int player)
    {
        return SDL_GetGamepadFromPlayerIndex(player);
    }
    
    // Get Gamepad Player Index
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern int SDL_GetGamepadPlayerIndex(SDL.Gamepad* gamepad);
    public static int GetGamepadPlayerIndex(SDL.Gamepad* gamepad)
    {
        return SDL_GetGamepadPlayerIndex(gamepad);
    }
    
    // Set Gamepad Player Index
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetGamepadPlayerIndex(SDL.Gamepad* gamepad, int player);
    public static bool SetGamepadPlayerIndex(SDL.Gamepad* gamepad, int player)
    {
        return SDL_SetGamepadPlayerIndex(gamepad, player);
    }
    
    // Set Gamepad Events Enabled
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_SetGamepadEventsEnabled(SDL.Bool enabled);
    public static void SetGamepadEventsEnabled(bool enabled)
    {
        SDL_SetGamepadEventsEnabled(enabled);
    }
    
    // Gamepad Has Button
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GamepadHasButton(SDL.Gamepad* gamepad, SDL.GamepadButton button);
    public static bool GamepadHasButton(SDL.Gamepad* gamepad, SDL.GamepadButton button)
    {
        return SDL_GamepadHasButton(gamepad, button);
    }
    
    // Gamepad Has Axis
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GamepadHasAxis(SDL.Gamepad* gamepad, SDL.GamepadAxis axis);
    public static bool GamepadHasAxis(SDL.Gamepad* gamepad, SDL.GamepadAxis axis)
    {
        return SDL_GamepadHasAxis(gamepad, axis);
    }
    
    // Rumble Gamepad
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RumbleGamepad(SDL.Gamepad* gamepad, ushort low, ushort high, uint ms);
    public static bool RumbleGamepad(SDL.Gamepad* gamepad, ushort low, ushort high, uint ms)
    {
        return SDL_RumbleGamepad(gamepad, low, high, ms);
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
    public static IntPtr GetGamepads(out int count)
    {
        return SDL_GetGamepads(out count);
    }
}