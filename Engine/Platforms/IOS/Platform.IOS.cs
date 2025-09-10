using static Engine.Internal.SDL2.SDL;
using System;

namespace Engine.Platforms
{
    public class PlatformIOS : Platform
    {
        public override Game Game { get; set; }
        public override IDevice Device { get; set; } = IDevice.IOS;
        
        public override IFileSystem FileSystem { get; set; } = new FileSystemIOS();
        public override IDebug Debug { get; set; } = new DebugIOS();
        
        
        public PlatformIOS(Game game)
        {
            Game = game;
        }

        public override void Init()
        {
            Game.Init("Engine", 800, 600, SDL_WindowFlags.SDL_WINDOW_FULLSCREEN | SDL_WindowFlags.SDL_WINDOW_RESIZABLE);
        }

        public override void Run()
        {
            while (Game.Update())
            {
                // Main Loop
            }
            
            Game.Dispose();
        }
    }
}