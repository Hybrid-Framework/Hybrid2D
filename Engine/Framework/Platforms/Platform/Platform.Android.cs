using System;

namespace Hybrid
{
    public class AndroidPlatform : Platform
    {
        internal override IPlatformDevice Device { get; } = new AndroidDevice();
        internal override IPlatformSystem System { get; } = new AndroidSystem();
    }
}