using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    // Create Surface
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Surface* SDL_CreateSurface(int w, int h, SDL.PixelFormat format);
    public static SDL.Surface* CreateSurface(int w, int h, SDL.PixelFormat format)
    {
        return SDL_CreateSurface(w, h, format);
    }
    
    // Create Surface From Texture
    public static SDL.Surface* CreateSurfaceFromTexture(SDL.Renderer* renderer, SDL.Texture* texture)
    {
        var width = GetTextureWidth(texture);
        var height = GetTextureHeight(texture);
        var format = GetTextureFormat(texture);
        var target = CreateTexture(renderer, format, TextureAccess.Target, width, height);

        SetRenderTarget(renderer, target);
        RenderTexture(renderer, texture, null, null);
        
        var surface = RenderReadPixels(renderer, null);
        
        SetRenderTarget(renderer, null);
        DestroyTexture(target);
        
        return surface;
    }
    
    // Destroy Surface
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_DestroySurface(SDL.Surface* surface);
    public static void DestroySurface(SDL.Surface* surface)
    {
        SDL_DestroySurface(surface);
    }
    
    // Lock Surface
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_LockSurface(SDL.Surface* surface);
    public static bool LockSurface(SDL.Surface* surface)
    {
        return SDL_LockSurface(surface);
    }
    
    // Unlock Surface
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_UnlockSurface(SDL.Surface* surface);
    public static void UnlockSurface(SDL.Surface* surface)
    {
        SDL_UnlockSurface(surface);
    }
    
    // Convert Surface
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Surface* SDL_ConvertSurface(SDL.Surface* surface, SDL.PixelFormat format);
    public static SDL.Surface* ConvertSurface(SDL.Surface* surface, SDL.PixelFormat format)
    {
        return SDL_ConvertSurface(surface, format);
    }
}