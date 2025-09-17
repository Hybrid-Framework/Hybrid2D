using static Engine.Internal.SDL2.SDL;
using System;

namespace Engine.Platforms
{
    public class PlatformWeb : Platform
    {
        public override GameBehaviour GameBehaviour { get; set; }
        public override IDevice Device { get; set; } = IDevice.Web;
        
        public override IFileSystem FileSystem { get; set; } = new FileSystemWeb();
        public override IDebug Debug { get; set; } = new DebugWeb();
        
        
        public PlatformWeb(GameBehaviour behaviour)
        {
            GameBehaviour = behaviour;
        }

        public override void Init()
        {
            GameBehaviour.Init("Engine", 1280, 768, SDL_WindowFlags.SDL_WINDOW_SHOWN);
        }

        public override void Run()
        {
            if (GameBehaviour.Update())
            {
                // Main Loop
                return;
            }
            
            GameBehaviour.Dispose();
        }
    }
}