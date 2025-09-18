using static Engine.SDL2.SDL;
using System;

namespace Engine.Platforms
{
    public class PlatformWeb : Platform
    {
        public PlatformWeb(GameBehaviour behaviour) => GameBehaviour = behaviour;
        
        internal override GameBehaviour GameBehaviour { get; set; }
        internal override IFileSystem FileSystem { get; set; } = new FileSystemWeb();
        internal override IDebug Debug { get; set; } = new DebugWeb();
        
        
        internal override void Run()
        {
            if (!Initialized)
            {
                // Init
                Initialized = true;
                GameBehaviour.Init();
            }

            if (IsRunning)
            {
                // Loop
                GameBehaviour.Update();
                GameBehaviour.Render();
            }
            else
            {
                // Dispose
                GameBehaviour.Dispose();
            }
        }
    }
}