using static Engine.SDL2.SDL;
using System;

namespace Engine.Platforms
{
    public class PlatformAndroid : Platform
    {
        public PlatformAndroid(GameBehaviour behaviour) => GameBehaviour = behaviour;
        
        internal override GameBehaviour GameBehaviour { get; set; }
        internal override IFileSystem FileSystem { get; set; } = new FileSystemAndroid();
        internal override IDebug Debug { get; set; } = new DebugAndroid();
        
        
        internal override void Run()
        {
            if (!Initialized)
            {
                // Init
                Initialized = true;
                GameBehaviour.Init();
            }
            
            while (IsRunning)
            {
                // Loop
                GameBehaviour.Update();
                GameBehaviour.Render();
            }
            
            // Dispose
            GameBehaviour.Dispose();
        }
    }
}