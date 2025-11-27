using System;

namespace Hybrid
{
    internal class IOSPlatform : Platform
    {
        protected override IPlatformDevice Device { get; set; } = new IOSDevice();
        protected override IPlatformCanvas Canvas { get; set; } = new IOSCanvas();
    }
}