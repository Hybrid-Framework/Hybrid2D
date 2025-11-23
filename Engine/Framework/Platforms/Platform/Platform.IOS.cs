using System;

namespace Hybrid
{
    public class IOSPlatform : Platform
    {
        internal override IPlatformOrientation PlatformOrientation { get; } = new IOSOrientation();
        internal override IPlatformResize PlatformResize { get; } = new IOSResize();
        internal override IPlatformDevice PlatformDevice { get; } = new IOSDevice();
        internal override IPlatformSystem PlatformSystem { get; } = new IOSSystem();
    }
}