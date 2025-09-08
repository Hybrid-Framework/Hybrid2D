using System.Runtime.InteropServices;
using SDL2;

public static class Program
{
    public static void Main(string[] args)
    {
        NativeLibrary.SetDllImportResolver(typeof(SDL).Assembly, (_, assembly, path) => NativeLibrary.Load("@rpath/SDL2.framework/SDL2", assembly, path));

        SDL.SDL_main_func entry = Entry;
        SDL.SDL_UIKitRunApp(0, IntPtr.Zero, entry);
    }

    private static int Entry(int argc, IntPtr argv)
    {
        using var app = new Engine.Game("Hello", 800, 600, SDL.SDL_WindowFlags.SDL_WINDOW_FULLSCREEN | SDL.SDL_WindowFlags.SDL_WINDOW_RESIZABLE);

        while (app.Update())
        {
            // Game loop
        }

        return 0;
    }
}