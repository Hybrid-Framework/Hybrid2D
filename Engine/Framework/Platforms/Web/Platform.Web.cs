using System;
using System.Runtime.InteropServices;

namespace Hybrid.Platforms
{
    public class PlatformWeb : Platform
    {
        public PlatformWeb(Behaviour behaviour) => Behaviour = behaviour;
        public override Behaviour Behaviour { get; set; }

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