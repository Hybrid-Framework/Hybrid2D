using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    // Gamepad Open
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_OpenGamepad(int id);
    public static IntPtr GamepadOpen(int id)
    {
        return SDL_OpenGamepad(id);
    }
    
    // Gamepad Close
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_CloseGamepad(IntPtr gamepad);
    public static void GamepadClose(IntPtr gamepad)
    {
        SDL_CloseGamepad(gamepad);
    }
    
    // Gamepad Connected
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GamepadConnected(IntPtr gamepad);
    public static bool GamepadConnected(IntPtr gamepad)
    {
        return SDL_GamepadConnected(gamepad);
    }
    
    // Gamepad Get ID
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern int SDL_GetGamepadID(IntPtr gamepad);
    public static int GamepadGetID(IntPtr gamepad)
    {
        return SDL_GetGamepadID(gamepad);
    }
    
    // Gamepad Set Player Index
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetGamepadPlayerIndex(IntPtr gamepad, int index);
    public static void GamepadSetPlayerIndex(IntPtr gamepad, int index)
    {
        SDL_SetGamepadPlayerIndex(gamepad, index);
    }
    
    // Gamepad Get Player Index
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern int SDL_GetGamepadPlayerIndex(IntPtr gamepad);
    public static int GamepadGetPlayerIndex(IntPtr gamepad)
    {
        return SDL_GetGamepadPlayerIndex(gamepad);
    }
    
    // Gamepad Has Axis
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GamepadHasAxis(IntPtr gamepad, SDL.GamepadAxis axis);
    public static bool GamepadHasAxis(IntPtr gamepad, SDL.GamepadAxis axis)
    {
        return SDL_GamepadHasAxis(gamepad, axis);
    }
    
    // Gamepad Has Button
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GamepadHasButton(IntPtr gamepad, SDL.GamepadButton button);
    public static bool GamepadHasButton(IntPtr gamepad, SDL.GamepadButton button)
    {
        return SDL_GamepadHasButton(gamepad, button);
    }
    
    // Gamepad Rumble
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RumbleGamepad(IntPtr gamepad, ushort low, ushort high, uint duration);
    public static void GamepadRumble(IntPtr gamepad, ushort low, ushort high, uint duration)
    {
        SDL_RumbleGamepad(gamepad, low, high, duration);
    }
    
    // Gamepad Rumble Triggers
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RumbleGamepadTriggers(IntPtr gamepad, ushort left, ushort right, uint duration);
    public static void GamepadRumbleTriggers(IntPtr gamepad, ushort left, ushort right, uint duration)
    {
        SDL_RumbleGamepadTriggers(gamepad, left, right, duration);
    }
}