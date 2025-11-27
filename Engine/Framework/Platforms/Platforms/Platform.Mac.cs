using System;

namespace Hybrid
{
    internal class MacPlatform : Platform
    {
        protected override IPlatformDevice Device { get; set; } = new MacDevice();
        protected override IPlatformCanvas Canvas { get; set; } = new MacCanvas();
    }
}