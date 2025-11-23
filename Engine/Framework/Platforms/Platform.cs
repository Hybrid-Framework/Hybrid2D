using System;

namespace Hybrid
{
    // Platform
    public partial class Platform
    {
        internal virtual IPlatformDevice Device { get; } = null;
        internal virtual IPlatformSystem System { get; } = null;
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
            return Current?.Device.GetDevice() ?? Hybrid.Device.Unknown;
        }
        
        public static System GetSystem()
        {
            return Current?.System.GetSystem() ?? Hybrid.System.Unknown;
        }

        public static void Quit()
        {
            Bootstrap.Engine?.Quit();
        }
    }
}