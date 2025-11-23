using System;

namespace Hybrid
{
    public class WindowsDevice : IPlatformDevice
    {
        public Device GetDevice()
        {
            return Device.Desktop;
        }
    }
}