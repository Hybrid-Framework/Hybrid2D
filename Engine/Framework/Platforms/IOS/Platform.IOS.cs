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
                // Loop
                Behaviour.Update();
                Behaviour.Render();
            }
            
            // Dispose
            Dispose();
        }
    }
}