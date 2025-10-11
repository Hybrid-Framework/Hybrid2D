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
    
    // Destroy Surface
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_DestroySurface(IntPtr surface);
    public static void DestroySurface(IntPtr surface)
    {
        SDL_DestroySurface(surface);
    }
    
    // Create Surface From Texture
    public static IntPtr CreateSurfaceFromTexture(IntPtr texture)
    {
        var width = GetTextureWidth(texture);
        var height = GetTextureHeight(texture);
        var format = GetTextureFormat(texture);
        var target = CreateTexture(format, TextureAccess.Target, width, height);
        FRect rect = new FRect() { x = 0, y = 0, w = width, h = height };

        SetRenderTarget(target);
        RenderTexture(texture, rect, rect);
        var surface = SDL.RenderReadPixels();
        SetRenderTarget(IntPtr.Zero);
        DestroyTexture(target);
        
        return surface;
    }
}