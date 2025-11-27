using System;

namespace Hybrid
{
    internal class AndroidPlatform : Platform
    {
        protected override IPlatformDevice Device { get; } = new AndroidDevice();
        protected override IPlatformCanvas Canvas { get; } = new AndroidCanvas();
    }
}