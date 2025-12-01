using System;

namespace Hybrid
{
    internal class WebSystem : IPlatformSystem
    {
        public UnderlyingDevice GetUnderlyingDevice()
        {
            string device = Emscripten.RunScriptString("Hybrid.getDevice();");

            return device switch
            {
                "Mobile" => UnderlyingDevice.Mobile,
                "Desktop" => UnderlyingDevice.Desktop,
                
                _ => UnderlyingDevice.Unknown,
            };
        }
        
        public UnderlyingPlatform GetUnderlyingPlatform()
        {
            return UnderlyingPlatform.Web;
        }
    }
}