using System;
using SDL3;

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
                while (SDL.SDL_PollEvent(out var e))
                {
                    Behaviour.Update(e);
                }
                
                // Loop
                Behaviour.Render();
            }
            
            // Dispose
            Dispose();
        }
    }
}