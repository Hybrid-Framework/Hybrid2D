using System;

namespace Hybrid
{
    internal class IOSSystem : IPlatformSystem
    {
        public UnderlyingDevice GetUnderlyingDevice()
        {
            return UnderlyingDevice.Mobile;
        }

        public UnderlyingPlatform GetUnderlyingPlatform()
        {
            return UnderlyingPlatform.IOS;
        }
    }
}