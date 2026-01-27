using System;

namespace Hybrid
{
    internal class WindowsSystem : IPlatformSystem
    {
        public UnderlyingDevice GetUnderlyingDevice()
        {
            return UnderlyingDevice.Desktop;
        }

        public UnderlyingPlatform GetUnderlyingPlatform()
        {
            return UnderlyingPlatform.Windows;
        }
    }
}