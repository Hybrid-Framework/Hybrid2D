using System.Runtime.InteropServices;

namespace Hybrid
{
    public class PlatformAndroid : Platform
    {
        public PlatformAndroid(GameBehaviour gameBehaviour)
        {
            GameBehaviour = gameBehaviour;
        }
        
        internal override void Bootstrap()
        {
            // Platform
            SystemPlatform = SystemPlatform.Android;
            
            // Resolve
            var assembly = typeof(SDL).Assembly;
            NativeLibrary.SetDllImportResolver(assembly, (library, asm, path) =>
            {
                return library switch
                {
                    "SDL3_image" => NativeLibrary.Load("libSDL3_image.so", asm, path),
                    "SDL3_mixer" => NativeLibrary.Load("libSDL3_mixer.so", asm, path),
                    "SDL3_ttf" => NativeLibrary.Load("libSDL3_ttf.so", asm, path),
                    "SDL3" => NativeLibrary.Load("libSDL3.so", asm, path),
                    _ => IntPtr.Zero
                };
            });
            
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
            Platform.Dispose();
        }
    }
}