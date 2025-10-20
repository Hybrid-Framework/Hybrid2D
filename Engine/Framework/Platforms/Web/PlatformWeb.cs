using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Hybrid
{
    public unsafe class PlatformWeb : Platform
    {
        public PlatformWeb(GameBehaviour gameBehaviour)
        {
            GameBehaviour = gameBehaviour;
        }
        
        internal override void Bootstrap()
        {
            SystemPlatform = SystemPlatform.Web;
            
            // Resolve
            var assembly = typeof(SDL).Assembly;
            NativeLibrary.SetDllImportResolver(assembly, (library, asm, path) =>
            {
                return library switch
                {
                    "SDL3_image" => NativeLibrary.Load("SDL3_image.a", asm, path),
                    "SDL3_mixer" => NativeLibrary.Load("SDL3_mixer.a", asm, path),
                    "SDL3_ttf" => NativeLibrary.Load("SDL3_ttf.a", asm, path),
                    "SDL3" => NativeLibrary.Load("SDL3.a", asm, path),
                    _ => IntPtr.Zero
                };
            });
            
            // Run
            Emscripten.SetMainLoop((IntPtr)(delegate* unmanaged[Cdecl] <void>)&Run, 0, false);
        }
        
        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        static void Run()
        {
            if (!Current.Initialized)
            {
                Current.GameBehaviour.Init();
                Current.Initialized = true;
                Current.IsRunning = true;
            }
            
            if (!Current.IsRunning)
            {
                Emscripten.CancelMainLoop();
                Current.Dispose();
                return;
            }
            
            Current.GameBehaviour.Update();
            Current.GameBehaviour.Draw();
        }
    }
}