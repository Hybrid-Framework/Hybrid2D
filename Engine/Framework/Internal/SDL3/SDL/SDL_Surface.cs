using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    // Create Surface
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_CreateSurface(int w, int h, SDL.PixelFormat format);
    public static IntPtr CreateSurface(int w, int h, SDL.PixelFormat format)
    {
        return SDL_CreateSurface(w, h, format);
    }
    
    // Create Surface From Texture
    public static IntPtr CreateSurfaceFromTexture(IntPtr renderer, IntPtr texture)
    {
        var width = SDL.GetTextureWidth(texture);
        var height = SDL.GetTextureHeight(texture);
        var format = SDL.GetTextureFormat(texture);
        var target = SDL.CreateTexture(renderer, format, TextureAccess.Target, width, height);

        SDL.SetRenderTarget(renderer, target);
        SDL.RenderTexture(renderer, texture, null, null);
        
        var surface = SDL.RenderReadPixels(renderer, null);
        
        SDL.SetRenderTarget(renderer, IntPtr.Zero);
        SDL.DestroyTexture(target);
        
        return surface;
    }
    
    // Destroy Surface
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_DestroySurface(IntPtr surface);
    public static void DestroySurface(IntPtr surface)
    {
        SDL_DestroySurface(surface);
    }
    
    // Lock Surface
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_LockSurface(IntPtr surface);
    public static bool LockSurface(IntPtr surface)
    {
        return SDL_LockSurface(surface);
    }
    
    // Unlock Surface
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_UnlockSurface(IntPtr surface);
    public static void UnlockSurface(IntPtr surface)
    {
        SDL_UnlockSurface(surface);
    }
}