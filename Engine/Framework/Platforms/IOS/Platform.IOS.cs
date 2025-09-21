using static Hybrid.SDL2.SDL;
using System;

namespace Hybrid.Platforms
{
    public class PlatformIOS : Platform
    {
        public PlatformIOS(Behaviour behaviour) => Behaviour = behaviour;
        
        internal override Behaviour Behaviour { get; set; }
        internal override IFileSystem FileSystem { get; set; } = new FileSystemIOS();
        internal override IDebug Debug { get; set; } = new DebugIOS();

        public override void Init()
        {
            // Init
            Behaviour.Init();
            
            // Platform Specifics
        }
        
        public override void Run()
        {
            // Main Loop
            while (IsRunning)
            {
                // Events
                while (SDL_PollEvent(out SDL_Event e) == 1)
                {
                    Behaviour.Events(e);
                }

                // Loop
                Behaviour.Update();
                Behaviour.Render();
            }
            
            // Dispose
            Dispose();
        }
    }
}