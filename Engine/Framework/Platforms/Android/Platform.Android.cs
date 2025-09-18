using static Hybrid.SDL2.SDL;
using System;

namespace Hybrid.Platforms
{
    public class PlatformAndroid : Platform
    {
        public PlatformAndroid(GameBehaviour behaviour) => GameBehaviour = behaviour;
        
        internal override GameBehaviour GameBehaviour { get; set; }
        internal override IFileSystem FileSystem { get; set; } = new FileSystemAndroid();
        internal override IDebug Debug { get; set; } = new DebugAndroid();

        public override void Init()
        {
            // Init
            GameBehaviour.Init();
            
            // Force Settings
            if (Window.GetWindow() != IntPtr.Zero)
            {
                Window.Fullscreen(true);
                Window.Resizeable(true);
            }
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