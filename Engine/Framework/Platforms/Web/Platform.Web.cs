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
        }
        
        public override void Run()
        {
            // Main Loop
            if (IsRunning)
            {
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