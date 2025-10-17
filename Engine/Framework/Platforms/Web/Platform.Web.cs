using System;
using System.Runtime.InteropServices;

namespace Hybrid.Platforms
{
    public class PlatformWeb : Platform
    {
        public PlatformWeb(Behaviour behaviour) => Behaviour = behaviour;
        public override Behaviour Behaviour { get; set; }

        public override void Init()
        {
            var assembly = typeof(SDL).Assembly;

            NativeLibrary.SetDllImportResolver(assembly, (library, asm, path) =>
            {
                return library switch
                {
                    "SDL3_image" => NativeLibrary.Load("SDL3_image", asm, path),
                    "SDL3_mixer" => NativeLibrary.Load("SDL3_mixer", asm, path),
                    "SDL3_ttf" => NativeLibrary.Load("SDL3_ttf", asm, path),
                    "SDL3" => NativeLibrary.Load("SDL3", asm, path),
                    _ => IntPtr.Zero
                };
            });
            
            // Init
            Behaviour.Init();
        }
        
        public override void Run()
        {
            // Main Loop
            if (IsRunning)
            {
                // Loop
                Behaviour.Update();
                Behaviour.Render();
            }
            else
            {
                // Dispose
                Dispose();
            }
        }
    }
}