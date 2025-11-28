using System;

namespace Hybrid
{
    internal class MacSystem : IPlatformSystem
    {
        public Device GetDevice()
        {
            return Device.Desktop;
        }
        
        public System GetPlatform()
        {
            return System.Mac;
        }
    }
}