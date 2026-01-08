using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.IO;
using System;

namespace Hybrid
{
    internal static unsafe class Bootstrap
    {
        private static GCHandle AppHandle;
        private static Application App;

        
        public static void Execute(Application app)
        {
            AppHandle = GCHandle.Alloc(app);
            App = app;

            if (OperatingSystem.IsIOS())
            {
                var assembly = typeof(SDL).Assembly;
                var frameworks = Path.Combine(AppContext.BaseDirectory!, "Frameworks");
                NativeLibrary.SetDllImportResolver(assembly, (library, asm, path) =>
                {
                    return library switch
                    {
                        "SDL3_image" => NativeLibrary.Load(Path.Combine(frameworks, "SDL3_image.framework", "SDL3_image"), asm, path),
                        "SDL3_mixer" => NativeLibrary.Load(Path.Combine(frameworks, "SDL3_mixer.framework", "SDL3_mixer"), asm, path),
                        "SDL3_ttf" => NativeLibrary.Load(Path.Combine(frameworks, "SDL3_ttf.framework", "SDL3_ttf"), asm,path),
                        "SDL3" => NativeLibrary.Load(Path.Combine(frameworks, "SDL3.framework", "SDL3"), asm, path),
                        _ => IntPtr.Zero
                    };
                });
            }
            
            SDL.Initialize();
            SDL.SDL_EnterAppMainCallbacks
            (
                0,
                IntPtr.Zero,
                &SDLInit,
                &SDLIterate,
                &SDLEvent,
                &SDLQuit
            );
        }
        
        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        private static SDL.AppResult SDLInit(IntPtr state, int argc, IntPtr argv)
        {
            App.StartMainLoop();
            {
                return SDL.AppResult.Continue;
            }
        }
        
        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        private static SDL.AppResult SDLIterate(IntPtr state)
        {
            App.MainLoop();
            {
                if (!App.IsRunning)
                {
                    return SDL.AppResult.Success;
                }
                
                return SDL.AppResult.Continue;
            }
        }
        
        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        private static SDL.AppResult SDLEvent(IntPtr state, SDL.Event* e)
        {
            App.Events(*e);
            {
                return SDL.AppResult.Continue;
            }
        }
        
        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        private static void SDLQuit(IntPtr state, SDL.AppResult result)
        {
            App.Quit();
            AppHandle.Free();
        }
    }
}