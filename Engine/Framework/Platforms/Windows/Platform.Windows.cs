using System.Runtime.InteropServices;

namespace Hybrid
{
    public class PlatformWindows : Platform
    {
        public PlatformWindows(GameBehaviour gameBehaviour)
        {
            GameBehaviour = gameBehaviour;
        }
        
        internal override void Bootstrap()
        {
            // Platform
            SystemPlatform = SystemPlatform.Windows;
            
            // Resolve
            var assembly = typeof(SDL).Assembly;
            NativeLibrary.SetDllImportResolver(assembly, (library, asm, path) =>
            {
                return library switch
                {
                    "SDL3_image" => NativeLibrary.Load("SDL3_image.dll", asm, path),
                    "SDL3_mixer" => NativeLibrary.Load("SDL3_mixer.dll", asm, path),
                    "SDL3_ttf" => NativeLibrary.Load("SDL3_ttf.dll", asm, path),
                    "SDL3" => NativeLibrary.Load("SDL3.dll", asm, path),
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