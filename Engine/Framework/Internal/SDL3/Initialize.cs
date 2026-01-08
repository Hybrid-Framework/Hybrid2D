using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    public static void Initialize()
    {
        SDL.SetHint(SDL.SDL_HINT_MAIN_CALLBACK_RATE, "0");
        
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