using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Hybrid
{
    internal unsafe class PlatformWeb : Platform
    {
        private static Device ResolveDevice()
        {
            var found = Emscripten.RunScriptString
            (
                @"(() =>
                {
                    const uap = new UAParser();

                    const device = uap.getDevice().withFeatureCheck();
                    
                    if (device.type == 'mobile') return 'Mobile';
                    if (device.type == 'tablet') return 'Mobile';
                    if (device.type == 'console') return 'Mobile';
                    if (device.type == 'embedded') return 'Mobile';
                    if (device.type == 'smarttv') return 'Mobile';
                    if (device.type == 'wearable') return 'Mobile';
                    if (device.type == 'xr') return 'Mobile';

                    if (device.is('iPad')) return 'Mobile';

                    return 'Desktop';

                })();"
            );

            switch (found)
            {
                case "Mobile": return Device.Mobile;
                case "Desktop": return Device.Desktop;
                default: return Device.Unknown;
            }
        }
        
        internal override void Bootstrap()
        {
            System = System.Web;
            Device = ResolveDevice();
            
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
        internal static void Run()
        {
            Emscripten.SetMainLoopTiming(Emscripten.Mode.RequestFrameAnimation, 1);
            Engine.StartMainLoop();
            
            if (Engine.IsRunning)
            {
                Device = ResolveDevice(); // DEBUG ONLY!!!
                Engine.MainLoop();
                return;
            }
            
            Emscripten.CancelMainLoop();
            Engine.Quit();
        }
    }
}