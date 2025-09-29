using System;
using SDL3;

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
        }
        
        public override void Run()
        {
            // Main Loop
            if (IsRunning)
            {
                while (SDL.SDL_PollEvent(out var e))
                {
                    Behaviour.Update(e);
                }
                
                // Loop
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