using System.Runtime.InteropServices;

public static unsafe partial class SDL
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
    private static extern SDL.Bool SDL_GamepadConnected(IntPtr gamepad);
    public static bool GamepadConnected(IntPtr gamepad)
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
    private static extern SDL.GamepadType SDL_GetGamepadType(IntPtr gamepad);
    public static SDL.GamepadType GetGamepadType(IntPtr gamepad)
    {
        return SDL_GetGamepadType(gamepad);
    }
    
    // Get Gamepad From ID
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_GetGamepadFromID(uint gamepadID);
    public static IntPtr GetGamepadFromID(uint gamepadID)
    {
        return SDL_GetGamepadFromID(gamepadID);
    }
    
    // Get Gamepad ID
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern uint SDL_GetGamepadID(IntPtr gamepad);
    public static uint GetGamepadID(IntPtr gamepad)
    {
        return SDL_GetGamepadID(gamepad);
    }
    
    // Get Gamepad From Player Index
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_GetGamepadFromPlayerIndex(int player);
    public static IntPtr GetGamepadFromPlayerIndex(int player)
    {
        return SDL_GetGamepadFromPlayerIndex(player);
    }
    
    // Get Gamepad Player Index
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern int SDL_GetGamepadPlayerIndex(IntPtr gamepad);
    public static int GetGamepadPlayerIndex(IntPtr gamepad)
    {
        return SDL_GetGamepadPlayerIndex(gamepad);
    }
    
    // Set Gamepad Player Index
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetGamepadPlayerIndex(IntPtr gamepad, int player);
    public static bool SetGamepadPlayerIndex(IntPtr gamepad, int player)
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
    private static extern SDL.Bool SDL_GamepadHasButton(IntPtr gamepad, SDL.GamepadButton button);
    public static bool GamepadHasButton(IntPtr gamepad, SDL.GamepadButton button)
    {
        return SDL_GamepadHasButton(gamepad, button);
    }
    
    // Gamepad Has Axis
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GamepadHasAxis(IntPtr gamepad, SDL.GamepadAxis axis);
    public static bool GamepadHasAxis(IntPtr gamepad, SDL.GamepadAxis axis)
    {
        return SDL_GamepadHasAxis(gamepad, axis);
    }
    
    // Rumble Gamepad
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RumbleGamepad(IntPtr gamepad, ushort low, ushort high, uint ms);
    public static bool RumbleGamepad(IntPtr gamepad, ushort low, ushort high, uint ms)
    {
        return SDL_RumbleGamepad(gamepad, low, high, ms);
    }
    
    // Open Gamepad
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_OpenGamepad(uint gamepadID);
    public static IntPtr OpenGamepad(uint gamepadID)
    {
        return SDL_OpenGamepad(gamepadID);
    }
    
    // Close Gamepad
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_CloseGamepad(IntPtr gamepad);
    public static void CloseGamepad(IntPtr gamepad)
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