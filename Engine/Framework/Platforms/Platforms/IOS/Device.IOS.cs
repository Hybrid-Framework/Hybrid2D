using System;

namespace Hybrid
{
    internal class IOSDevice : IPlatformDevice
    {
        public Device GetDevice()
        {
            return Device.Mobile;
        }
        
        public System GetSystem()
        {
            return System.IOS;
        }
    }
}