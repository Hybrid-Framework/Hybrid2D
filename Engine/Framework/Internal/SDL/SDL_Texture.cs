using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    // Create Texture
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Texture* SDL_CreateTexture(SDL.Renderer* renderer, SDL.PixelFormat format, SDL.TextureAccess access, int w, int h);
    public static SDL.Texture* CreateTexture(SDL.Renderer* renderer, SDL.PixelFormat format, SDL.TextureAccess access, int w, int h)
    {
        return SDL_CreateTexture(renderer, format, access, w, h);
    }
    
    // Create Texture From Surface
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Texture* SDL_CreateTextureFromSurface(SDL.Renderer* renderer, SDL.Surface* surface);
    public static SDL.Texture* CreateTextureFromSurface(SDL.Renderer* renderer, SDL.Surface* surface)
    {
        return SDL_CreateTextureFromSurface(renderer, surface);
    }
    
    // Destroy Texture
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_DestroyTexture(SDL.Texture* texture);
    public static void DestroyTexture(SDL.Texture* texture)
    {
        SDL_DestroyTexture(texture);
    }
    
    // Set Texture Scale Mode
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetTextureScaleMode(SDL.Texture* texture, SDL.ScaleMode mode);
    public static bool SetTextureScaleMode(SDL.Texture* texture, SDL.ScaleMode mode)
    {
        return SDL_SetTextureScaleMode(texture, mode);
    }
    
    // Get Texture Scale Mode
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetTextureScaleMode(SDL.Texture* texture, out SDL.ScaleMode mode);
    public static bool GetTextureScaleMode(SDL.Texture* texture, out SDL.ScaleMode mode)
    {
        return SDL_GetTextureScaleMode(texture, out mode);
    }
    
    // Set Texture Color Mod
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetTextureColorMod(SDL.Texture* texture, byte r, byte g, byte b);
    public static bool SetTextureColorMod(SDL.Texture* texture, byte r, byte g, byte b)
    {
        return SDL_SetTextureColorMod(texture, r, g, b);
    }
    
    // Get Texture Color Mod
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetTextureColorMod(SDL.Texture* texture, out byte r, out byte g, out byte b);
    public static bool GetTextureColorMod(SDL.Texture* texture, out byte r, out byte g, out byte b)
    {
        return SDL_GetTextureColorMod(texture, out r, out g, out b);
    }
    
    // Set Texture Alpha Mod
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetTextureAlphaMod(SDL.Texture* texture, byte alpha);
    public static bool SetTextureAlphaMod(SDL.Texture* texture, byte alpha)
    {
        return SDL_SetTextureAlphaMod(texture, alpha);
    }
    
    // Get Texture Alpha Mod
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetTextureAlphaMod(SDL.Texture* texture, out byte alpha);
    public static bool GetTextureAlphaMod(SDL.Texture* texture, out byte alpha)
    {
        return SDL_GetTextureAlphaMod(texture, out alpha);
    }
    
    // Set Texture Blend Mode
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetTextureBlendMode(SDL.Texture* texture, SDL.BlendMode mode);
    public static bool SetTextureBlendMode(SDL.Texture* texture, SDL.BlendMode mode)
    {
        return SDL_SetTextureBlendMode(texture, mode);
    }
    
    // Get Texture Blend Mode
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetTextureBlendMode(SDL.Texture* texture, out SDL.BlendMode mode);
    public static bool GetTextureBlendMode(SDL.Texture* texture, out SDL.BlendMode mode)
    {
        return SDL_GetTextureBlendMode(texture, out mode);
    }
    
    // Render Texture
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderTexture(SDL.Renderer* renderer, SDL.Texture* texture, ref SDL.FRect src, ref SDL.FRect dst);
    public static bool RenderTexture(SDL.Renderer* renderer, SDL.Texture* texture, ref SDL.FRect src, ref SDL.FRect dst)
    {
        return SDL_RenderTexture(renderer, texture, ref src, ref dst);
    }
    
    // Render Texture Rotated
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderTextureRotated(SDL.Renderer* renderer, SDL.Texture* texture, ref SDL.FRect src, ref SDL.FRect dst, double angle, ref SDL.FPoint center, SDL.FlipMode flip);
    public static bool RenderTextureRotated(SDL.Renderer* renderer, SDL.Texture* texture, ref SDL.FRect src, ref SDL.FRect dst, double angle, ref SDL.FPoint center, SDL.FlipMode flip)
    {
        return SDL_RenderTextureRotated(renderer, texture, ref src, ref dst, angle, ref center, flip);
    }
    
    // Render Texture Affine
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderTextureAffine(SDL.Renderer* renderer, SDL.Texture* texture, ref SDL.FRect src, ref SDL.FPoint origin, ref SDL.FPoint right, ref SDL.FPoint down);
    public static bool RenderTextureAffine(SDL.Renderer* renderer, SDL.Texture* texture, ref SDL.FRect src, ref SDL.FPoint origin, ref SDL.FPoint right, ref SDL.FPoint down)
    {
        return SDL_RenderTextureAffine(renderer, texture, ref src, ref origin, ref right, ref down);
    }
    
    // Render Texture Tiled
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderTextureTiled(SDL.Renderer* renderer, SDL.Texture* texture, ref SDL.FRect src, float scale, ref SDL.FRect dst);
    public static bool RenderTextureTiled(SDL.Renderer* renderer, SDL.Texture* texture, ref SDL.FRect src, float scale, ref SDL.FRect dst)
    {
        return SDL_RenderTextureTiled(renderer, texture, ref src, scale, ref dst);
    }
    
    // Update Texture
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_UpdateTexture(SDL.Texture* texture, ref SDL.Rect rect, byte* pixels, int pitch);
    public static bool UpdateTexture(SDL.Texture* texture, ref SDL.Rect rect, byte* pixels, int pitch)
    {
        return SDL_UpdateTexture(texture, ref rect, pixels, pitch);
    }
    
    // Lock Texture
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_LockTexture(SDL.Texture* texture, ref SDL.Rect rect, out byte* pixels, out int pitch);
    public static bool LockTexture(SDL.Texture* texture, ref SDL.Rect rect, out byte* pixels, out int pitch)
    {
        return SDL_LockTexture(texture, ref rect, out pixels, out pitch);
    }
    
    // Unlock Texture
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_UnlockTexture(SDL.Texture* texture);
    public static void UnlockTexture(SDL.Texture* texture)
    {
        SDL_UnlockTexture(texture);
    }
}