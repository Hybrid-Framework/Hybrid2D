using System;

namespace Hybrid
{
    // Platform
    public partial class Platform : Module<Platform>
    {
        protected Platform() { }
        
        protected virtual IPlatformDevice Device { get; set; }
        protected virtual IPlatformCanvas Canvas { get; set; }

        protected static Platform Current { get; private set; }
        protected static Config Config { get; private set; }
        
        
        internal static void SetPlatform(Platform platform, Config config)
        {
            Current = platform;
            Config = config;
        }
    }
    
    // Platform API
    public partial class Platform
    {
        public static void Quit()
        {
            Engine.Instance.Quit();
        }
        
        public static Config GetConfig()
        {
            return Config;
        }
        
        public static Device GetDevice()
        {
            return Current?.Device?.GetDevice() ?? Hybrid.Device.Unknown;
        }
        
        public static System GetSystem()
        {
            return Current?.Device?.GetSystem() ?? System.Unknown;
        }
        
        internal static Orientation GetOrientation()
        {
            return Current?.Canvas?.GetOrientation() ?? Orientation.Unknown;
        }
        
        internal static Orientation GetNaturalOrientation()
        {
            return Current?.Canvas?.GetNaturalOrientation() ?? Orientation.Unknown;
        }
    }
}