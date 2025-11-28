using System;

namespace Hybrid
{
    internal class IOSSystem : IPlatformSystem
    {
        public Device GetDevice()
        {
            return Device.Mobile;
        }
        
        public System GetPlatform()
        {
            return System.IOS;
        }
    }
}