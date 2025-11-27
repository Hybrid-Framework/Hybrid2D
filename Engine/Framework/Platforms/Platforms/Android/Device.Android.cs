using System;

namespace Hybrid
{
    internal class AndroidDevice : IPlatformDevice
    {
        public Device GetDevice()
        {
            return Device.Mobile;
        }
        
        public System GetSystem()
        {
            return System.Android;
        }
    }
}