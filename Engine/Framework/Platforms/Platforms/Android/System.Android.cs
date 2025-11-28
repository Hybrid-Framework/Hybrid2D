using System;

namespace Hybrid
{
    internal class AndroidSystem : IPlatformSystem
    {
        public Device GetDevice()
        {
            return Device.Mobile;
        }
        
        public System GetPlatform()
        {
            return System.Android;
        }
    }
}