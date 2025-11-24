using System;

namespace Hybrid
{
    public class IOSPlatform : Platform
    {
        protected override IPlatformDevice Device { get; } = new IOSDevice();
        protected override IPlatformCanvas Canvas { get; } = new IOSCanvas();
    }
}