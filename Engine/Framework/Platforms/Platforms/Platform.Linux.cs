using System;

namespace Hybrid
{
    internal class LinuxPlatform : Platform
    {
        protected override IPlatformDevice Device { get; set; } = new LinuxDevice();
        protected override IPlatformCanvas Canvas { get; set; } = new LinuxCanvas();
    }
}