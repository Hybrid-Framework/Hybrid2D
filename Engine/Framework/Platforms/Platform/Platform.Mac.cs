using System;

namespace Hybrid
{
    public class MacPlatform : Platform
    {
        internal override IPlatformDevice Device { get; } = new MacDevice();
        internal override IPlatformSystem System { get; } = new MacSystem();
    }
}