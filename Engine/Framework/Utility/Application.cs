using System;

namespace Hybrid
{
    // Application
    public static class Application
    {
        public static UnderlyingDevice GetUnderlyingDevice()
        {
            return Platform.GetSystem().GetUnderlyingDevice();
        }
        
        public static UnderlyingPlatform GetUnderlyingPlatform()
        {
            return Platform.GetSystem().GetUnderlyingPlatform();
        }
        
        public static Config GetConfig()
        {
            return Platform.GetConfig();
        }
        
        public static void Quit()
        {
            Engine.Instance.Quit();
        }
    }
}