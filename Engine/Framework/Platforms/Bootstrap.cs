using System;

namespace Hybrid
{
    // Platform
    public abstract class Bootstrap
    {
        public static void Windows(Config Config) => Entry(new WindowsBootstrap(), Config);
        public static void Android(Config Config) => Entry(new AndroidBootstrap(), Config);
        public static void Linux(Config Config) => Entry(new LinuxBootstrap(), Config);
        public static void Mac(Config Config) => Entry(new MacBootstrap(), Config);
        public static void IOS(Config Config) => Entry(new IOSBootstrap(), Config);
        public static void Web(Config Config) => Entry(new WebBootstrap(), Config);
        
        
        protected static void Entry(Bootstrap bootstrap, Config config)
        {
            bootstrap.Execute(config);
        }

        protected virtual void Execute(Config config)
        {
            // Platform specific bootstrap
        }
    }
}