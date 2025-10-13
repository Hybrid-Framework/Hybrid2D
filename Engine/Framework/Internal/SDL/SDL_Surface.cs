using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    // Create Surface
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Surface* SDL_CreateSurface(int w, int h, SDL.PixelFormat format);
    public static SDL.Surface* CreateSurface(int w, int h, SDL.PixelFormat format)
    {
        return SDL_CreateSurface(w, h, format);
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
}