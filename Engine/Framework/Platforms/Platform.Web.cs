using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Hybrid
{
    internal unsafe class PlatformWeb : Platform
    {
        internal override void Bootstrap()
        {
            PlatformName = PlatformName.Web;
            PlatformDevice = PlatformDevice.Unknown;
            
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
            Emscripten.SetMainLoop((IntPtr)(delegate* unmanaged[Cdecl]<void>)&Run, 0, true);
        }
        
        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        internal static void Run()
        {
            Emscripten.SetMainLoopTiming(Emscripten.TimingMode.RequestFrameAnimation, 1);
            Engine.Initialize();
            
            if (Engine.IsRunning)
            {
                Engine.MainLoop();
                return;
            }
            
            Emscripten.CancelMainLoop();
            Engine.Quit();
        }
    }
}