using static Hybrid.SDL2.SDL;
using System;

namespace Hybrid.Platforms
{
    public class PlatformAndroid : Platform
    {
        public PlatformAndroid(Behaviour behaviour) => Behaviour = behaviour;
        
        internal override Behaviour Behaviour { get; set; }
        internal override IFileSystem FileSystem { get; set; } = new FileSystemAndroid();
        internal override IDebug Debug { get; set; } = new DebugAndroid();

        public override void Init()
        {
            // Init
            Behaviour.Init();
            
            // Platform Specifics
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