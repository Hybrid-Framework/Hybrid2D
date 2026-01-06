using System;

namespace Hybrid
{
    // Platform
    public abstract class Bootstrap
    {
        public static void Windows(Game game) => Entry(new WindowsBootstrap(), game);
        public static void Android(Game game) => Entry(new AndroidBootstrap(), game);
        public static void Linux(Game game) => Entry(new LinuxBootstrap(), game);
        public static void Mac(Game game) => Entry(new MacBootstrap(), game);
        public static void IOS(Game game) => Entry(new IOSBootstrap(), game);
        public static void Web(Game game) => Entry(new WebBootstrap(), game);
        
        protected static void Entry(Bootstrap bootstrap, Game game)
        {
            bootstrap.Execute(game);
        }

        protected virtual void Execute(Game game)
        {
            
        }
    }
}