using System;

namespace Hybrid
{
    internal class AndroidPlatform : Platform
    {
        protected override IPlatformDevice Device { get; set; } = new AndroidDevice();
        protected override IPlatformCanvas Canvas { get; set; } = new AndroidCanvas();
    }
}