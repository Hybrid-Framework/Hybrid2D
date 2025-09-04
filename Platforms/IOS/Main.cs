using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using SDL2;

public static class Program
{
    // Entry point
    public static void Main(string[] args)
    {
        // Ensure P/Invoke can find SDL2.framework inside the app bundle
        NativeLibrary.SetDllImportResolver(typeof(SDL).Assembly, (_, assembly, path) => NativeLibrary.Load("@rpath/SDL2.framework/SDL2", assembly, path));

        // Create the delegate
        SDL.SDL_main_func mainFunc = Entry;

        // Run the SDL iOS app
        SDL.SDL_UIKitRunApp(0, IntPtr.Zero, mainFunc);
    }

    private static int Entry(int argc, IntPtr argv)
    {
        using var app = new Engine.Game("Hello", 800, 600, SDL2.SDL.SDL_WindowFlags.SDL_WINDOW_FULLSCREEN);

        while (app.Update())
        {
            // Game loop
        }

        return 0;
    }
}