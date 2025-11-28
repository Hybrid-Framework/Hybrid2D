using System;

namespace Hybrid
{
    internal class LinuxSystem : IPlatformSystem
    {
        public Device GetDevice()
        {
            return Device.Desktop;
        }
        
        public System GetPlatform()
        {
            return System.Linux;
        }
    }
}