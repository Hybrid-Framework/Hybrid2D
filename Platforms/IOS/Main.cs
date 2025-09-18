using System.Runtime.InteropServices;
using Engine.Platforms;
using Engine;
using App;

public static class Program
{
    public static void Main(string[] args)
    {
        var assembly = typeof(Engine.SDL2.SDL).Assembly;

        NativeLibrary.SetDllImportResolver(assembly, (library, asm, path) =>
        {
            return library switch
            {
                "SDL2_image" => NativeLibrary.Load("@rpath/SDL2_image.framework/SDL2_image", asm, path),
                "SDL2_mixer" => NativeLibrary.Load("@rpath/SDL2_mixer.framework/SDL2_mixer", asm, path),
                "SDL2_ttf" => NativeLibrary.Load("@rpath/SDL2_ttf.framework/SDL2_ttf", asm, path),
                "SDL2" => NativeLibrary.Load("@rpath/SDL2.framework/SDL2", asm, path),
                _ => IntPtr.Zero
            };
        });

        Engine.SDL2.SDL.SDL_main_func entry = Entry;
        Engine.SDL2.SDL.SDL_UIKitRunApp(0, IntPtr.Zero, entry);
    }

    private static int Entry(int argc, IntPtr argv)
    {
        Platform.Create(new PlatformIOS(new Game()));
        Platform.Current.Run();
        return 0;
    }
}