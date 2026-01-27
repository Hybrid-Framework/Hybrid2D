using System;

namespace Hybrid
{
    internal class MacSystem : IPlatformSystem
    {
        public UnderlyingDevice GetUnderlyingDevice()
        {
            return UnderlyingDevice.Desktop;
        }

        public UnderlyingPlatform GetUnderlyingPlatform()
        {
            return UnderlyingPlatform.Mac;
        }
    }
}