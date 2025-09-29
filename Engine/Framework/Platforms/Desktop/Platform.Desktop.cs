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
        }
        
        public override void Run()
        {
            // Main Loop
            while (IsRunning)
            {
                // Loop
                PollEvents();
                Behaviour.Render();
            }
            
            // Dispose
            Dispose();
        }
    }
}