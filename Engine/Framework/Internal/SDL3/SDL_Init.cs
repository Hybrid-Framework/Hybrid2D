using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    // Library
    private const string library = "SDL3";
    
    
    // Init
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern SDL.Bool SDL_Init(InitFlags flags);
    internal static bool Init(InitFlags flags)
    {
        return SDL_Init(flags);
    }

    // Quit
    [DllImport(library, CallingConvention = CallingConvention.Cdecl)]
    private static extern void SDL_Quit();
    internal static void Quit()
    {
        SDL_Quit();
    }
    
    // Initialize
    internal static void Initialize()
    {
        SDL.SetHint(SDL.SDL_HINT_MAIN_CALLBACK_RATE, "0");
        SDL.SetMainReady();
        
        if (!SDL.Init(SDL.InitFlags.Everything))
        {
            throw new Exception(SDL.GetError());
        }

        if (!SDL_mixer.Init())
        {
            throw new Exception(SDL.GetError());
        }

        if (!SDL_image.Init())
        {
            throw new Exception(SDL.GetError());
        }

        if (!SDL_ttf.Init())
        {
            throw new Exception(SDL.GetError());
        }
    }
}