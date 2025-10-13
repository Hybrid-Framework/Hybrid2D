using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    // Create Renderer
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Renderer* SDL_CreateRenderer(SDL.Window* window, byte* name);
    public static SDL.Renderer* CreateRenderer(SDL.Window* window, string name)
    {
        var bytes = StringToUtf8(name);

        fixed (byte* utf8 = bytes)
        {
            return SDL_CreateRenderer(window, utf8);
        }
    }
    
    // Destroy Renderer
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_DestroyRenderer(SDL.Renderer* renderer);
    public static void DestroyRenderer(SDL.Renderer* renderer)
    {
        SDL_DestroyRenderer(renderer);
    }
    
    // Set Render Target
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetRenderTarget(SDL.Renderer* renderer, SDL.Texture* texture);
    public static bool SetRenderTarget(SDL.Renderer* renderer, SDL.Texture* texture)
    {
        return SDL_SetRenderTarget(renderer, texture);
    }
    
    // Get Render Target
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Texture* SDL_GetRenderTarget(SDL.Renderer* renderer);
    public static SDL.Texture* GetRenderTarget(SDL.Renderer* renderer)
    {
        return SDL_GetRenderTarget(renderer);
    }
    
    // Set Render Logical Presentation
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetRenderLogicalPresentation(SDL.Renderer* renderer, int w, int h, SDL.Presentation presentation);
    public static bool SetRenderLogicalPresentation(SDL.Renderer* renderer, int w, int h, SDL.Presentation presentation)
    {
        return SDL_SetRenderLogicalPresentation(renderer, w, h, presentation);
    }
    
    // Get Render Logical Presentation
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetRenderLogicalPresentation(SDL.Renderer* renderer, out int w, out int h, out SDL.Presentation presentation);
    public static bool GetRenderLogicalPresentation(SDL.Renderer* renderer, out int w, out int h, out SDL.Presentation presentation)
    {
        return SDL_GetRenderLogicalPresentation(renderer, out w, out h, out presentation);
    }
    
    // Get Render Logical Presentation Rect
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetRenderLogicalPresentationRect(SDL.Renderer* renderer, out SDL.FRect rect);
    public static bool GetRenderLogicalPresentationRect(SDL.Renderer* renderer, out SDL.FRect rect)
    {
        return SDL_GetRenderLogicalPresentationRect(renderer, out rect);
    }
    
    // Set Render Viewport
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetRenderViewport(SDL.Renderer* renderer, ref SDL.Rect rect);
    public static bool SetRenderViewport(SDL.Renderer* renderer, ref SDL.Rect rect)
    {
        return SDL_SetRenderViewport(renderer, ref rect);
    }
    
    // Get Render Viewport
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetRenderViewport(SDL.Renderer* renderer, out SDL.Rect rect);
    public static bool GetRenderViewport(SDL.Renderer* renderer, out SDL.Rect rect)
    {
        return SDL_GetRenderViewport(renderer, out rect);
    }
    
    // Render Viewport Set
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderViewportSet(SDL.Renderer* renderer);
    public static bool RenderViewportSet(SDL.Renderer* renderer)
    {
        return SDL_RenderViewportSet(renderer);
    }
    
    // Set Render Clip Rect
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetRenderClipRect(SDL.Renderer* renderer, ref SDL.Rect rect);
    public static bool SetRenderClipRect(SDL.Renderer* renderer, ref SDL.Rect rect)
    {
        return SDL_SetRenderClipRect(renderer, ref rect);
    }
    
    // Get Render Clip Rect
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetRenderClipRect(SDL.Renderer* renderer, out SDL.Rect rect);
    public static bool GetRenderClipRect(SDL.Renderer* renderer, out SDL.Rect rect)
    {
        return SDL_GetRenderClipRect(renderer, out rect);
    }
    
    // Render Clip Enabled
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderClipEnabled(SDL.Renderer* renderer);
    public static bool RenderClipEnabled(SDL.Renderer* renderer)
    {
        return SDL_RenderClipEnabled(renderer);
    }
    
    // Set Render Scale
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetRenderScale(SDL.Renderer* renderer, float x, float y);
    public static bool SetRenderScale(SDL.Renderer* renderer, float x, float y)
    {
        return SDL_SetRenderScale(renderer, x, y);
    }
    
    // Get Render Scale
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetRenderScale(SDL.Renderer* renderer, out float x, out float y);
    public static bool GetRenderScale(SDL.Renderer* renderer, out float x, out float y)
    {
        return SDL_GetRenderScale(renderer, out x, out y);
    }
    
    // Set Render VSync
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetRenderVSync(SDL.Renderer* renderer, int vsync);
    public static bool SetRenderVSync(SDL.Renderer* renderer, int vsync)
    {
        return SDL_SetRenderVSync(renderer, vsync);
    }
    
    // Get Render VSync
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetRenderVSync(SDL.Renderer* renderer, out int vsync);
    public static bool GetRenderVSync(SDL.Renderer* renderer, out int vsync)
    {
        return SDL_GetRenderVSync(renderer, out vsync);
    }
    
    // Get Render Output Size
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetRenderOutputSize(SDL.Renderer* renderer, out int w, out int h);
    public static bool GetRenderOutputSize(SDL.Renderer* renderer, out int w, out int h)
    {
        return SDL_GetRenderOutputSize(renderer, out w, out h);
    }
    
    // Get Current Render Output Size
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetCurrentRenderOutputSize(SDL.Renderer* renderer, out int w, out int h);
    public static bool GetCurrentRenderOutputSize(SDL.Renderer* renderer, out int w, out int h)
    {
        return SDL_GetCurrentRenderOutputSize(renderer, out w, out h);
    }
    
    // Get Render Safe Area
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetRenderSafeArea(SDL.Renderer* renderer, out SDL.Rect rect);
    public static bool GetRenderSafeArea(SDL.Renderer* renderer, out SDL.Rect rect)
    {
        return SDL_GetRenderSafeArea(renderer, out rect);
    }
    
    // Get Renderer
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Renderer* SDL_GetRenderer(SDL.Window* window);
    public static SDL.Renderer* GetRenderer(SDL.Window* window)
    {
        return SDL_GetRenderer(window);
    }
    
    // Get Render Window
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Window* SDL_GetRenderWindow(SDL.Renderer* renderer);
    public static SDL.Window* GetRenderWindow(SDL.Renderer* renderer)
    {
        return SDL_GetRenderWindow(renderer);
    }
}