using static Engine.SDL2.SDL;
using System;

namespace Engine.Platforms
{
    public class PlatformDesktop : Platform
    {
        public override GameBehaviour GameBehaviour { get; set; }
        public override IDevice Device { get; set; } = IDevice.Desktop;
        
        public override IFileSystem FileSystem { get; set; } = new FileSystemDesktop();
        public override IDebug Debug { get; set; } = new DebugDesktop();
        
        
        public PlatformDesktop(GameBehaviour behaviour)
        {
            GameBehaviour = behaviour;
        }

        public override void Init()
        {
            GameBehaviour.Init("Engine", 800, 600, SDL_WindowFlags.SDL_WINDOW_SHOWN);
        }
        
        public override void Run()
        {
            while (GameBehaviour.Update())
            {
                // Main Loop
            }
            
            GameBehaviour.Dispose();
        }
    }
}