using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System;

namespace Hybrid
{
    internal static unsafe class Bootstrap
    {
        private static GCHandle AppHandle;
        private static App App;

        
        public static void Execute(App app)
        {
            AppHandle = GCHandle.Alloc(app);
            App = app;
            
            Resolver.ResolveLibraries();
            {
                SDL.Initialize();
                {
                    SDL.RunApp(0, IntPtr.Zero, &SDLEntry, IntPtr.Zero);
                }
            }
        }
        
        [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
        private static int SDLEntry(int argc, IntPtr argv)
        {
            SDL.EnterAppMainCallbacks
            (
                0,
                IntPtr.Zero,
                &SDLInit,
                &SDLIterate,
                &SDLEvent,
                &SDLQuit
            );
            
            return 0;
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
            if (AppHandle.IsAllocated)
            {
                AppHandle.Free();
            }
            
            if (App.IsRunning)
            {
                App.Quit();
            }
        }
    }
}