using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    // Has Keyboard
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_HasKeyboard();
    public static bool HasKeyboard()
    {
        return SDL_HasKeyboard();
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