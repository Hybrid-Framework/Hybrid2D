using static Engine.Internal.SDL2.SDL;
using System;

public static class Program
{
    public static void Main()
    {
        using (var app = new Engine.Game("Hello", 800, 600, SDL_WindowFlags.SDL_WINDOW_SHOWN))
        {
            while (app.Update())
            {
                
            }
        }
    }
}