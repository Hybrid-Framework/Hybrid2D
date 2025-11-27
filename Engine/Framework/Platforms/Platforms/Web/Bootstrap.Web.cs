using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Hybrid
{
    internal unsafe class WebBootstrap : Bootstrap
    {
        protected override Platform CreatePlatform()
        {
            return new WebPlatform();
        }
        
        protected override void Execute()
        {
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
            SDL.SetHint(SDL.SDL_HINT_EMSCRIPTEN_FILL_DOCUMENT, "1");
            Emscripten.SetMainLoop((IntPtr)(delegate* unmanaged[Cdecl]<void>)&Run, 0, false);
        }
        
        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        protected static void Run()
        {
            Emscripten.SetMainLoopTiming(Emscripten.Mode.RequestFrameAnimation, 1);
            Engine.Instance.StartMainLoop();
            
            if (Engine.Instance.IsRunning)
            {
                Engine.Instance.MainLoop();
                return;
            }
            
            Emscripten.CancelMainLoop();
            Engine.Instance.Quit();
        }
    }
}