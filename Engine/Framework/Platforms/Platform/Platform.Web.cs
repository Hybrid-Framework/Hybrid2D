using System;

namespace Hybrid
{
    public class WebPlatform : Platform
    {
        internal override IPlatformOrientation PlatformOrientation { get; } = new WebOrientation();
        internal override IPlatformResize PlatformResize { get; } = new WebResize();
        internal override IPlatformDevice PlatformDevice { get; } = new WebDevice();
        internal override IPlatformSystem PlatformSystem { get; } = new WebSystem();
    }
}