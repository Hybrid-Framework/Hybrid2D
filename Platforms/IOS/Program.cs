using System;

public static class Program
{
    public static void Main()
    {
        using (var app = new Engine.Game("Hello", 800, 600, SDL2.SDL.SDL_WindowFlags.SDL_WINDOW_NOFLAGS))
        {
            while (app.Update())
            {
                
            }
        }
    }
}