using System.Runtime.InteropServices;
using System;

namespace Hybrid
{
    public class PlatformIOS : Platform
    {
        public PlatformIOS(GameBehaviour gameBehaviour)
        {
            GameBehaviour = gameBehaviour;
        }

        internal override void Initialize()
        {
            // Platform
            SystemPlatform = SystemPlatform.iOS;
            
            // Resolve
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
            
            SDL.MainFunction method = Run;
            SDL.RunApp(0, IntPtr.Zero, method, IntPtr.Zero);
        }
        
        internal int Run(int argc, IntPtr argv)
        {
            GameBehaviour.Init();
            Initialized = true;
            IsRunning = true;

            while (IsRunning)
            {
                GameBehaviour.Update();
                GameBehaviour.Draw();
            }

            Dispose();
            return 0;
        }
    }
}