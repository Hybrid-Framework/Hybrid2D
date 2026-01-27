using System;

namespace Hybrid
{
    internal class AndroidSystem : IPlatformSystem
    {
        public UnderlyingDevice GetUnderlyingDevice()
        {
            return UnderlyingDevice.Mobile;
        }

        public UnderlyingPlatform GetUnderlyingPlatform()
        {
            return UnderlyingPlatform.Android;
        }
    }
}