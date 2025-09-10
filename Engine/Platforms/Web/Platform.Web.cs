using static Engine.Internal.SDL2.SDL;
using System;

namespace Engine.Platforms
{
    public class PlatformWeb : Platform
    {
        public override Game Game { get; set; }
        public override IDevice Device { get; set; } = IDevice.Web;
        
        public override IFileSystem FileSystem { get; set; } = new FileSystemWeb();
        public override IDebug Debug { get; set; } = new DebugWeb();
        
        
        public PlatformWeb(Game game)
        {
            Game = game;
        }

        public override void Init()
        {
            Game.Init("Engine", 1280, 768, SDL_WindowFlags.SDL_WINDOW_SHOWN);
        }

        public override void Run()
        {
            if (Game.Update())
            {
                // Main Loop
                return;
            }
            
            Game.Dispose();
        }
    }
}