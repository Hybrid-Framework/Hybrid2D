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
            PlatformType = PlatformType.Web;
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
            
            SDL.Init(SDL.InitFlags.Everything);
            SDL_mixer.Init();
            SDL_image.Init();
            SDL_ttf.Init();
            
            Emscripten.SetMainLoop((IntPtr)(delegate* unmanaged[Cdecl]<void>)&Run, 0, true);
        }
        
        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        internal static void Run()
        {
            Emscripten.SetMainLoopTiming(Emscripten.TimingMode.RequestFrameAnimation, 1);
            Current?.Initialize();
            
            if (IsRunning)
            {
                Current?.MainLoop();
                return;
            }
            
            Emscripten.CancelMainLoop();
            Current?.Quit();
        }
    }
}