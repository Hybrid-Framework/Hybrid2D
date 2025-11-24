using System;

namespace Hybrid
{
    public class MacDevice : IPlatformDevice
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