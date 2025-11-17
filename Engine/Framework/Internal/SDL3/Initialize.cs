using System.Runtime.InteropServices;

internal static unsafe partial class SDL
{
    public static void Initialize()
    {
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