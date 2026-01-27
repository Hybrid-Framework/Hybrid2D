using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    // Set Hint
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetHint(byte* name, byte* value);
    public static bool SetHint(string name, string value)
    {
        var nameBytes = StringToUtf8(name);
        var valueBytes = StringToUtf8(value);

        fixed (byte* utf8Name = nameBytes)
        fixed (byte* utf8Value = valueBytes)
        {
            return SDL_SetHint(utf8Name, utf8Value);
        }
    }
    
    // Get hint
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern byte* SDL_GetHint(byte* name);
    public static string GetHint(string name)
    {
        var bytes = StringToUtf8(name);

        fixed (byte* utf8 = bytes)
        {
            return Utf8ToString(SDL_GetHint(utf8));
        }
    }
    
    // Reset Hint
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_ResetHint(byte* name);
    public static bool ResetHint(string name)
    {
        var bytes = StringToUtf8(name);

        fixed (byte* utf8 = bytes)
        {
            return SDL_ResetHint(utf8);
        }
    }
    
    // Reset Hints
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_ResetHints();
    public static void ResetHints()
    {
        SDL_ResetHints();
    }
}