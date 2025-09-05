using System.Runtime.InteropServices;
using SDL2;

public static class Program
{
    public static void Main(string[] args)
    {
        var assembly = typeof(SDL).Assembly;

        NativeLibrary.SetDllImportResolver(assembly, (libraryName, asm, path) =>
        {
            return libraryName switch
            {
                "SDL2" => NativeLibrary.Load("@rpath/SDL2.framework/SDL2", asm, path),
                "SDL2_image" => NativeLibrary.Load("@rpath/SDL2_image.framework/SDL2_image", asm, path),
                "SDL2_mixer" => NativeLibrary.Load("@rpath/SDL2_mixer.framework/SDL2_mixer", asm, path),
                "SDL2_ttf" => NativeLibrary.Load("@rpath/SDL2_ttf.framework/SDL2_ttf", asm, path),
                _ => IntPtr.Zero
            };
        });

        SDL.SDL_main_func mainFunc = Entry;
        SDL.SDL_UIKitRunApp(0, IntPtr.Zero, mainFunc);
    }

    private static int Entry(int argc, IntPtr argv)
    {
        using var app = new Engine.Tests("Hello", 800, 600, SDL.SDL_WindowFlags.SDL_WINDOW_FULLSCREEN | SDL.SDL_WindowFlags.SDL_WINDOW_RESIZABLE);

        while (app.Update())
        {
            // Game loop
        }

        return 0;
    }
}