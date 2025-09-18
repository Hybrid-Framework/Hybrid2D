using static Hybrid.SDL2.SDL;
using System;

namespace Hybrid.Platforms
{
    public class PlatformIOS : Platform
    {
        public PlatformIOS(GameBehaviour behaviour) => GameBehaviour = behaviour;
        
        internal override GameBehaviour GameBehaviour { get; set; }
        internal override IFileSystem FileSystem { get; set; } = new FileSystemIOS();
        internal override IDebug Debug { get; set; } = new DebugIOS();

        public override void Init()
        {
            // Init
            GameBehaviour.Init();
        }
        
        public override void Run()
        {
            // Main Loop
            while (IsRunning)
            {
                // Events
                while (SDL_PollEvent(out SDL_Event e) == 1)
                {
                    Events.Process(e);
                }

                // Loop
                GameBehaviour.Update();
                GameBehaviour.Render();
            }
            
            // Dispose
            Dispose();
        }
    }
}