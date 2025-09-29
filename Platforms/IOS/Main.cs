using System.Runtime.InteropServices;
using Hybrid.Platforms;
using Hybrid;
using App;

public static class Program
{
    public static void Main(string[] args)
    {
        var assembly = typeof(Hybrid.SDL2.SDL).Assembly;

        NativeLibrary.SetDllImportResolver(assembly, (library, asm, path) =>
        {
            return library switch
            {
                "IMAGE" => NativeLibrary.Load("@rpath/IMAGE.framework/IMAGE", asm, path),
                "MIXER" => NativeLibrary.Load("@rpath/MIXER.framework/MIXER", asm, path),
                "SDL2" => NativeLibrary.Load("@rpath/SDL2.framework/SDL2", asm, path),
                "TTF" => NativeLibrary.Load("@rpath/TTF.framework/TTF", asm, path),
                _ => IntPtr.Zero
            };
        });

        // Hybrid.SDL2.SDL.SDL_main_func entry = Entry;
        // Hybrid.SDL2.SDL.SDL_UIKitRunApp(0, IntPtr.Zero, entry);
    }

    private static int Entry(int argc, IntPtr argv)
    {
        Platform.Create(new PlatformIOS(new Game()));
        Platform.Current.Run();
        return 0;
    }
}