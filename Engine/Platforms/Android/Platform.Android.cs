using static Engine.SDL2.SDL;
using System;

namespace Engine.Platforms
{
    public class PlatformAndroid : Platform
    {
        public override GameBehaviour GameBehaviour { get; set; }
        public override IDevice Device { get; set; } = IDevice.Android;
        
        public override IFileSystem FileSystem { get; set; } = new FileSystemAndroid();
        public override IDebug Debug { get; set; } = new DebugAndroid();
        
        
        public PlatformAndroid(GameBehaviour behaviour)
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