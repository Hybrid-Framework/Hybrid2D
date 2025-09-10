using static Engine.Internal.SDL2.SDL;
using System;

namespace Engine.Platforms
{
    public class PlatformDesktop : Platform
    {
        public override Game Game { get; set; }
        public override IDevice Device { get; set; } = IDevice.Desktop;
        
        public override IFileSystem FileSystem { get; set; } = new FileSystemDesktop();
        public override IDebug Debug { get; set; } = new DebugDesktop();
        
        
        public PlatformDesktop(Game game)
        {
            Game = game;
        }

        public override void Init()
        {
            Game.Init("Engine", 800, 600, SDL_WindowFlags.SDL_WINDOW_SHOWN);
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