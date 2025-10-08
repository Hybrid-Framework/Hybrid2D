using System.Runtime.InteropServices;
using Hybrid.Platforms;
using Hybrid;
using App;

public static class Program
{
    public static void Main(string[] args)
    {
        var assembly = typeof(SDL).Assembly;

        NativeLibrary.SetDllImportResolver(assembly, (library, asm, path) =>
        {
            return library switch
            {
                "SDL3_image" => NativeLibrary.Load("@rpath/SDL3_image.framework/SDL3_image", asm, path),
                "SDL3_mixer" => NativeLibrary.Load("@rpath/SDL3_mixer.framework/SDL3_mixer", asm, path),
                "SDL3_ttf" => NativeLibrary.Load("@rpath/SDL3_ttf.framework/SDL3_ttf", asm, path),
                "SDL3" => NativeLibrary.Load("@rpath/SDL3.framework/SDL3", asm, path),
                _ => IntPtr.Zero
            };
        });

        SDL.MainFunction entry = Entry;
        SDL.RunApp(0, IntPtr.Zero, entry, IntPtr.Zero);
    }

    private static int Entry(int argc, IntPtr argv)
    {
        Platform.Create(new PlatformIOS(new Game()));
        Platform.Current.Run();
        return 0;
    }
}