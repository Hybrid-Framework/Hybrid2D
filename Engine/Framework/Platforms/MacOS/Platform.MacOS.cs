using System.Runtime.InteropServices;

namespace Hybrid
{
    public class PlatformMacOS : Platform
    {
        public PlatformMacOS(GameBehaviour gameBehaviour)
        {
            GameBehaviour = gameBehaviour;
        }
        
        internal override void Bootstrap()
        {
            // Platform
            SystemPlatform = SystemPlatform.MacOS;
            
            // Resolve
            var assembly = typeof(SDL).Assembly;
            NativeLibrary.SetDllImportResolver(assembly, (library, asm, path) =>
            {
                return library switch
                {
                    "SDL3_image" => NativeLibrary.Load("libSDL3_image.dylib", asm, path),
                    "SDL3_mixer" => NativeLibrary.Load("libSDL3_mixer.dylib", asm, path),
                    "SDL3_ttf" => NativeLibrary.Load("libSDL3_ttf.dylib", asm, path),
                    "SDL3" => NativeLibrary.Load("libSDL3.dylib", asm, path),
                    _ => IntPtr.Zero
                };
            });
            
            Run();
        }

        static void Run()
        {
            if (!Current.Initialized)
            {
                Current.GameBehaviour.Init();
                Current.Initialized = true;
                Current.IsRunning = true;
            }
            
            while (Current.IsRunning)
            {
                Current.GameBehaviour.Update();
                Current.GameBehaviour.Draw();
            }
            
            Current.Dispose();
        }
    }
}