using System;

namespace Hybrid
{
    // Platform
    public partial class Platform
    {
        // Platform Specifics
        internal virtual IPlatformOrientation PlatformOrientation { get; } = null;
        internal virtual IPlatformResize PlatformResize { get; } = null;
        internal virtual IPlatformDevice PlatformDevice { get; } = null;
        internal virtual IPlatformSystem PlatformSystem { get; } = null;
        
        internal static Platform Current { get; set; }

        internal static void Create(Platform platform, Config config)
        {
            // Set Platform
            Current = platform;
        }
    }

    // Platform Methods
    public partial class Platform
    {
        public static Device GetDevice()
        {
            return Current?.PlatformDevice?.GetDevice() ?? Hybrid.Device.Unknown;
        }
        
        public static System GetSystem()
        {
            return Current?.PlatformSystem?.GetSystem() ?? Hybrid.System.Unknown;
        }

        public static Orientation GetOrientation()
        {
            return Current?.PlatformOrientation?.GetOrientation() ?? Hybrid.Orientation.Unknown;
        }
        
        public static Orientation GetNaturalOrientation()
        {
            return Current?.PlatformOrientation?.GetNaturalOrientation() ?? Hybrid.Orientation.Unknown;
        }

        public static void Resize()
        {
            Current?.PlatformResize?.Resize();
        }

        public static void Quit()
        {
            Bootstrap.Engine?.Quit();
        }
    }
}