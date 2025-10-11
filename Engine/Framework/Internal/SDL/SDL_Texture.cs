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
    
    // Destroy Texture
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_DestroyTexture(IntPtr texture);
    public static void DestroyTexture(IntPtr texture)
    {
        SDL_DestroyTexture(texture);
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
    
    // Get Texture Properties
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern uint SDL_GetTextureProperties(IntPtr texture);
    public static (int w, int h, PixelFormat format, TextureAccess access) GetTextureProperties(IntPtr texture)
    {
        var width = GetTextureWidth(texture);
        var height = GetTextureHeight(texture);
        var format = GetTextureFormat(texture);
        var access = GetTextureAccess(texture);
        return (width, height, format, access);
    }
    
    // Get Texture Width
    public static int GetTextureWidth(IntPtr texture)
    {
        return (int)GetNumberProperty(SDL_GetTextureProperties(texture), "SDL.texture.width");
    }
    
    // Get Texture Height
    public static int GetTextureHeight(IntPtr texture)
    {
        return (int)GetNumberProperty(SDL_GetTextureProperties(texture), "SDL.texture.height");
    }
    
    // Get Texture Format
    public static PixelFormat GetTextureFormat(IntPtr texture)
    {
        return (PixelFormat)GetNumberProperty(SDL_GetTextureProperties(texture), "SDL.texture.format");
    }
    
    // Get Texture Access
    public static TextureAccess GetTextureAccess(IntPtr texture)
    {
        return (TextureAccess)GetNumberProperty(SDL_GetTextureProperties(texture), "SDL.texture.access");
    }
    
    // Update Texture
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_UpdateTexture(IntPtr texture, SDL.Rect* rect, IntPtr pixels, int pitch);
    public static bool UpdateTexture(IntPtr texture, SDL.Rect* rect, IntPtr pixels, int pitch)
    {
        return SDL_UpdateTexture(texture, rect, pixels, pitch);
    }
    
    // Lock Texture
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_LockTexture(IntPtr texture, SDL.Rect* rect, out IntPtr pixels, out int pitch);
    public static bool LockTexture(IntPtr texture, SDL.Rect* rect, out IntPtr pixels, out int pitch)
    {
        return SDL_LockTexture(texture, rect, out pixels, out pitch);
    }
    
    // Unlock Texture
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_UnlockTexture(IntPtr texture);
    public static void UnlockTexture(IntPtr texture)
    {
        SDL_UnlockTexture(texture);
    }
    
    // Set Texture Pixels
    public static void SetTexturePixels(IntPtr texture, SDL.Pixel[] pixels)
    {
        int width = GetTextureWidth(texture);
        int height = GetTextureHeight(texture);
        byte[] buffer = new byte[width * height * 4];

        foreach (var p in pixels)
        {
            if (p.x < 0 || p.x >= width || p.y < 0 || p.y >= height)
            {
                continue;
            }

            int index = (p.y * width + p.x) * 4;
            buffer[index + 0] = p.a;
            buffer[index + 1] = p.r;
            buffer[index + 2] = p.g;
            buffer[index + 3] = p.b;
        }

        fixed (byte* ptr = buffer)
        {
            SDL.UpdateTexture(texture, null, (IntPtr)ptr, width * 4);
        }
    }
    
    // Set Texture Pixel
    public static void SetTexturePixel(IntPtr texture, SDL.Pixel pixel)
    {
        int width = GetTextureWidth(texture);
        int height = GetTextureHeight(texture);
        
        if (pixel.x < 0 || pixel.x >= width || pixel.y < 0 || pixel.y >= height)
        {
            return;
        }

        SDL.Rect rect = new SDL.Rect { x = pixel.x, y = pixel.y, w = 1, h = 1 };
        byte[] buffer = new byte[4] { pixel.a, pixel.r, pixel.g, pixel.b };

        fixed (byte* ptr = buffer)
        {
            SDL.UpdateTexture(texture, &rect, (IntPtr)ptr, 1 * 4);
        }
    }
}