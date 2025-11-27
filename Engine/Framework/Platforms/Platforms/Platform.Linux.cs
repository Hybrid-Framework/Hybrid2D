using System;

namespace Hybrid
{
    internal class LinuxPlatform : Platform
    {
        protected override IPlatformDevice Device { get; } = new LinuxDevice();
        protected override IPlatformCanvas Canvas { get; } = new LinuxCanvas();
    }
}