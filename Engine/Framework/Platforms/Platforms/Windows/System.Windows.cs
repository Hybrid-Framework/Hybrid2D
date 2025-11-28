using System;

namespace Hybrid
{
    internal class WindowsSystem : IPlatformSystem
    {
        public Device GetDevice()
        {
            return Device.Desktop;
        }
        
        public System GetPlatform()
        {
            return System.Windows;
        }
    }
}