using System;

namespace Hybrid
{
    // Platform
    public partial class Platform : Module<Platform>
    {
        protected Platform() { }

        protected static Platform Current { get; private set; }
        protected static Config Config { get; private set; }
        
        
        internal static void SetPlatform(Platform platform, Config config)
        {
            Current = platform;
            Config = config;
        }
        
        public static void Quit()
        {
            Engine.Instance.Quit();
        }

        public static Config GetConfig()
        {
            return Config;
        }
    }
    
    // Platform Specifics
    public partial class Platform
    {
        protected virtual IPlatformSystem System { get; set; }
        protected virtual IPlatformCanvas Canvas { get; set; }
        
        public static IPlatformSystem GetSystem() => Current.System;
        public static IPlatformCanvas GetCanvas() => Current.Canvas;
    }
}