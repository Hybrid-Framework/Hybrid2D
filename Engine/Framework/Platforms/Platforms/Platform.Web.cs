using System;

namespace Hybrid
{
    public class WebPlatform : Platform
    {
        protected override IPlatformDevice Device { get; } = new WebDevice();
        protected override IPlatformCanvas Canvas { get; } = new WebCanvas();
    }
}