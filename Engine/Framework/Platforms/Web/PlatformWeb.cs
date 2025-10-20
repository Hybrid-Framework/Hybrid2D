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
            // Platform
            SystemPlatform = SystemPlatform.Web;
            
            // Resolve
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
            Emscripten.SetMainLoopTiming(Emscripten.TimingMode.RequestFrameAnimation, 1);
        }
        
        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        internal static void Run()
        {
            // Initialize
            if (!Current.Initialized)
            {
                Current.GameBehaviour.Init();
                Current.Initialized = true;
                Current.IsRunning = true;
            }
            
            // Main Loop
            if (Current.IsRunning)
            {
                while (SDL.PollEvent(out SDL.Event e))
                {
                    var type = (SDL.EventType)e.type;

                    if (type == SDL.EventType.Quit)
                    {
                        Current.Quit();
                        return;
                    }
                }
                
                Current.GameBehaviour.Update();
                Current.GameBehaviour.Draw();
                return;
            }
            
            // Exit
            Emscripten.CancelMainLoop();
            Current.Quit();
        }

        internal override void Quit()
        {
            // Quit
            IsRunning = false;
            Platform.Dispose();
        }
    }
}