using System.Runtime.InteropServices;
using System;

internal static unsafe partial class SDL
{
    // Has Mouse
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_HasMouse();
    internal static bool HasMouse()
    {
        return SDL_HasMouse();
    }
    
    // Get Mouse Name For ID
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern byte* SDL_GetMouseNameForID(uint mouseID);
    internal static string GetMouseNameForID(uint mouseID)
    {
        return Utf8ToString(SDL_GetMouseNameForID(mouseID));
    }
    
    // Show Cursor
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_ShowCursor();
    internal static bool ShowCursor()
    {
        return SDL_ShowCursor();
    }
    
    // Hide Cursor
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_HideCursor();
    internal static bool HideCursor()
    {
        return SDL_HideCursor();
    }
    
    // Get Mice
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_GetMice(out int count);
    internal static uint[] GetMice(out int count)
    {
        IntPtr ptr = SDL_GetMice(out count);

        if (ptr == IntPtr.Zero || count == 0)
            return Array.Empty<uint>();

        uint[] ids = new uint[count];
        Marshal.Copy(ptr, (int[])(object)ids, 0, count);
        SDL_free(ptr);
        return ids;
    }
}