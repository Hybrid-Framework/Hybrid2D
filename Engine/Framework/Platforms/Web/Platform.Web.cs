using static Hybrid.SDL2.SDL;
using System;

namespace Hybrid.Platforms
{
    public class PlatformWeb : Platform
    {
        public PlatformWeb(Behaviour behaviour) => Behaviour = behaviour;
        
        internal override Behaviour Behaviour { get; set; }
        internal override IFileSystem FileSystem { get; set; } = new FileSystemWeb();
        internal override IDebug Debug { get; set; } = new DebugWeb();

        public override void Init()
        {
            // Init
            Behaviour.Init();
            
            // Platform Specifics
            if (Window.GetWindow() != IntPtr.Zero)
            {
                Window.Vsync(true);
            }
        }
        
        public override void Run()
        {
            // Main Loop
            if (IsRunning)
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
            else
            {
                // Dispose
                Dispose();
            }
        }
    }
}