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
}