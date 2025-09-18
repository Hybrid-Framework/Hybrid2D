using static Hybrid.SDL2.SDL;
using System;

namespace Hybrid.Platforms
{
    public class PlatformWeb : Platform
    {
        public PlatformWeb(GameBehaviour behaviour) => GameBehaviour = behaviour;
        
        internal override GameBehaviour GameBehaviour { get; set; }
        internal override IFileSystem FileSystem { get; set; } = new FileSystemWeb();
        internal override IDebug Debug { get; set; } = new DebugWeb();

        public override void Init()
        {
            // Init
            GameBehaviour.Init();
            
            // Force Settings
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
                    Events.Process(e);
                }

                // Loop
                GameBehaviour.Update();
                GameBehaviour.Render();
            }
            else
            {
                // Dispose
                Dispose();
            }
        }
    }
}