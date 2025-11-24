using System;

namespace Hybrid
{
    // Platform
    public partial class Platform
    {
        // Platform Specifics
        protected virtual IPlatformDevice Device { get; } = null;
        protected virtual IPlatformCanvas Canvas { get; } = null;
        
        protected static Platform Current { get; set; }

        internal static void Create(Platform platform, Config config)
        {
            // Set Platform
            Current = platform;
        }
    }

    // Public API
    public partial class Platform
    {
        public static Device GetDevice()
        {
            return Current?.Device?.GetDevice() ?? Hybrid.Device.Unknown;
        }
        
        public static System GetSystem()
        {
            return Current?.Device?.GetSystem() ?? System.Unknown;
        }

        public static void Quit()
        {
            Bootstrap.Engine?.Quit();
        }
    }

    // Engine API
    public partial class Platform
    {
        internal static Orientation GetOrientation()
        {
            return Current?.Canvas?.GetOrientation() ?? Orientation.Unknown;
        }
        
        internal static Orientation GetNaturalOrientation()
        {
            return Current?.Canvas?.GetNaturalOrientation() ?? Orientation.Unknown;
        }

        internal static void HandleResize()
        {
            Current?.Canvas?.HandleResize();
        }
    }
}