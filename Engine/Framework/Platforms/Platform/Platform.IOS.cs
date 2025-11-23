using System;

namespace Hybrid
{
    public class IOSPlatform : Platform
    {
        internal override IPlatformDevice Device { get; } = new IOSDevice();
        internal override IPlatformSystem System { get; } = new IOSSystem();
    }
}