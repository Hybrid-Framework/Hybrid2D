using static Engine.Internal.SDL2.SDL;
using System;

namespace Engine.Platforms
{
    public class PlatformIOS : Platform
    {
        public override GameBehaviour GameBehaviour { get; set; }
        public override IDevice Device { get; set; } = IDevice.IOS;
        
        public override IFileSystem FileSystem { get; set; } = new FileSystemIOS();
        public override IDebug Debug { get; set; } = new DebugIOS();
        
        
        public PlatformIOS(GameBehaviour behaviour)
        {
            GameBehaviour = behaviour;
        }

        public override void Init()
        {
            GameBehaviour.Init("Engine", 800, 600, SDL_WindowFlags.SDL_WINDOW_FULLSCREEN | SDL_WindowFlags.SDL_WINDOW_RESIZABLE);
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