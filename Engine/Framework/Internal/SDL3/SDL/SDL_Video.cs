using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    // Create Window
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_CreateWindow(byte* title, int w, int h, ulong flags);
    public static IntPtr CreateWindow(string title, int w, int h, SDL.WindowFlags flags)
    {
        var bytes = StringToUtf8(title);

        fixed (byte* utf8 = bytes)
        {
            return SDL_CreateWindow(utf8, w, h, (ulong)flags);
        }
    }
    
    // Destroy Window
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_DestroyWindow(IntPtr window);
    public static void DestroyWindow(IntPtr window)
    {
        SDL_DestroyWindow(window);
    }
    
    // Set Window Title
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetWindowTitle(IntPtr window, byte* title);
    public static bool SetWindowTitle(IntPtr window, string title)
    {
        var bytes = StringToUtf8(title);

        fixed (byte* utf8 = bytes)
        {
            return SDL_SetWindowTitle(window, utf8);
        }
    }
    
    // Get Window Title
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern byte* SDL_GetWindowTitle(IntPtr window);
    public static string GetWindowTitle(IntPtr window)
    {
        return Utf8ToString(SDL_GetWindowTitle(window));
    }
    
    // Set Window Position
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetWindowPosition(IntPtr window, int x, int y);
    public static bool SetWindowPosition(IntPtr window, int x, int y)
    {
        return SDL_SetWindowPosition(window, x, y);
    }
    
    // Get Window Position
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetWindowPosition(IntPtr window, out int x, out int y);
    public static bool GetWindowPosition(IntPtr window, out int x, out int y)
    {
        return SDL_GetWindowPosition(window, out x, out y);
    }
    
    // Set Window Size
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetWindowSize(IntPtr window, int w, int h);
    public static bool SetWindowSize(IntPtr window, int w, int h)
    {
        return SDL_SetWindowSize(window, w, h);
    }
    
    // Get Window Size
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetWindowSize(IntPtr window, out int w, out int h);
    public static bool GetWindowSize(IntPtr window, out int w, out int h)
    {
        return SDL_GetWindowSize(window, out w, out h);
    }
    
    // Set Window Minimum Size
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetWindowMinimumSize(IntPtr window, int w, int h);
    public static bool SetWindowMinimumSize(IntPtr window, int w, int h)
    {
        return SDL_SetWindowMinimumSize(window, w, h);
    }
    
    // Get Window Minimum Size
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetWindowMinimumSize(IntPtr window, out int w, out int h);
    public static bool GetWindowMinimumSize(IntPtr window, out int w, out int h)
    {
        return SDL_GetWindowMinimumSize(window, out w, out h);
    }
    
    // Set Window Maximum Size
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetWindowMaximumSize(IntPtr window, int w, int h);
    public static bool SetWindowMaximumSize(IntPtr window, int w, int h)
    {
        return SDL_SetWindowMaximumSize(window, w, h);
    }
    
    // Get Window Maximum Size
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetWindowMaximumSize(IntPtr window, out int w, out int h);
    public static bool GetWindowMaximumSize(IntPtr window, out int w, out int h)
    {
        return SDL_GetWindowMaximumSize(window, out w, out h);
    }
    
    // Set Window Aspect Ratio
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetWindowAspectRatio(IntPtr window, float min, float max);
    public static bool SetWindowAspectRatio(IntPtr window, float min, float max)
    {
        return SDL_SetWindowAspectRatio(window, min, max);
    }
    
    // Get Window Aspect Ratio
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetWindowAspectRatio(IntPtr window, out float min, out float max);
    public static bool GetWindowAspectRatio(IntPtr window, out float min, out float max)
    {
        return SDL_GetWindowAspectRatio(window, out min, out max);
    }
    
    // Set Window Bordered
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetWindowBordered(IntPtr window, SDL.Bool bordered);
    public static bool SetWindowBordered(IntPtr window, bool bordered)
    {
        return SDL_SetWindowBordered(window, bordered);
    }
    
    // Set Window Resizable
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetWindowResizable(IntPtr window, SDL.Bool resizable);
    public static bool SetWindowResizable(IntPtr window, bool resizable)
    {
        return SDL_SetWindowResizable(window, resizable);
    }
    
    // Set Window Fullscreen
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetWindowFullscreen(IntPtr window, SDL.Bool fullscreen);
    public static bool SetWindowFullscreen(IntPtr window, bool fullscreen)
    {
        return SDL_SetWindowFullscreen(window, fullscreen);
    }
    
    // Show Window
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_ShowWindow(IntPtr window);
    public static bool ShowWindow(IntPtr window)
    {
        return SDL_ShowWindow(window);
    }
    
    // Hide Window
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_HideWindow(IntPtr window);
    public static bool HideWindow(IntPtr window)
    {
        return SDL_HideWindow(window);
    }
    
    // Set Window Icon
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetWindowIcon(IntPtr window, IntPtr surface);
    public static bool SetWindowIcon(IntPtr window, IntPtr surface)
    {
        return SDL_SetWindowIcon(window, surface);
    }
    
    // Get Window Safe Area
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetWindowSafeArea(IntPtr window, out SDL.Rect rect);
    public static bool GetWindowSafeArea(IntPtr window, out SDL.Rect rect)
    {
        return SDL_GetWindowSafeArea(window, out rect);
    }
    
    // Get Primary Display
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern uint SDL_GetPrimaryDisplay();
    public static uint GetPrimaryDisplay()
    {
        return SDL_GetPrimaryDisplay();
    }
    
    // Get Display For Window
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern uint SDL_GetDisplayForWindow(IntPtr window);
    public static uint GetDisplayForWindow(IntPtr window)
    {
        return SDL_GetDisplayForWindow(window);
    }
    
    // Get Natural Display Orientation
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Orientation SDL_GetNaturalDisplayOrientation(uint displayID);
    public static SDL.Orientation GetNaturalDisplayOrientation(uint displayID)
    {
        return SDL_GetNaturalDisplayOrientation(displayID);
    }
    
    // Get Current Display Orientation
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Orientation SDL_GetCurrentDisplayOrientation(uint displayID);
    public static SDL.Orientation GetCurrentDisplayOrientation(uint displayID)
    {
        return SDL_GetCurrentDisplayOrientation(displayID);
    }
}