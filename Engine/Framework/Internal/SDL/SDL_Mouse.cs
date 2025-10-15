using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    // Has Mouse
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_HasMouse();
    public static bool HasMouse()
    {
        return SDL_HasMouse();
    }
    
    // Get Mice
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_GetMice(out int count);
    public static IntPtr GetMice(out int count)
    {
        return SDL_GetMice(out count);
    }
    
    // Get Mouse Name For ID
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern byte* SDL_GetMouseNameForID(uint mouseID);
    public static string GetMouseNameForID(uint mouseID)
    {
        return Utf8ToString(SDL_GetMouseNameForID(mouseID));
    }
    
    // Show Cursor
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_ShowCursor();
    public static bool ShowCursor()
    {
        return SDL_ShowCursor();
    }
    
    // Hide Cursor
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_HideCursor();
    public static bool HideCursor()
    {
        return SDL_HideCursor();
    }
}