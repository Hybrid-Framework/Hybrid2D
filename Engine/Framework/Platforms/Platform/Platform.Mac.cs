using System;

namespace Hybrid
{
    public class MacPlatform : Platform
    {
        internal override IPlatformOrientation PlatformOrientation { get; } = new MacOrientation();
        internal override IPlatformResize PlatformResize { get; } = new MacResize();
        internal override IPlatformDevice PlatformDevice { get; } = new MacDevice();
        internal override IPlatformSystem PlatformSystem { get; } = new MacSystem();
    }
}