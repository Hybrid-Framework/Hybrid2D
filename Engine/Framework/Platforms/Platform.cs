using System;

namespace Hybrid
{
    // Platform
    public abstract class Platform
    {
        public static void Windows(Config config) => Create(new PlatformWindows(), config);
        public static void Android(Config config) => Create(new PlatformAndroid(), config);
        public static void Linux(Config config) => Create(new PlatformLinux(), config);
        public static void MacOS(Config config) => Create(new PlatformMacOS(), config);
        public static void IOS(Config config) => Create(new PlatformIOS(), config);
        public static void Web(Config config) => Create(new PlatformWeb(), config);
        
        public virtual PlatformDevice PlatformDevice { get; protected set; }
        public virtual PlatformName PlatformName { get; protected set; }
        
        public static Platform Current { get; protected set; }
        internal static Engine Engine { get; set; }

        internal abstract void Bootstrap();
        

        internal static void Create(Platform platform, Config config)
        {
            // Check for null instances
            if (platform == null) throw new Exception("Can not create null platform");
            if (config == null) throw new Exception("Can not create null config");
            
            // Create Engine
            Engine = new Engine(config);
            
            // Bootstrap
            Current = platform;
            Current.Bootstrap();
        }
    }
}