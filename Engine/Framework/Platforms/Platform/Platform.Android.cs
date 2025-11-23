using System;

namespace Hybrid
{
    public class AndroidPlatform : Platform
    {
        internal override IPlatformOrientation PlatformOrientation { get; } = new AndroidOrientation();
        internal override IPlatformResize PlatformResize { get; } = new AndroidResize();
        internal override IPlatformDevice PlatformDevice { get; } = new AndroidDevice();
        internal override IPlatformSystem PlatformSystem { get; } = new AndroidSystem();
    }
}