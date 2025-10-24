using System.Runtime.InteropServices;

namespace Hybrid
{
    public class PlatformAndroid : Platform
    {
        public PlatformAndroid(Game game)
        {
            Game = game;
        }
        
        internal override void Bootstrap()
        {
            PlatformType = PlatformType.Android;
            PlatformDevice = PlatformDevice.Mobile;
            
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