using System;

namespace Hybrid
{
    public class MacDevice : IPlatformDevice
    {
        public Device GetDevice()
        {
            return Device.Desktop;
        }
    }
}