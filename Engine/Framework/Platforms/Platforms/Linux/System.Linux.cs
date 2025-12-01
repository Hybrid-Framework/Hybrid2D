using System;

namespace Hybrid
{
    internal class LinuxSystem : IPlatformSystem
    {
        public UnderlyingDevice GetUnderlyingDevice()
        {
            return UnderlyingDevice.Desktop;
        }

        public UnderlyingPlatform GetUnderlyingPlatform()
        {
            return UnderlyingPlatform.Linux;
        }
    }
}