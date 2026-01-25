using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    // Create Window And Renderer
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_CreateWindowAndRenderer(byte* title, int width, int height, ulong flags, out SDL.Window* window, out SDL.Renderer* renderer);
    internal static bool CreateWindowAndRenderer(string title, int w, int h, SDL.WindowFlags flags, out SDL.Window* window, out SDL.Renderer* renderer)
    {
        var bytes = StringToUtf8(title);

        fixed (byte* utf8 = bytes)
        {
            return SDL_CreateWindowAndRenderer(utf8, w, h, (ulong)flags, out window, out renderer);
        }
    }
    
    // Create Window
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Window* SDL_CreateWindow(byte* title, int w, int h, ulong flags);
    internal static SDL.Window* CreateWindow(string title, int w, int h, SDL.WindowFlags flags)
    {
        var bytes = StringToUtf8(title);

        fixed (byte* utf8 = bytes)
        {
            return SDL_CreateWindow(utf8, w, h, (ulong)flags);
        }
    }
    
    // Destroy Window
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_DestroyWindow(SDL.Window* window);
    internal static void DestroyWindow(SDL.Window* window)
    {
        SDL_DestroyWindow(window);
    }
    
    // Set Window Title
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetWindowTitle(SDL.Window* window, byte* title);
    internal static bool SetWindowTitle(SDL.Window* window, string title)
    {
        var bytes = StringToUtf8(title);

        fixed (byte* utf8 = bytes)
        {
            return SDL_SetWindowTitle(window, utf8);
        }
    }
    
    // Get Window Title
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern byte* SDL_GetWindowTitle(SDL.Window* window);
    internal static string GetWindowTitle(SDL.Window* window)
    {
        return Utf8ToString(SDL_GetWindowTitle(window));
    }
    
    // Set Window Position
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetWindowPosition(SDL.Window* window, int x, int y);
    internal static bool SetWindowPosition(SDL.Window* window, int x, int y)
    {
        return SDL_SetWindowPosition(window, x, y);
    }
    
    // Get Window Position
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetWindowPosition(SDL.Window* window, out int x, out int y);
    internal static bool GetWindowPosition(SDL.Window* window, out int x, out int y)
    {
        return SDL_GetWindowPosition(window, out x, out y);
    }
    
    // Set Window Size
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetWindowSize(SDL.Window* window, int w, int h);
    internal static bool SetWindowSize(SDL.Window* window, int w, int h)
    {
        return SDL_SetWindowSize(window, w, h);
    }
    
    // Get Window Size
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetWindowSize(SDL.Window* window, out int w, out int h);
    internal static bool GetWindowSize(SDL.Window* window, out int w, out int h)
    {
        return SDL_GetWindowSize(window, out w, out h);
    }
    
    // Set Window Minimum Size
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetWindowMinimumSize(SDL.Window* window, int w, int h);
    internal static bool SetWindowMinimumSize(SDL.Window* window, int w, int h)
    {
        return SDL_SetWindowMinimumSize(window, w, h);
    }
    
    // Get Window Minimum Size
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetWindowMinimumSize(SDL.Window* window, out int w, out int h);
    internal static bool GetWindowMinimumSize(SDL.Window* window, out int w, out int h)
    {
        return SDL_GetWindowMinimumSize(window, out w, out h);
    }
    
    // Set Window Maximum Size
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetWindowMaximumSize(SDL.Window* window, int w, int h);
    internal static bool SetWindowMaximumSize(SDL.Window* window, int w, int h)
    {
        return SDL_SetWindowMaximumSize(window, w, h);
    }
    
    // Get Window Maximum Size
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetWindowMaximumSize(SDL.Window* window, out int w, out int h);
    internal static bool GetWindowMaximumSize(SDL.Window* window, out int w, out int h)
    {
        return SDL_GetWindowMaximumSize(window, out w, out h);
    }
    
    // Set Window Aspect Ratio
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetWindowAspectRatio(SDL.Window* window, float min, float max);
    internal static bool SetWindowAspectRatio(SDL.Window* window, float min, float max)
    {
        return SDL_SetWindowAspectRatio(window, min, max);
    }
    
    // Get Window Aspect Ratio
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetWindowAspectRatio(SDL.Window* window, out float min, out float max);
    internal static bool GetWindowAspectRatio(SDL.Window* window, out float min, out float max)
    {
        return SDL_GetWindowAspectRatio(window, out min, out max);
    }
    
    // Set Window Bordered
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetWindowBordered(SDL.Window* window, SDL.Bool bordered);
    internal static bool SetWindowBordered(SDL.Window* window, bool bordered)
    {
        return SDL_SetWindowBordered(window, bordered);
    }
    
    // Set Window Resizable
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetWindowResizable(SDL.Window* window, SDL.Bool resizable);
    internal static bool SetWindowResizable(SDL.Window* window, bool resizable)
    {
        var current = (GetWindowFlags(window) & WindowFlags.Resizable) != 0;

        if (resizable != current)
        {
            return SDL_SetWindowResizable(window, resizable);
        }

        return false;
    }
    
    // Set Window Fullscreen
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetWindowFullscreen(SDL.Window* window, SDL.Bool fullscreen);
    internal static bool SetWindowFullscreen(SDL.Window* window, bool fullscreen)
    {
        var current = (GetWindowFlags(window) & WindowFlags.Fullscreen) != 0;

        if (fullscreen != current)
        {
            return SDL_SetWindowFullscreen(window, fullscreen);
        }

        return false;
    }
    
    // Show Window
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_ShowWindow(SDL.Window* window);
    internal static bool ShowWindow(SDL.Window* window)
    {
        return SDL_ShowWindow(window);
    }
    
    // Hide Window
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_HideWindow(SDL.Window* window);
    internal static bool HideWindow(SDL.Window* window)
    {
        return SDL_HideWindow(window);
    }
    
    // Set Window Icon
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetWindowIcon(SDL.Window* window, SDL.Surface* surface);
    internal static bool SetWindowIcon(SDL.Window* window, SDL.Surface* surface)
    {
        return SDL_SetWindowIcon(window, surface);
    }
    
    // Get Window Safe Area
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetWindowSafeArea(SDL.Window* window, out RectInt rect);
    internal static bool GetWindowSafeArea(SDL.Window* window, out RectInt rect)
    {
        return SDL_GetWindowSafeArea(window, out rect);
    }
    
    // Get Window Flags
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern ulong SDL_GetWindowFlags(SDL.Window* window);
    internal static SDL.WindowFlags GetWindowFlags(SDL.Window* window)
    {
        return (SDL.WindowFlags)SDL_GetWindowFlags(window);
    }
    
    // Get Window Size In Pixels
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetWindowSizeInPixels(SDL.Window* window, out int w, out int h);
    internal static bool GetWindowSizeInPixels(SDL.Window* window, out int w, out int h)
    {
        return SDL_GetWindowSizeInPixels(window, out w, out h);
    }
    
    // Raise Window
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RaiseWindow(SDL.Window* window);
    internal static bool RaiseWindow(SDL.Window* window)
    {
        return SDL_RaiseWindow(window);
    }
    
    // Maximize Window
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_MaximizeWindow(SDL.Window* window);
    internal static bool MaximizeWindow(SDL.Window* window)
    {
        return SDL_MaximizeWindow(window);
    }

    // Minimize Window
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_MinimizeWindow(SDL.Window* window);
    internal static bool MinimizeWindow(SDL.Window* window)
    {
        return SDL_MinimizeWindow(window);
    }
    
    // Get Window ID
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern uint SDL_GetWindowID(SDL.Window* window);
    internal static uint GetWindowID(SDL.Window* window)
    {
        return SDL_GetWindowID(window);
    }
    
    // Get Window From ID
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Window* SDL_GetWindowFromID(uint windowID);
    internal static SDL.Window* GetWindowFromID(uint windowID)
    {
        return SDL_GetWindowFromID(windowID);
    }
    
    // Restore Window
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RestoreWindow(SDL.Window* window);
    internal static bool RestoreWindow(SDL.Window* window)
    {
        return SDL_RestoreWindow(window);
    }
}