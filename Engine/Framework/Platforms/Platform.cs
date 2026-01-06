using System;

namespace Hybrid
{
    // Platform
    internal abstract partial class Platform
    {
        internal static Platform Current { get; private set; }
        internal static Config Config { get; private set; }
        internal static Game Game { get; private set; }
        
        
        internal static void SetPlatform(Platform platform, Config config)
        {
            if(platform == null || config == null)
                throw new Exception($"Invalid Platform Parameters {typeof(Platform)} {typeof(Config)} {typeof(Game)}");
            
            Game = config.Game;
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