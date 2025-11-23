using System;

namespace Hybrid
{
    public class WebDevice : IPlatformDevice
    {
        public Device GetDevice()
        {
            string device = Emscripten.RunScriptString
            (
                @"(() =>
                {
                    const uap = new UAParser();

                    const device = uap.getDevice().withFeatureCheck();
                    
                    if (device.type == 'mobile') return 'Mobile';
                    if (device.type == 'tablet') return 'Mobile';
                    if (device.type == 'console') return 'Mobile';
                    if (device.type == 'embedded') return 'Mobile';
                    if (device.type == 'smarttv') return 'Mobile';
                    if (device.type == 'wearable') return 'Mobile';
                    if (device.type == 'xr') return 'Mobile';
                    if (device.is('iPad')) return 'Mobile';

                    return 'Desktop';

                })();"
            );

            switch (device)
            {
                case "Mobile":
                    return Device.Mobile;
                
                case "Desktop":
                    return Device.Desktop;
                
                default:
                    return Device.Unknown;
            }
        }
    }
}