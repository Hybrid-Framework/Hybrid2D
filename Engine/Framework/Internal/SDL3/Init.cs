using System;

public static unsafe partial class SDL
{
    public static void Initialize()
    {
        if (!Init(InitFlags.Everything))
        {
            throw new Exception(GetError());
        }

        if (!SDL_image.Init())
        {
            throw new Exception(GetError());
        }

        if (!SDL_mixer.Init())
        {
            throw new Exception(GetError());
        }

        if (!SDL_ttf.Init())
        {
            throw new Exception(GetError());
        }
    }
}