using System;

namespace Hybrid
{
    public class IOSDevice : IPlatformDevice
    {
        public Device GetDevice()
        {
            return Device.Mobile;
        }
    }
}