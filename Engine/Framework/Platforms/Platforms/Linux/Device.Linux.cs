using System;

namespace Hybrid
{
    public class LinuxDevice : IPlatformDevice
    {
        public Device GetDevice()
        {
            return Device.Desktop;
        }
        
        public System GetSystem()
        {
            return System.Linux;
        }
    }
}