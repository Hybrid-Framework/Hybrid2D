using System;

namespace Hybrid
{
    public class LinuxPlatform : Platform
    {
        internal override IPlatformDevice Device { get; } = new LinuxDevice();
        internal override IPlatformSystem System { get; } = new LinuxSystem();
    }
}