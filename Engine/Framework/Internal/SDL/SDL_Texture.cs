using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    // Create Texture
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_CreateTexture(IntPtr renderer, SDL.PixelFormat format, SDL.TextureAccess access, int w, int h);
    public static IntPtr CreateTexture(IntPtr renderer, SDL.PixelFormat format, SDL.TextureAccess access, int w, int h)
    {
        return SDL_CreateTexture(renderer, format, access, w, h);
    }
    
    // Create Texture With Properties
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_CreateTextureWithProperties(IntPtr renderer, uint properties);
    public static IntPtr CreateTextureWithProperties(IntPtr renderer, uint properties)
    {
        return SDL_CreateTextureWithProperties(renderer, properties);
    }
    
    // Create Texture From Surface
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_CreateTextureFromSurface(IntPtr renderer, IntPtr surface);
    public static IntPtr CreateTextureFromSurface(IntPtr renderer, IntPtr surface)
    {
        return SDL_CreateTextureFromSurface(renderer, surface);
    }
    
    // Destroy Texture
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_DestroyTexture(IntPtr texture);
    public static void DestroyTexture(IntPtr texture)
    {
        SDL_DestroyTexture(texture);
    }
    
    // Set Texture Scale Mode
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetTextureScaleMode(IntPtr texture, SDL.ScaleMode mode);
    public static bool SetTextureScaleMode(IntPtr texture, SDL.ScaleMode mode)
    {
        return SDL_SetTextureScaleMode(texture, mode);
    }
    
    // Get Texture Scale Mode
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetTextureScaleMode(IntPtr texture, out SDL.ScaleMode mode);
    public static bool GetTextureScaleMode(IntPtr texture, out SDL.ScaleMode mode)
    {
        return SDL_GetTextureScaleMode(texture, out mode);
    }
    
    // Set Texture Color Mod
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetTextureColorMod(IntPtr texture, byte r, byte g, byte b);
    public static bool SetTextureColorMod(IntPtr texture, byte r, byte g, byte b)
    {
        return SDL_SetTextureColorMod(texture, r, g, b);
    }
    
    // Get Texture Color Mod
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetTextureColorMod(IntPtr texture, out byte r, out byte g, out byte b);
    public static bool GetTextureColorMod(IntPtr texture, out byte r, out byte g, out byte b)
    {
        return SDL_GetTextureColorMod(texture, out r, out g, out b);
    }
    
    // Set Texture Alpha Mod
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetTextureAlphaMod(IntPtr texture, byte alpha);
    public static bool SetTextureAlphaMod(IntPtr texture, byte alpha)
    {
        return SDL_SetTextureAlphaMod(texture, alpha);
    }
    
    // Get Texture Alpha Mod
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetTextureAlphaMod(IntPtr texture, out byte alpha);
    public static bool GetTextureAlphaMod(IntPtr texture, out byte alpha)
    {
        return SDL_GetTextureAlphaMod(texture, out alpha);
    }
    
    // Set Texture Blend Mode
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetTextureBlendMode(IntPtr texture, SDL.BlendMode mode);
    public static bool SetTextureBlendMode(IntPtr texture, SDL.BlendMode mode)
    {
        return SDL_SetTextureBlendMode(texture, mode);
    }
    
    // Get Texture Blend Mode
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetTextureBlendMode(IntPtr texture, out SDL.BlendMode mode);
    public static bool GetTextureBlendMode(IntPtr texture, out SDL.BlendMode mode)
    {
        return SDL_GetTextureBlendMode(texture, out mode);
    }
    
    // Render Texture
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderTexture(IntPtr renderer, IntPtr texture, SDL.FRect* src, SDL.FRect* dst);
    public static bool RenderTexture(IntPtr renderer, IntPtr texture, SDL.FRect? src, SDL.FRect? dst)
    {
        SDL.FRect s = src.GetValueOrDefault();
        var sv = (src.HasValue ? &s : null);
        
        SDL.FRect d = dst.GetValueOrDefault();
        var dv = (dst.HasValue ? &d : null);
        
        return SDL_RenderTexture(renderer, texture, sv, dv);
    }
    
    // Render Texture Rotated
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderTextureRotated(IntPtr renderer, IntPtr texture, SDL.FRect* src, SDL.FRect* dst, double angle, SDL.FPoint* center, SDL.FlipMode flip);
    public static bool RenderTextureRotated(IntPtr renderer, IntPtr texture, SDL.FRect? src, SDL.FRect? dst, double angle, SDL.FPoint? center, SDL.FlipMode flip)
    {
        SDL.FRect s = src.GetValueOrDefault();
        var sv = (src.HasValue ? &s : null);
        
        SDL.FRect d = dst.GetValueOrDefault();
        var dv = (dst.HasValue ? &d : null);
        
        SDL.FPoint c = center.GetValueOrDefault();
        var cv = (center.HasValue ? &c : null);
        
        return SDL_RenderTextureRotated(renderer, texture, sv, dv, angle, cv, flip);
    }
    
    // Render Texture Affine
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderTextureAffine(IntPtr renderer, IntPtr texture, SDL.FRect* src, SDL.FPoint* origin, SDL.FPoint* right, SDL.FPoint* down);
    public static bool RenderTextureAffine(IntPtr renderer, IntPtr texture, SDL.FRect? src, SDL.FPoint? origin, SDL.FPoint? right, SDL.FPoint? down)
    {
        SDL.FRect s = src.GetValueOrDefault();
        var sv = (src.HasValue ? &s : null);
        
        SDL.FPoint o = origin.GetValueOrDefault();
        var ov = (origin.HasValue ? &o : null);
        
        SDL.FPoint r = right.GetValueOrDefault();
        var rv = (right.HasValue ? &r : null);
        
        SDL.FPoint d = down.GetValueOrDefault();
        var dv = (down.HasValue ? &d : null);
        
        return SDL_RenderTextureAffine(renderer, texture, sv, ov, rv, dv);
    }
    
    // Render Texture Tiled
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderTextureTiled(IntPtr renderer, IntPtr texture, SDL.FRect* src, float scale, SDL.FRect* dst);
    public static bool RenderTextureTiled(IntPtr renderer, IntPtr texture, SDL.FRect? src, float scale, SDL.FRect? dst)
    {
        SDL.FRect s = src.GetValueOrDefault();
        var sv = (src.HasValue ? &s : null);
        
        SDL.FRect d = dst.GetValueOrDefault();
        var dv = (dst.HasValue ? &d : null);
        
        return SDL_RenderTextureTiled(renderer, texture, sv, scale, dv);
    }
    
    // Update Texture
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_UpdateTexture(IntPtr texture, SDL.Rect* rect, IntPtr pixels, int pitch);
    public static bool UpdateTexture(IntPtr texture, SDL.Rect? rect, IntPtr pixels, int pitch)
    {
        SDL.Rect r = rect.GetValueOrDefault();
        var rv = (rect.HasValue ? &r : null);
        
        return SDL_UpdateTexture(texture, rv, pixels, pitch);
    }
    
    // Lock Texture
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_LockTexture(IntPtr texture, SDL.Rect* rect, out IntPtr pixels, out int pitch);
    public static bool LockTexture(IntPtr texture, SDL.Rect? rect, out IntPtr pixels, out int pitch)
    {
        SDL.Rect r = rect.GetValueOrDefault();
        var rv = (rect.HasValue ? &r : null);
        
        return SDL_LockTexture(texture, rv, out pixels, out pitch);
    }
    
    // Unlock Texture
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_UnlockTexture(IntPtr texture);
    public static void UnlockTexture(IntPtr texture)
    {
        SDL_UnlockTexture(texture);
    }
    
    // Get Texture Properties
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern uint SDL_GetTextureProperties(IntPtr texture);
    private static uint GetTextureProperties(IntPtr texture)
    {
        return SDL_GetTextureProperties(texture);
    }
    
    // Get Texture Width
    public static int GetTextureWidth(IntPtr texture)
    {
        uint properties = GetTextureProperties(texture);
        return (int)GetNumberProperty(properties, Properties.PropertyTextureWidth, 0);
    }
    
    // Get Texture Height
    public static int GetTextureHeight(IntPtr texture)
    {
        uint properties = GetTextureProperties(texture);
        return (int)GetNumberProperty(properties, Properties.PropertyTextureHeight, 0);
    }
    
    // Get Texture Format
    public static SDL.PixelFormat GetTextureFormat(IntPtr texture)
    {
        uint properties = GetTextureProperties(texture);
        return (SDL.PixelFormat)(int)GetNumberProperty(properties, Properties.PropertyTextureFormat, 0);
    }
    
    // Get Texture Access
    public static SDL.TextureAccess GetTextureAccess(IntPtr texture)
    {
        uint properties = GetTextureProperties(texture);
        return (SDL.TextureAccess)(int)GetNumberProperty(properties, Properties.PropertyTextureAccess, 0);
    }
    
    // Get Texture Color Space
    public static SDL.ColorSpace GetTextureColorSpace(IntPtr texture)
    {
        uint properties = GetTextureProperties(texture);
        return (SDL.ColorSpace)(int)GetNumberProperty(properties, Properties.PropertyTextureColorSpace, 0);
    }
}