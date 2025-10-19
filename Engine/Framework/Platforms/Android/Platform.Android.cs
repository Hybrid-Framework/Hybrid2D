using System.Runtime.InteropServices;
using System;

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
            // Platform
            SystemPlatform = SystemPlatform.Android;
            
            // Resolve
            var assembly = typeof(SDL).Assembly;
            NativeLibrary.SetDllImportResolver(assembly, (library, asm, path) =>
            {
                return library switch
                {
                    "SDL3_image" => NativeLibrary.Load("libSDL3_image.so", asm, path),
                    "SDL3_mixer" => NativeLibrary.Load("libSDL3_mixer.so", asm, path),
                    "SDL3_ttf" => NativeLibrary.Load("libSDL3_ttf.so", asm, path),
                    "SDL3" => NativeLibrary.Load("libSDL3.so", asm, path),
                    _ => IntPtr.Zero
                };
            });
            
            Run();
        }

        internal void Run()
        {
            if (!Initialized)
            {
                GameBehaviour.Init();
                Initialized = true;
                IsRunning = true;
            }
            
            while (IsRunning)
            {
                GameBehaviour.Update();
                GameBehaviour.Draw();
            }
            
            Dispose();
        }
    }
}