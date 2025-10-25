using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    // Create Texture
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Texture* SDL_CreateTexture(SDL.Renderer* renderer, SDL.PixelFormat format, SDL.TextureAccess access, int w, int h);
    public static SDL.Texture* CreateTexture(SDL.Renderer* renderer, SDL.PixelFormat format, SDL.TextureAccess access, int w, int h)
    {
        var texture = SDL_CreateTexture(renderer, format, access, w, h);
        SDL.SetTextureScaleMode(texture, ScaleMode.Pixel);
        return texture;
    }
    
    // Create Texture With Properties
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Texture* SDL_CreateTextureWithProperties(SDL.Renderer* renderer, uint properties);
    public static SDL.Texture* CreateTextureWithProperties(SDL.Renderer* renderer, uint properties)
    {
        var texture = SDL_CreateTextureWithProperties(renderer, properties);
        SDL.SetTextureScaleMode(texture, ScaleMode.Pixel);
        return texture;
    }
    
    // Create Texture From Surface
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Texture* SDL_CreateTextureFromSurface(SDL.Renderer* renderer, SDL.Surface* surface);
    public static SDL.Texture* CreateTextureFromSurface(SDL.Renderer* renderer, SDL.Surface* surface)
    {
        var texture = SDL_CreateTextureFromSurface(renderer, surface);
        SDL.SetTextureScaleMode(texture, ScaleMode.Pixel);
        return texture;
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
    private static extern SDL.Bool SDL_RenderTexture(SDL.Renderer* renderer, SDL.Texture* texture, SDL.FRect* src, SDL.FRect* dst);
    public static bool RenderTexture(SDL.Renderer* renderer, SDL.Texture* texture, SDL.FRect? src, SDL.FRect? dst)
    {
        SDL.FRect s = src.GetValueOrDefault();
        var sv = (src.HasValue ? &s : null);
        
        SDL.FRect d = dst.GetValueOrDefault();
        var dv = (dst.HasValue ? &d : null);
        
        return SDL_RenderTexture(renderer, texture, sv, dv);
    }
    
    // Render Texture Rotated
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderTextureRotated(SDL.Renderer* renderer, SDL.Texture* texture, SDL.FRect* src, SDL.FRect* dst, double angle, SDL.FPoint* center, SDL.FlipMode flip);
    public static bool RenderTextureRotated(SDL.Renderer* renderer, SDL.Texture* texture, SDL.FRect? src, SDL.FRect? dst, double angle, SDL.FPoint? center, SDL.FlipMode flip)
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
    private static extern SDL.Bool SDL_RenderTextureAffine(SDL.Renderer* renderer, SDL.Texture* texture, SDL.FRect* src, SDL.FPoint* origin, SDL.FPoint* right, SDL.FPoint* down);
    public static bool RenderTextureAffine(SDL.Renderer* renderer, SDL.Texture* texture, SDL.FRect? src, SDL.FPoint? origin, SDL.FPoint? right, SDL.FPoint? down)
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
    private static extern SDL.Bool SDL_RenderTextureTiled(SDL.Renderer* renderer, SDL.Texture* texture, SDL.FRect* src, float scale, SDL.FRect* dst);
    public static bool RenderTextureTiled(SDL.Renderer* renderer, SDL.Texture* texture, SDL.FRect? src, float scale, SDL.FRect? dst)
    {
        SDL.FRect s = src.GetValueOrDefault();
        var sv = (src.HasValue ? &s : null);
        
        SDL.FRect d = dst.GetValueOrDefault();
        var dv = (dst.HasValue ? &d : null);
        
        return SDL_RenderTextureTiled(renderer, texture, sv, scale, dv);
    }
    
    // Render Texture 9 Grid
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderTexture9Grid(SDL.Renderer* renderer, SDL.Texture* texture, SDL.FRect* src, float leftWidth, float rightWidth, float topHeight, float bottomHeight, float scale, SDL.FRect* dst);
    public static bool RenderTexture9Grid(SDL.Renderer* renderer, SDL.Texture* texture, SDL.FRect? src, float leftWidth, float rightWidth, float topHeight, float bottomHeight, float scale, SDL.FRect? dst)
    {
        SDL.FRect s = src.GetValueOrDefault();
        var sv = (src.HasValue ? &s : null);
        
        SDL.FRect d = dst.GetValueOrDefault();
        var dv = (dst.HasValue ? &d : null);

        return SDL_RenderTexture9Grid(renderer, texture, sv, leftWidth, rightWidth, topHeight, bottomHeight, scale, dv);
    }
    
    // Render Texture 9 Grid Tiled
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_RenderTexture9GridTiled(SDL.Renderer* renderer, SDL.Texture* texture, SDL.FRect* src, float leftWidth, float rightWidth, float topHeight, float bottomHeight, float scale, SDL.FRect* dst, float tileScale);
    public static bool RenderTexture9GridTiled(SDL.Renderer* renderer, SDL.Texture* texture, SDL.FRect? src, float leftWidth, float rightWidth, float topHeight, float bottomHeight, float scale, SDL.FRect? dst, float tileScale)
    {
        SDL.FRect s = src.GetValueOrDefault();
        var sv = (src.HasValue ? &s : null);
        
        SDL.FRect d = dst.GetValueOrDefault();
        var dv = (dst.HasValue ? &d : null);

        return SDL_RenderTexture9GridTiled(renderer, texture, sv, leftWidth, rightWidth, topHeight, bottomHeight, scale, dv, tileScale);
    }
    
    // Update Texture
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_UpdateTexture(SDL.Texture* texture, SDL.Rect* rect, IntPtr pixels, int pitch);
    public static bool UpdateTexture(SDL.Texture* texture, SDL.Rect? rect, IntPtr pixels, int pitch)
    {
        SDL.Rect r = rect.GetValueOrDefault();
        var rv = (rect.HasValue ? &r : null);
        
        return SDL_UpdateTexture(texture, rv, pixels, pitch);
    }
    
    // Lock Texture
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_LockTexture(SDL.Texture* texture, SDL.Rect* rect, out IntPtr pixels, out int pitch);
    public static bool LockTexture(SDL.Texture* texture, SDL.Rect? rect, out IntPtr pixels, out int pitch)
    {
        SDL.Rect r = rect.GetValueOrDefault();
        var rv = (rect.HasValue ? &r : null);
        
        return SDL_LockTexture(texture, rv, out pixels, out pitch);
    }
    
    // Unlock Texture
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_UnlockTexture(SDL.Texture* texture);
    public static void UnlockTexture(SDL.Texture* texture)
    {
        SDL_UnlockTexture(texture);
    }
    
    // Get Texture Properties
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern uint SDL_GetTextureProperties(SDL.Texture* texture);
    public static uint GetTextureProperties(SDL.Texture* texture)
    {
        return SDL_GetTextureProperties(texture);
    }
    
    // Get Texture Width
    public static int GetTextureWidth(SDL.Texture* texture)
    {
        uint properties = GetTextureProperties(texture);
        return (int)GetNumberProperty(properties, Properties.Texture_Width, -1);
    }
    
    // Get Texture Height
    public static int GetTextureHeight(SDL.Texture* texture)
    {
        uint properties = GetTextureProperties(texture);
        return (int)GetNumberProperty(properties, Properties.Texture_Height, -1);
    }
    
    // Get Texture Format
    public static SDL.PixelFormat GetTextureFormat(SDL.Texture* texture)
    {
        uint properties = GetTextureProperties(texture);
        return (SDL.PixelFormat)GetNumberProperty(properties, Properties.Texture_Format, -1);
    }
    
    // Get Texture Access
    public static SDL.TextureAccess GetTextureAccess(SDL.Texture* texture)
    {
        uint properties = GetTextureProperties(texture);
        return (SDL.TextureAccess)GetNumberProperty(properties, Properties.Texture_Access, -1);
    }
    
    // Get Texture Color Space
    public static SDL.ColorSpace GetTextureColorSpace(SDL.Texture* texture)
    {
        uint properties = GetTextureProperties(texture);
        return (SDL.ColorSpace)GetNumberProperty(properties, Properties.Texture_ColorSpace, -1);
    }
}