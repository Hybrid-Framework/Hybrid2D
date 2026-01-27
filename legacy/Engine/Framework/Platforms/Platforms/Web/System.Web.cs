using System;

namespace Hybrid
{
    internal class WebSystem : IPlatformSystem
    {
        public UnderlyingDevice GetUnderlyingDevice()
        {
            string device = Emscripten.RunScriptString("HybridJS.GetDevice();");

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