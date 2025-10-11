using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    // Window
    private static IntPtr Window;
    public static IntPtr GetWindow()
    {
        return Window;
    }
    
    
    // Create Window
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_CreateWindow(byte* title, int w, int h, SDL.WindowFlags flags);
    public static void CreateWindow(string title, int w, int h, SDL.WindowFlags flags)
    {
        var bytes = StringToUtf8(title);
        
        fixed (byte* utf8 = bytes)
        {
            DestroyWindow();
            Window = SDL_CreateWindow(utf8, w, h, flags);
        }
    }
    
    // Destroy Window
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_DestroyWindow(IntPtr window);
    public static void DestroyWindow()
    {
        if (Window != IntPtr.Zero)
        {
            SDL_DestroyWindow(GetWindow());
            Window = IntPtr.Zero;
        }
    }
    
    // Set Window Title
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetWindowTitle(IntPtr window, byte* title);
    public static void SetWindowTitle(string title)
    {
        var bytes = StringToUtf8(title);
        
        fixed (byte* utf8 = bytes)
        {
            SDL_SetWindowTitle(GetWindow(), utf8);
        }
    }
    
    // Get Window Title
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_GetWindowTitle(IntPtr window);
    public static string GetWindowTitle()
    {
        return Utf8ToString(SDL_GetWindowTitle(GetWindow()));
    }
    
    // Set Window Position
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetWindowPosition(IntPtr window, int x, int y);
    public static void SetWindowPosition(int x, int y)
    {
        SDL_SetWindowPosition(GetWindow(), x, y);
    }
    
    // Get Window Position
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetWindowPosition(IntPtr window, out int x, out int y);
    public static (int x, int y) GetWindowPosition()
    {
        SDL_GetWindowPosition(GetWindow(), out int x, out int y);
        return (x, y);
    }
    
    // Set Window Size
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetWindowSize(IntPtr window, int w, int h);
    public static void SetWindowSize(int w, int h)
    {
        SDL_SetWindowSize(GetWindow(), w, h);
    }
    
    // Get Window Size
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetWindowSize(IntPtr window, out int w, out int h);
    public static (int w, int h) GetWindowSize()
    {
        SDL_GetWindowSize(GetWindow(), out int w, out int h);
        return (w, h);
    }
    
    // Set Window Aspect Ratio
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetWindowAspectRatio(IntPtr window, float min, float max);
    public static void SetWindowAspectRatio(float min, float max)
    {
        SDL_SetWindowAspectRatio(GetWindow(), min, max);
    }
    
    // Get Window Aspect Ratio
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetWindowAspectRatio(IntPtr window, out float min, out float max);
    public static (float min, float max) GetWindowAspectRatio()
    {
        SDL_GetWindowAspectRatio(GetWindow(), out float min, out float max);
        return (min, max);
    }
    
    // Set Window Minimum Size
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetWindowMinimumSize(IntPtr window, int w, int h);
    public static void SetWindowMinimumSize(int w, int h)
    {
        SDL_SetWindowMinimumSize(GetWindow(), w, h);
    }
    
    // Get Window Minimum Size
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetWindowMinimumSize(IntPtr window, out int w, out int h);
    public static (int w, int h) GetWindowMinimumSize()
    {
        SDL_GetWindowMinimumSize(GetWindow(), out int w, out int h);
        return (w, h);
    }
    
    // Set Window Maximum Size
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetWindowMaximumSize(IntPtr window, int w, int h);
    public static void SetWindowMaximumSize(int w, int h)
    {
        SDL_SetWindowMaximumSize(GetWindow(), w, h);
    }
    
    // Get Window Maximum Size
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetWindowMaximumSize(IntPtr window, out int w, out int h);
    public static (int w, int h) GetWindowMaximumSize()
    {
        SDL_GetWindowMaximumSize(GetWindow(), out int w, out int h);
        return (w, h);
    }
    
    // Get Window Safe Area
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetWindowSafeArea(IntPtr window, out SDL.Rect rect);
    public static SDL.Rect GetWindowSafeArea()
    {
        SDL_GetWindowSafeArea(GetWindow(), out SDL.Rect rect);
        return rect;
    }
    
    // Set Window Resizable
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetWindowResizable(IntPtr window, SDL.Bool resizable);
    public static void SetWindowResizable(bool resizable)
    {
        SDL_SetWindowResizable(GetWindow(), resizable);
    }
    
    // Set Window Fullscreen
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetWindowFullscreen(IntPtr window, SDL.Bool fullscreen);
    public static void SetWindowFullscreen(bool fullscreen)
    {
        SDL_SetWindowFullscreen(GetWindow(), fullscreen);
    }
    
    // Maximize Window
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_MaximizeWindow(IntPtr window);
    public static void MaximizeWindow()
    {
        SDL_MaximizeWindow(GetWindow());
    }
    
    // Minimize Window
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_MinimizeWindow(IntPtr window);
    public static void MinimizeWindow()
    {
        SDL_MinimizeWindow(GetWindow());
    }
    
    // Show Window
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_ShowWindow(IntPtr window);
    public static void ShowWindow()
    {
        SDL_ShowWindow(GetWindow());
    }
    
    // Hide Window
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_HideWindow(IntPtr window);
    public static void HideWindow()
    {
        SDL_HideWindow(GetWindow());
    }
    
    // Get Display ID
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern uint SDL_GetDisplayForWindow(IntPtr window);
    public static uint GetDisplayID()
    {
        return SDL_GetDisplayForWindow(GetWindow());
    }
    
    // Get Natural Orientation
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Orientation SDL_GetNaturalDisplayOrientation(uint displayID);
    public static SDL.Orientation GetNaturalOrientation()
    {
        return SDL_GetNaturalDisplayOrientation(GetDisplayID());
    }
    
    // Get Current Orientation
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Orientation SDL_GetCurrentDisplayOrientation(uint displayID);
    public static SDL.Orientation GetCurrentOrientation()
    {
        return SDL_GetCurrentDisplayOrientation(GetDisplayID());
    }
}