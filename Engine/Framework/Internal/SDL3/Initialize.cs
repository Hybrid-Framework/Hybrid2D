using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    public static void Initialize()
    {
        SDL.SetHint(SDL.SDL_HINT_WINDOWS_RAW_KEYBOARD, "1");
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