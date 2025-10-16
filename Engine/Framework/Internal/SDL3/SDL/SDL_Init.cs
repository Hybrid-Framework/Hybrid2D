using System.Runtime.InteropServices;

public static unsafe partial class SDL
{
    // Init
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_Init(InitFlags flags);
    public static bool Init(InitFlags flags)
    {
        return SDL_Init(flags);
    }
    
    // Quit
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_Quit();
    public static void Quit()
    {
        SDL_Quit();
    }
}