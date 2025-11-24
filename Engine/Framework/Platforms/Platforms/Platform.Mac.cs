using System;

namespace Hybrid
{
    public class MacPlatform : Platform
    {
        protected override IPlatformDevice Device { get; } = new MacDevice();
        protected override IPlatformCanvas Canvas { get; } = new MacCanvas();
    }
}