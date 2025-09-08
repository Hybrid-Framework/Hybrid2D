using System.Runtime.InteropServices.JavaScript;
using Engine;

public static partial class Program
{
    [JSImport("setMainLoop", "main.js")]
    private static partial void SetMainLoop([JSMarshalAs<JSType.Function>] Action cb);
    private static Game? Game = null;
    private static void Main() { }

    [JSExport]
    private static void Entry()
    {
        if (Game == null)
        {
            Game = new Game($"Hello", 1280, 768, SDL2.SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN);
        }
        else
        {
            if (!Game.Update())
            {
                Game.Dispose();
                Game = null;
            }
        }
    }
}