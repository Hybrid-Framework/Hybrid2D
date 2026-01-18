using System.Runtime.InteropServices;
using System;

internal static unsafe partial class SDL
{
    // Has Keyboard
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_HasKeyboard();
    internal static bool HasKeyboard()
    {
        return SDL_HasKeyboard();
    }
    
    // Get Keyboard Name for ID
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern byte* SDL_GetKeyboardNameForID(uint keyboardID);
    internal static string GetKeyboardNameForID(uint keyboardID)
    {
        return Utf8ToString(SDL_GetKeyboardNameForID(keyboardID));
    }
    
    // Get Mod State
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.KeyModifier SDL_GetModState();
    internal static SDL.KeyModifier GetModState()
    {
        return SDL_GetModState();
    }
    
    // Set Mod State
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_SetModState(SDL.KeyModifier keyModifier);
    internal static void SetModState(SDL.KeyModifier keyModifier)
    {
        SDL_SetModState(keyModifier);
    }
    
    // Get Key Name
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern byte* SDL_GetKeyName(SDL.KeyCode keyCode);
    internal static string GetKeyName(SDL.KeyCode keyCode)
    {
        return Utf8ToString(SDL_GetKeyName(keyCode));
    }
    
    // Get Key From Name
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.KeyCode SDL_GetKeyFromName(byte* name);
    internal static SDL.KeyCode GetKeyFromName(string name)
    {
        var bytes = StringToUtf8(name);

        fixed (byte* utf8 = bytes)
        {
            return SDL_GetKeyFromName(utf8);
        }
    }
    
    // Get Keyboards
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_GetKeyboards(out int count);
    internal static uint[] GetKeyboards(out int count)
    {
        IntPtr ptr = SDL_GetKeyboards(out count);

        if (ptr == IntPtr.Zero || count == 0)
            return Array.Empty<uint>();

        uint[] ids = new uint[count];
        Marshal.Copy(ptr, (int[])(object)ids, 0, count);
        SDL_free(ptr);
        return ids;
    }
}