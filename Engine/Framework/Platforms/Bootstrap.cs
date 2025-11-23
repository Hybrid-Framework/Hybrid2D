using System;

namespace Hybrid
{
    // Platform
    public class Bootstrap
    {
        public static void Windows(Config config) => Create(new WindowsBootstrap(), config);
        public static void Android(Config config) => Create(new AndroidBootstrap(), config);
        public static void Linux(Config config) => Create(new LinuxBootstrap(), config);
        public static void Mac(Config config) => Create(new MacBootstrap(), config);
        public static void IOS(Config config) => Create(new IOSBootstrap(), config);
        public static void Web(Config config) => Create(new WebBootstrap(), config);
        
        protected virtual Platform Platform { get; set; }
        internal static Engine Engine { get; set; }
        
        
        internal static void Create(Bootstrap bootstrap, Config config)
        {
            // Initialize Platform
            Platform.Create(bootstrap.Platform, config);

            // Initialize Engine
            Engine = new Engine(config);
            
            // Bootstrap
            bootstrap.Execute();
        }
        
        internal virtual void Execute()
        {
            // Code To Execute
        }

        internal Bootstrap()
        {
            // Constructor
        }
    }
}