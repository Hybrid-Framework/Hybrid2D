using System.Runtime.InteropServices;

namespace Hybrid
{
    internal class PlatformIOS : Platform
    {
        internal override void Bootstrap()
        {
            PlatformType = PlatformType.iOS;
            PlatformDevice = PlatformDevice.Mobile;
            
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
            
            SDL.Initialize();
            SDL.MainFunction main = Run;
            SDL.RunApp(0, IntPtr.Zero, main, IntPtr.Zero);
        }
        
        internal static int Run(int argc, IntPtr argv)
        {
            Engine.Initialize();
            
            while (Engine.IsRunning)
            {
                Engine.MainLoop();
            }

            Engine.Quit();
            return 0;
        }
    }
}