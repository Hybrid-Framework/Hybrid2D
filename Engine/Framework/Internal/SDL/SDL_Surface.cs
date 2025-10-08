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
    
    // Create Surface From
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_CreateSurfaceFrom(int w, int h, SDL.PixelFormat format, IntPtr pixels, int pitch);
    public static IntPtr CreateSurfaceFrom(int w, int h, SDL.PixelFormat format, IntPtr pixels, int pitch)
    {
        return SDL_CreateSurfaceFrom(w, h, format, pixels, pitch);
    }
    
    // Destroy Surface
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_DestroySurface(IntPtr surface);
    public static void DestroySurface(IntPtr surface)
    {
        SDL_DestroySurface(surface);
    }
    
    // Flip Surface
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_FlipSurface(IntPtr surface, SDL.FlipMode mode);
    public static void FlipSurface(IntPtr surface, SDL.FlipMode mode)
    {
        SDL_FlipSurface(surface, mode);
    }
    
    // Duplicate Surface
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_DuplicateSurface(IntPtr surface);
    public static IntPtr DuplicateSurface(IntPtr surface)
    {
        return SDL_DuplicateSurface(surface);
    }
    
    // Scale Surface
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_ScaleSurface(IntPtr surface, int w, int h, SDL.ScaleMode mode);
    public static IntPtr ScaleSurface(IntPtr surface, int w, int h, SDL.ScaleMode mode)
    {
        return SDL_ScaleSurface(surface, w, h, mode);
    }
    
    // Convert Surface
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern IntPtr SDL_ConvertSurface(IntPtr surface, SDL.PixelFormat format);
    public static IntPtr ConvertSurface(IntPtr surface, SDL.PixelFormat format)
    {
        return SDL_ConvertSurface(surface, format);
    }
    
    // Clear Surface
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_ClearSurface(IntPtr surface, float r, float g, float b, float a);
    public static void ClearSurface(IntPtr surface, byte r, byte g, byte b, byte a)
    {
        SDL_ClearSurface(surface, (r / 255f), (g / 255f), (b / 255f), (a / 255f));
    }
    
    // Blit Surface
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_BlitSurface(IntPtr surfaceA, SDL.Rect* rectA, IntPtr surfaceB, SDL.Rect* rectB);
    public static void BlitSurface(IntPtr surfaceA, SDL.Rect rectA, IntPtr surfaceB, SDL.Rect rectB)
    {
        SDL_BlitSurface(surfaceA, &rectA, surfaceB, &rectB);
    }
    
    // Lock Surface
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_LockSurface(IntPtr surface);
    public static void LockSurface(IntPtr surface)
    {
        SDL_LockSurface(surface);
    }
    
    // Unlock Surface
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_UnlockSurface(IntPtr surface);
    public static void UnlockSurface(IntPtr surface)
    {
        SDL_UnlockSurface(surface);
    }
    
    // Set Surface Color Mod
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetSurfaceColorMod(IntPtr surface, byte r, byte g, byte b);
    public static void SetSurfaceColorMod(IntPtr surface, byte r, byte g, byte b)
    {
        SDL_SetSurfaceColorMod(surface, r, g, b);
    }
    
    // Get Surface Color Mod
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetSurfaceColorMod(IntPtr surface, out byte r, out byte g, out byte b);
    public static (byte r, byte g, byte b) GetSurfaceColorMod(IntPtr surface)
    {
        SDL_GetSurfaceColorMod(surface, out byte r, out byte g, out byte b);
        return (r, g, b);
    }
    
    // Set Surface Alpha Mod
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetSurfaceAlphaMod(IntPtr surface, byte alpha);
    public static void SetSurfaceAlphaMod(IntPtr surface, byte alpha)
    {
        SDL_SetSurfaceAlphaMod(surface, alpha);
    }
    
    // Get Surface Alpha Mod
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetSurfaceAlphaMod(IntPtr surface, out byte alpha);
    public static byte GetSurfaceAlphaMod(IntPtr surface)
    {
        SDL_GetSurfaceAlphaMod(surface, out byte alpha);
        return alpha;
    }
    
    // Set Surface Blend Mode
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetSurfaceBlendMode(IntPtr surface, SDL.BlendMode mode);
    public static void SetSurfaceBlendMode(IntPtr surface, SDL.BlendMode mode)
    {
        SDL_SetSurfaceBlendMode(surface, mode);
    }
    
    // Get Surface Blend Mode
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetSurfaceBlendMode(IntPtr surface, out SDL.BlendMode mode);
    public static SDL.BlendMode GetSurfaceBlendMode(IntPtr surface)
    {
        SDL_GetSurfaceBlendMode(surface, out SDL.BlendMode mode);
        return mode;
    }
    
    // Set Surface Clip Rect
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_SetSurfaceClipRect(IntPtr surface, SDL.Rect* rect);
    public static void SetSurfaceClipRect(IntPtr surface, SDL.Rect rect)
    {
        SDL_SetSurfaceClipRect(surface, &rect);
    }
    
    // Get Surface Clip Rect
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_GetSurfaceClipRect(IntPtr surface, out SDL.Rect rect);
    public static SDL.Rect GetSurfaceClipRect(IntPtr surface)
    {
        SDL_GetSurfaceClipRect(surface, out SDL.Rect rect);
        return rect;
    }
}