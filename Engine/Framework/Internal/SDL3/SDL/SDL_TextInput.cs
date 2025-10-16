using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    // Start Text Input
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_StartTextInput(IntPtr window);
    public static bool StartTextInput(IntPtr window)
    {
        return SDL_StartTextInput(window);
    }
    
    // Start Text Input With Properties
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_StartTextInputWithProperties(IntPtr window, uint properties);
    public static bool StartTextInputWithProperties(IntPtr window, uint properties)
    {
        return SDL_StartTextInputWithProperties(window, properties);
    }
    
    // Stop Text Input
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_StopTextInput(IntPtr window);
    public static bool StopTextInput(IntPtr window)
    {
        return SDL_StopTextInput(window);
    }
    
    // Text Input Active
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_TextInputActive(IntPtr window);
    public static bool TextInputActive(IntPtr window)
    {
        return SDL_TextInputActive(window);
    }
    
    // Set Text Input Area
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetTextInputArea(IntPtr window, SDL.Rect* rect, int cursor);
    public static bool SetTextInputArea(IntPtr window, SDL.Rect? rect, int cursor)
    {
        SDL.Rect r = rect.GetValueOrDefault();
        var rv = (rect.HasValue ? &r : null);

        return SDL_SetTextInputArea(window, rv, cursor);
    }
    
    // Get Text Input Area
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetTextInputArea(IntPtr window, out SDL.Rect rect, out int cursor);
    public static bool GetTextInputArea(IntPtr window, out SDL.Rect rect, out int cursor)
    {
        return SDL_GetTextInputArea(window, out rect, out cursor);
    }
    
    // Has Screen Keyboard Support
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_HasScreenKeyboardSupport();
    public static bool HasScreenKeyboardSupport()
    {
        return SDL_HasScreenKeyboardSupport();
    }
    
    // Screen Keyboard Shown
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_ScreenKeyboardShown(IntPtr window);
    public static bool ScreenKeyboardShown(IntPtr window)
    {
        return SDL_ScreenKeyboardShown(window);
    }
    
    // Clear Composition
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_ClearComposition(IntPtr window);
    public static bool ClearComposition(IntPtr window)
    {
        return SDL_ClearComposition(window);
    }
}