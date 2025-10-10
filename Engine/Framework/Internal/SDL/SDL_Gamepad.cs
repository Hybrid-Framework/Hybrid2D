using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    // Gamepad Support
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_HasGamepad();
    public static bool GamepadSupport()
    {
        return SDL_HasGamepad();
    }
    
    // Open Gamepad
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_OpenGamepad(int id);
    public static IntPtr OpenGamepad(int id)
    {
        return SDL_OpenGamepad(id);
    }
    
    // Close Gamepad
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_CloseGamepad(IntPtr gamepad);
    public static void CloseGamepad(IntPtr gamepad)
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
    
    // Get Gamepad ID
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern int SDL_GetGamepadID(IntPtr gamepad);
    public static int GetGamepadID(IntPtr gamepad)
    {
        return SDL_GetGamepadID(gamepad);
    }
    
    // Set Gamepad Player Index
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetGamepadPlayerIndex(IntPtr gamepad, int index);
    public static void SetGamepadPlayerIndex(IntPtr gamepad, int index)
    {
        SDL_SetGamepadPlayerIndex(gamepad, index);
    }
    
    // Get Gamepad Player Index
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern int SDL_GetGamepadPlayerIndex(IntPtr gamepad);
    public static int GetGamepadPlayerIndex(IntPtr gamepad)
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
    
    // Rumble Gamepad
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RumbleGamepad(IntPtr gamepad, ushort low, ushort high, uint duration);
    public static void RumbleGamepad(IntPtr gamepad, ushort low, ushort high, uint duration)
    {
        SDL_RumbleGamepad(gamepad, low, high, duration);
    }
    
    // Rumble Gamepad Triggers
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RumbleGamepadTriggers(IntPtr gamepad, ushort left, ushort right, uint duration);
    public static void RumbleGamepadTriggers(IntPtr gamepad, ushort left, ushort right, uint duration)
    {
        SDL_RumbleGamepadTriggers(gamepad, left, right, duration);
    }
    
    // Get Gamepad Name From ID
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_GetGamepadNameForID(int id);
    public static string GetGamepadNameFromID(int id)
    {
        return Utf8ToString(SDL_GetGamepadNameForID(id));
    }
    
    // Get Gamepads
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern int* SDL_GetGamepads(out int count);
    public static int[] GetGamepadDevices()
    {
        int* ptr = SDL_GetGamepads(out int count);

        if (ptr == null || count == 0)
        {
            return Array.Empty<int>();
        }

        int[] ids = new int[count];

        for (int i = 0; i < count; i++)
        {
            ids[i] = ptr[i];
        }

        SDL.Free((IntPtr)ptr);
        return ids;
    }
}