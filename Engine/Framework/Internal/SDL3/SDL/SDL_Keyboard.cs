using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    // Has Keyboard
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_HasKeyboard();
    public static bool HasKeyboard()
    {
        return SDL_HasKeyboard();
    }
    
    // Get Keyboards
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_GetKeyboards(out int count);
    public static IntPtr GetKeyboards(out int count)
    {
        return SDL_GetKeyboards(out count);
    }
    
    // Get Keyboard Name for ID
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern byte* SDL_GetKeyboardNameForID(uint keyboardID);
    public static string GetKeyboardNameForID(uint keyboardID)
    {
        return Utf8ToString(SDL_GetKeyboardNameForID(keyboardID));
    }
    
    // Get Mod State
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.KeyModifier SDL_GetModState();
    public static SDL.KeyModifier GetModState()
    {
        return SDL_GetModState();
    }
    
    // Set Mod State
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_SetModState(SDL.KeyModifier keyModifier);
    public static void SetModState(SDL.KeyModifier keyModifier)
    {
        SDL_SetModState(keyModifier);
    }
    
    // Get Key Name
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern byte* SDL_GetKeyName(SDL.KeyCode keyCode);
    public static string GetKeyName(SDL.KeyCode keyCode)
    {
        return Utf8ToString(SDL_GetKeyName(keyCode));
    }
    
    // Get Key From Name
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.KeyCode SDL_GetKeyFromName(byte* name);
    public static SDL.KeyCode GetKeyFromName(string name)
    {
        var bytes = StringToUtf8(name);

        fixed (byte* utf8 = bytes)
        {
            return SDL_GetKeyFromName(utf8);
        }
    }
}