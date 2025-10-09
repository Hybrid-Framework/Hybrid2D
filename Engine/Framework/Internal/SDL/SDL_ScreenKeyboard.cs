using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    // Screen Keyboard Support
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_HasScreenKeyboardSupport();
    public static bool ScreenKeyboardSupport()
    {
        return SDL_HasScreenKeyboardSupport();
    }
    
    // Screen Keyboard Shown
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_ScreenKeyboardShown(IntPtr window);
    public static bool ScreenKeyboardShown()
    {
        return SDL_ScreenKeyboardShown(GetWindow());
    }
    
    // Start Text Input
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_StartTextInput(IntPtr window);
    public static void StartTextInput()
    {
        SDL_StartTextInput(GetWindow());
    }
    
    // Stop Text Input
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_StopTextInput(IntPtr window);
    public static void StopTextInput()
    {
        SDL_StopTextInput(GetWindow());
    }
    
    // Text Input Active
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_TextInputActive(IntPtr window);
    public static bool TextInputActive()
    {
        return SDL_TextInputActive(GetWindow());
    }
    
    // Clear Composition
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_ClearComposition(IntPtr window);
    public static void ClearComposition()
    {
        SDL_ClearComposition(GetWindow());
    }
    
    // Set Text Input Area
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetTextInputArea(IntPtr window, SDL.Rect* rect, int cursor);
    public static void SetTextInputArea(SDL.Rect rect, int cursor)
    {
        SDL_SetTextInputArea(GetWindow(), &rect, cursor);
    }
    
    // Get Text Input Area
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetTextInputArea(IntPtr window, out SDL.Rect rect, out int cursor);
    public static (SDL.Rect rect, int cursor) GetTextInputArea()
    {
        SDL_GetTextInputArea(GetWindow(), out SDL.Rect rect, out int cursor);
        return (rect, cursor);
    }
}