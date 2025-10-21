using System.Runtime.InteropServices;

namespace Hybrid
{
    public unsafe class PlatformWindows : Platform
    {
        public PlatformWindows(GameBehaviour gameBehaviour)
        {
            GameBehaviour = gameBehaviour;
        }
        
        internal override void Bootstrap()
        {
            // Platform
            SystemPlatform = SystemPlatform.Windows;
            SystemDevice = SystemDevice.Desktop;
            
            // Resolve
            var assembly = typeof(SDL).Assembly;
            NativeLibrary.SetDllImportResolver(assembly, (library, asm, path) =>
            {
                return library switch
                {
                    "SDL3_image" => NativeLibrary.Load("SDL3_image.dll", asm, path),
                    "SDL3_mixer" => NativeLibrary.Load("SDL3_mixer.dll", asm, path),
                    "SDL3_ttf" => NativeLibrary.Load("SDL3_ttf.dll", asm, path),
                    "SDL3" => NativeLibrary.Load("SDL3.dll", asm, path),
                    _ => IntPtr.Zero
                };
            });
            
            // Run
            SDL.Initialize();
            Run();
        }

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
            while (Current.IsRunning)
            {
                if (Window.GetWindow() == null)
                {
                    throw new Exception("Please create a window inside Init(); using Window.Create(...);");
                }
                
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
            }
            
            // Exit
            Current.Quit();
        }
        
        internal override void Quit()
        {
            // Quit
            IsRunning = false;
            Current.Dispose();
        }
    }
}