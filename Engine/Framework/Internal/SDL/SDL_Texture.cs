using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    // Create Texture
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_CreateTexture(IntPtr renderer, SDL.PixelFormat format, SDL.TextureAccess access, int w, int h);
    public static IntPtr CreateTexture(SDL.PixelFormat format, SDL.TextureAccess access, int w, int h)
    {
        return SDL_CreateTexture(GetRenderer(), format, access, w, h);
    }
    
    // Create Texture From Surface
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_CreateTextureFromSurface(IntPtr renderer, IntPtr surface);
    public static IntPtr CreateTextureFromSurface(IntPtr surface)
    {
        return SDL_CreateTextureFromSurface(GetRenderer(), surface);
    }
    
    // Set Texture Color Mod
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetTextureColorMod(IntPtr texture, byte r, byte g, byte b);
    public static void SetTextureColorMod(IntPtr texture, byte r, byte g, byte b)
    {
        SDL_SetTextureColorMod(texture, r, g, b);
    }
    
    // Get Texture Color Mod
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetTextureColorMod(IntPtr texture, out byte r, out byte g, out byte b);
    public static (byte r, byte g, byte b) GetTextureColorMod(IntPtr texture)
    {
        SDL_GetTextureColorMod(texture, out byte r, out byte g, out byte b);
        return (r, g, b);
    }
    
    // Set Texture Alpha Mod
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetTextureAlphaMod(IntPtr texture, byte alpha);
    public static void SetTextureAlphaMod(IntPtr texture, byte alpha)
    {
        SDL_SetTextureAlphaMod(texture, alpha);
    }
    
    // Get Texture Alpha Mod
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetTextureAlphaMod(IntPtr texture, out byte alpha);
    public static byte GetTextureAlphaMod(IntPtr texture)
    {
        SDL_GetTextureAlphaMod(texture, out byte alpha);
        return alpha;
    }
    
    // Set Texture Blend Mode
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetTextureBlendMode(IntPtr texture, SDL.BlendMode mode);
    public static void SetTextureBlendMode(IntPtr texture, SDL.BlendMode mode)
    {
        SDL_SetTextureBlendMode(texture, mode);
    }
    
    // Get Texture Blend Mode
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetTextureBlendMode(IntPtr texture, out SDL.BlendMode mode);
    public static SDL.BlendMode GetTextureBlendMode(IntPtr texture)
    {
        SDL_GetTextureBlendMode(texture, out SDL.BlendMode mode);
        return mode;
    }
    
    // Set Texture Scale Mode
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetTextureScaleMode(IntPtr texture, SDL.ScaleMode mode);
    public static void SetTextureScaleMode(IntPtr texture, SDL.ScaleMode mode)
    {
        SDL_SetTextureScaleMode(texture, mode);
    }
    
    // Get Texture Scale Mode
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetTextureScaleMode(IntPtr texture, out SDL.ScaleMode mode);
    public static SDL.ScaleMode GetTextureScaleMode(IntPtr texture)
    {
        SDL_GetTextureScaleMode(texture, out SDL.ScaleMode mode);
        return mode;
    }
    
    // Update Texture
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_UpdateTexture(IntPtr texture, SDL.Rect* rect, IntPtr pixels, int pitch);
    public static void UpdateTexture(IntPtr texture, SDL.Rect rect, IntPtr pixels, int pitch)
    {
        SDL_UpdateTexture(texture, &rect, pixels, pitch);
    }
    
    // Lock Texture
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_LockTexture(IntPtr texture, SDL.Rect* rect, out IntPtr pixels, out int pitch);
    public static (IntPtr pixels, int pitch) LockTexture(IntPtr texture, SDL.Rect rect)
    {
        SDL_LockTexture(texture, &rect, out IntPtr pixels, out int pitch);
        return (pixels, pitch);
    }
    
    // Lock Texture To Surface
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_LockTextureToSurface(IntPtr texture, SDL.Rect* rect, out IntPtr surface);
    public static IntPtr LockTextureToSurface(IntPtr texture, SDL.Rect rect)
    {
        SDL_LockTextureToSurface(texture, &rect, out IntPtr surface);
        return surface;
    }
    
    // Unlock Texture
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_UnlockTexture(IntPtr texture);
    public static void UnlockTexture(IntPtr texture)
    {
        SDL_UnlockTexture(texture);
    }
    
    // Get Texture Size
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetTextureSize(IntPtr texture, out float w, out float h);
    public static (float w, float h) GetTextureSize(IntPtr texture)
    {
        SDL_GetTextureSize(texture, out float w, out float h);
        return (w, h);
    }
    
    // Render Texture
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderTexture(IntPtr renderer, IntPtr texture, SDL.FRect* src, SDL.FRect* dst);
    public static void RenderTexture(IntPtr texture, SDL.FRect src, SDL.FRect dst)
    {
        SDL_RenderTexture(GetRenderer(), texture, &src, &dst);
    }
    
    // Render Texture Rotated
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderTextureRotated(IntPtr renderer, IntPtr texture, SDL.FRect* src, SDL.FRect* dst, double angle, SDL.FPoint* center, SDL.FlipMode mode);
    public static void RenderTextureRotated(IntPtr texture, SDL.FRect src, SDL.FRect dst, double angle, SDL.FPoint center, SDL.FlipMode mode)
    {
        SDL_RenderTextureRotated(GetRenderer(), texture, &src, &dst, angle, &center, mode);
    }
}