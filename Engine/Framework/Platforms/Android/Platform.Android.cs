using System;
using System.Runtime.InteropServices;

namespace Hybrid.Platforms
{
    public class PlatformAndroid : Platform
    {
        public PlatformAndroid(Behaviour behaviour) => Behaviour = behaviour;
        public override Behaviour Behaviour { get; set; }

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