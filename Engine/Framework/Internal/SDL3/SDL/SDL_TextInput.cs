using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    // Start Text Input
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_StartTextInput(SDL.Window* window);
    public static bool StartTextInput(SDL.Window* window)
    {
        return SDL_StartTextInput(window);
    }
    
    // Start Text Input With Properties
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_StartTextInputWithProperties(SDL.Window* window, uint properties);
    public static bool StartTextInputWithProperties(SDL.Window* window, uint properties)
    {
        return SDL_StartTextInputWithProperties(window, properties);
    }
    
    // Stop Text Input
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_StopTextInput(SDL.Window* window);
    public static bool StopTextInput(SDL.Window* window)
    {
        return SDL_StopTextInput(window);
    }
    
    // Text Input Active
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_TextInputActive(SDL.Window* window);
    public static bool TextInputActive(SDL.Window* window)
    {
        return SDL_TextInputActive(window);
    }
    
    // Set Text Input Area
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetTextInputArea(SDL.Window* window, SDL.Rect* rect, int cursor);
    public static bool SetTextInputArea(SDL.Window* window, SDL.Rect? rect, int cursor)
    {
        SDL.Rect r = rect.GetValueOrDefault();
        var rv = (rect.HasValue ? &r : null);

        return SDL_SetTextInputArea(window, rv, cursor);
    }
    
    // Get Text Input Area
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetTextInputArea(SDL.Window* window, out SDL.Rect rect, out int cursor);
    public static bool GetTextInputArea(SDL.Window* window, out SDL.Rect rect, out int cursor)
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
    private static extern SDL.Bool SDL_ScreenKeyboardShown(SDL.Window* window);
    public static bool ScreenKeyboardShown(SDL.Window* window)
    {
        return SDL_ScreenKeyboardShown(window);
    }
    
    // Clear Composition
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_ClearComposition(SDL.Window* window);
    public static bool ClearComposition(SDL.Window* window)
    {
        return SDL_ClearComposition(window);
    }
}