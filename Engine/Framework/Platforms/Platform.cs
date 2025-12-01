using System;

namespace Hybrid
{
    // Platform
    internal class Platform : Module<Platform>
    {
        protected Platform() { }

        protected internal virtual IPlatformSystem System { get; set; }
        protected internal virtual IPlatformCanvas Canvas { get; set; }
        
        private static Platform Current { get; set; }
        private static Config Config { get; set; }
        
        
        internal static void SetPlatform(Platform platform, Config config)
        {
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
}