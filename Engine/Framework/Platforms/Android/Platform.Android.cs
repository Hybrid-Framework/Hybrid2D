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