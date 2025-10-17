using System;
using System.Runtime.InteropServices;

namespace Hybrid.Platforms
{
    public class PlatformIOS : Platform
    {
        public PlatformIOS(Behaviour behaviour) => Behaviour = behaviour;
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