using System;

namespace Hybrid
{
    public class LinuxPlatform : Platform
    {
        internal override IPlatformOrientation PlatformOrientation { get; } = new LinuxOrientation();
        internal override IPlatformResize PlatformResize { get; } = new LinuxResize();
        internal override IPlatformDevice PlatformDevice { get; } = new LinuxDevice();
        internal override IPlatformSystem PlatformSystem { get; } = new LinuxSystem();
    }
}