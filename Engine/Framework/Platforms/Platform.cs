using System;

namespace Hybrid
{
    // Platform
    public abstract class Platform
    {
        public static void Windows(Game game) => Create(new PlatformWindows(), game);
        public static void Android(Game game) => Create(new PlatformAndroid(), game);
        public static void Linux(Game game) => Create(new PlatformLinux(), game);
        public static void MacOS(Game game) => Create(new PlatformMacOS(), game);
        public static void IOS(Game game) => Create(new PlatformIOS(), game);
        public static void Web(Game game) => Create(new PlatformWeb(), game);
        
        public virtual PlatformDevice PlatformDevice { get; protected set; }
        public virtual PlatformType PlatformType { get; protected set; }
        
        public static Platform Current { get; protected set; }
        internal static Engine Engine { get; set; }

        internal abstract void Bootstrap();
        

        internal static void Create(Platform platform, Game game)
        {
            // Check for null instances
            if (platform == null) throw new Exception("Can not create null platform");
            if (game == null) throw new Exception("Can not create null game");
            
            // Create Engine
            Engine = new Engine(game);
            
            // Bootstrap
            Current = platform;
            Current.Bootstrap();
        }
        
        public void Quit()
        {
            // Quit
            Engine.Quit();
        }
    }
}