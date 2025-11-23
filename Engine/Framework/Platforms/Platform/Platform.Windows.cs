using System;

namespace Hybrid
{
    public class WindowsPlatform : Platform
    {
        internal override IPlatformOrientation PlatformOrientation { get; } = new WindowsOrientation();
        internal override IPlatformResize PlatformResize { get; } = new WindowsResize();
        internal override IPlatformDevice PlatformDevice { get; } = new WindowsDevice();
        internal override IPlatformSystem PlatformSystem { get; } = new WindowsSystem();
    }
}