using System;

namespace Hybrid
{
    internal class WebSystem : IPlatformSystem
    {
        public Device GetDevice()
        {
            string device = Emscripten.RunScriptString("Hybrid.getDevice();");

            return device switch
            {
                "Mobile" => Device.Mobile,
                "Desktop" => Device.Desktop,
                _ => Device.Unknown,
            };
        }
        
        public System GetPlatform()
        {
            return System.Web;
        }
    }
}