using System;

namespace Hybrid
{
    internal class MacPlatform : Platform
    {
        protected override IPlatformSystem System { get; set; } = new MacSystem();
        protected override IPlatformCanvas Canvas { get; set; } = new MacCanvas();
        protected override IPlatformEvents Events { get; set; } = new MacEvents();
    }
}