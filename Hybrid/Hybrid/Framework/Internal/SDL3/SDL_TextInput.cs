using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    // Start Text Input
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_StartTextInput(SDL.Window* window);
    internal static bool StartTextInput(SDL.Window* window)
    {
        return SDL_StartTextInput(window);
    }
    
    // Start Text Input With Properties
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_StartTextInputWithProperties(SDL.Window* window, uint properties);
    internal static bool StartTextInputWithProperties(SDL.Window* window, uint properties)
    {
        return SDL_StartTextInputWithProperties(window, properties);
    }
    
    // Stop Text Input
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_StopTextInput(SDL.Window* window);
    internal static bool StopTextInput(SDL.Window* window)
    {
        return SDL_StopTextInput(window);
    }
    
    // Text Input Active
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_TextInputActive(SDL.Window* window);
    internal static bool TextInputActive(SDL.Window* window)
    {
        return SDL_TextInputActive(window);
    }
    
    // Set Text Input Area
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetTextInputArea(SDL.Window* window, RectInt* rect, int cursor);
    internal static bool SetTextInputArea(SDL.Window* window, RectInt? rect, int cursor)
    {
        RectInt r = rect.GetValueOrDefault();
        var rv = (rect.HasValue ? &r : null);

        return SDL_SetTextInputArea(window, rv, cursor);
    }
    
    // Get Text Input Area
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetTextInputArea(SDL.Window* window, out RectInt rect, out int cursor);
    internal static bool GetTextInputArea(SDL.Window* window, out RectInt rect, out int cursor)
    {
        return SDL_GetTextInputArea(window, out rect, out cursor);
    }
    
    // Has Screen Keyboard Support
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_HasScreenKeyboardSupport();
    internal static bool HasScreenKeyboardSupport()
    {
        return SDL_HasScreenKeyboardSupport();
    }
    
    // Screen Keyboard Shown
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_ScreenKeyboardShown(SDL.Window* window);
    internal static bool ScreenKeyboardShown(SDL.Window* window)
    {
        return SDL_ScreenKeyboardShown(window);
    }
    
    // Clear Composition
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_ClearComposition(SDL.Window* window);
    internal static bool ClearComposition(SDL.Window* window)
    {
        return SDL_ClearComposition(window);
    }
}