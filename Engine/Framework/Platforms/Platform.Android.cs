using System.Runtime.InteropServices;

namespace Hybrid
{
    public class PlatformAndroid : Platform
    {
        public PlatformAndroid(GameBehaviour gameBehaviour)
        {
            GameBehaviour = gameBehaviour;
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
            
            SDL.Init(SDL.InitFlags.Everything);
            SDL_mixer.Init();
            SDL_image.Init();
            SDL_ttf.Init();
            
            Run();
        }

        internal static void Run()
        {
            Current?.Initialize();
            
            while (IsRunning)
            {
                Current?.MainLoop();
            }
            
            Current?.Quit();
        }
    }
}