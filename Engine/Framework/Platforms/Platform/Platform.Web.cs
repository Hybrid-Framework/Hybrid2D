using System;

namespace Hybrid
{
    public class WebPlatform : Platform
    {
        internal override IPlatformDevice Device { get; } = new WebDevice();
        internal override IPlatformSystem System { get; } = new WebSystem();
    }
}