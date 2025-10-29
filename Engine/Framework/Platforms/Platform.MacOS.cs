using System.Runtime.InteropServices;

namespace Hybrid
{
    internal class PlatformMacOS : Platform
    {
        internal override void Bootstrap()
        {
            PlatformType = PlatformType.MacOS;
            PlatformDevice = PlatformDevice.Desktop;
            
            var assembly = typeof(SDL).Assembly;
            NativeLibrary.SetDllImportResolver(assembly, (library, asm, path) =>
            {
                return library switch
                {
                    "SDL3_image" => IntPtr.Zero,
                    "SDL3_mixer" => IntPtr.Zero,
                    "SDL3_ttf"   => IntPtr.Zero,
                    "SDL3"       => IntPtr.Zero,
                    _            => IntPtr.Zero
                };
            });
            
            SDL.Initialize();
            Run();
        }

        internal static void Run()
        {
            Engine.Initialize();
            
            while (Engine.IsRunning)
            {
                Engine.MainLoop();
            }
            
            Engine.Quit();
        }
    }
}