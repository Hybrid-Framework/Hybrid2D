using System.Runtime.InteropServices;

namespace Hybrid
{
    public class PlatformLinux : Platform
    {
        public PlatformLinux(Game game)
        {
            Game = game;
        }
        
        internal override void Bootstrap()
        {
            PlatformType = PlatformType.Linux;
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
            Current.Initialize();
            
            while (Current.IsRunning)
            {
                Current.MainLoop();
            }
            
            Current.Quit();
        }
    }
}