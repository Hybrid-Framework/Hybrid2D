using System;

namespace Hybrid
{
    // Platform
    internal abstract partial class Platform
    {
        private static Platform Current { get; set; }
        private static Config Config { get; set; }
        
        
        internal static void SetPlatform(Platform platform, Config config)
        {
            if(platform == null || config == null)
                throw new Exception("Invalid Parameters");
            
            Current = platform;
            Config = config;
        }

        internal static Platform GetPlatform()
        {
            if (Current == null)
                throw new Exception("No Platform Detected");
            
            return Current;
        }
        
        internal static Config GetConfig()
        {
            if (Config == null)
                throw new Exception("No Config Detected");
            
            return Config;
        }
    }

    // Backends
    internal abstract partial class Platform
    {
        protected virtual IPlatformDisplay Display { get; set; }
        protected virtual IPlatformSystem System { get; set; }
        protected virtual IPlatformEvents Events { get; set; }

        internal static IPlatformDisplay GetDisplay() => GetPlatform().Display;
        internal static IPlatformSystem GetSystem() => GetPlatform().System;
        internal static IPlatformEvents GetEvents() => GetPlatform().Events;
    }
}