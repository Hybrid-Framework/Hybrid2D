using static Hybrid.SDL2.SDL;
using System;

namespace Hybrid.Platforms
{
    public class PlatformDesktop : Platform
    {
        public PlatformDesktop(Behaviour behaviour) => Behaviour = behaviour;
        
        internal override Behaviour Behaviour { get; set; }
        internal override IFileSystem FileSystem { get; set; } = new FileSystemDesktop();
        internal override IDebug Debug { get; set; } = new DebugDesktop();

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
                    Events.Process(e);
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