using System.Runtime.InteropServices;
using static Engine.Internal.SDL2.SDL;

public static class Program
{
    public static void Main(string[] args)
    {
        var assembly = typeof(Engine.Internal.SDL2.SDL).Assembly;

        NativeLibrary.SetDllImportResolver(assembly, (library, asm, path) =>
        {
            return library switch
            {
                "SDL2_mixer" => NativeLibrary.Load("@rpath/SDL2_mixer.framework/SDL2_mixer", asm, path),
                "SDL2" => NativeLibrary.Load("@rpath/SDL2.framework/SDL2", asm, path),
                _ => IntPtr.Zero
            };
        });

        SDL_main_func entry = Entry;
        SDL_UIKitRunApp(0, IntPtr.Zero, entry);
    }

    private static int Entry(int argc, IntPtr argv)
    {
        using var app = new Engine.Game("Hello", 800, 600, SDL_WindowFlags.SDL_WINDOW_FULLSCREEN | SDL_WindowFlags.SDL_WINDOW_RESIZABLE);

        while (app.Update())
        {
            // Game loop
        }

        return 0;
    }
}