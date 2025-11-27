using System;

namespace Hybrid
{
    internal class WebPlatform : Platform
    {
        protected override IPlatformDevice Device { get; set; } = new WebDevice();
        protected override IPlatformCanvas Canvas { get; set; } = new WebCanvas();
    }
}