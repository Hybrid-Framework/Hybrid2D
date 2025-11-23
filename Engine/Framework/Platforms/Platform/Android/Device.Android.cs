using System;

namespace Hybrid
{
    public class AndroidDevice : IPlatformDevice
    {
        public Device GetDevice()
        {
            return Device.Mobile;
        }
    }
}