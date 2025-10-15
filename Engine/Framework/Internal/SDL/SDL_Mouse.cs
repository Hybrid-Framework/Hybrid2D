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