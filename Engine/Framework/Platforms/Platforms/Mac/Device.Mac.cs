using System;

namespace Hybrid
{
    internal class MacDevice : IPlatformDevice
    {
        public Device GetDevice()
        {
            return Device.Desktop;
        }
        
        public System GetSystem()
        {
            return System.Mac;
        }
    }
}