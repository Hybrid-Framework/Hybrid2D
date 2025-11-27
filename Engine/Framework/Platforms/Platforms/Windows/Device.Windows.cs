using System;

namespace Hybrid
{
    internal class WindowsDevice : IPlatformDevice
    {
        public Device GetDevice()
        {
            return Device.Desktop;
        }
        
        public System GetSystem()
        {
            return System.Windows;
        }
    }
}