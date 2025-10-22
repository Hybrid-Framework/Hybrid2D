using System.Runtime.InteropServices;

namespace Hybrid
{
    public class PlatformIOS : Platform
    {
        public PlatformIOS(GameBehaviour gameBehaviour)
        {
            GameBehaviour = gameBehaviour;
        }

        internal override void Bootstrap()
        {
            SystemPlatform = SystemPlatform.iOS;
            SystemDevice = SystemDevice.Mobile;
            
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
            
            SDL.Init(SDL.InitFlags.Everything);
            SDL_mixer.Init();
            SDL_image.Init();
            SDL_ttf.Init();
            
            SDL.MainFunction main = Run;
            SDL.RunApp(0, IntPtr.Zero, main, IntPtr.Zero);
        }
        
        internal static int Run(int argc, IntPtr argv)
        {
            Current?.Initialize();
            
            while (IsRunning)
            {
                Current?.MainLoop();
            }

            Current?.Quit();
            return 0;
        }
    }
}