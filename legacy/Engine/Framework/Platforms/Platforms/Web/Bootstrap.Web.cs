using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System;

namespace Hybrid
{
    internal unsafe class WebBootstrap : Bootstrap
    {
        protected override void Execute(Config config)
        {
            Platform.SetPlatform(new WebPlatform(), config);
            
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
            Emscripten.SetMainLoop((IntPtr)(delegate* unmanaged[Cdecl]<void>)&Run, 0, false);
        }
        
        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        protected static void Run()
        {
            Emscripten.SetMainLoopTiming(Emscripten.Mode.RequestFrameAnimation, 1);
            
            if (Engine.Instance.Run())
            {
                // Run application
                return;
            }
            
            Emscripten.CancelMainLoop();
        }
    }
}