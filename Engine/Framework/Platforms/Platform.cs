using System;

namespace Hybrid
{
    // Platform
    public abstract partial class Platform : Module<Platform>
    {
        protected Platform() { }
        
        protected abstract IPlatformDevice Device { get; set; }
        protected abstract IPlatformCanvas Canvas { get; set; }

        protected static Platform Current { get; set; }
        protected static Config Config { get; set; }
        
        
        internal static void Create(Platform platform, Config config)
        {
            Current = platform;
            Config = config;
        }
    }
    
    // Platform API
    public abstract partial class Platform
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