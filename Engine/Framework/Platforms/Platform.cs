using System;

namespace Hybrid
{
    // Platform
    internal abstract partial class Platform
    {
        internal static Platform Current { get; private set; }
        internal static Game Game { get; private set; }
        
        
        internal static void SetPlatform(Platform platform, Game game)
        {
            if(platform == null || game == null)
                throw new Exception($"Invalid Platform Parameters {typeof(Platform)} {typeof(Game)}");
            
            Current = platform;
            Game = game;
        }

        internal static Platform GetPlatform()
        {
            if (Current == null)
                throw new Exception("No Platform Detected");
            
            return Current;
        }
        
        internal static Game GetGame()
        {
            if (Game == null)
                throw new Exception("No Game Detected");
            
            return Game;
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