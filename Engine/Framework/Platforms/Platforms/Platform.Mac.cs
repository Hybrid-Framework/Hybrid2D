using System;

namespace Hybrid
{
    internal class MacPlatform : Platform
    {
        protected internal override IPlatformSystem System { get; set; } = new MacSystem();
        protected internal override IPlatformCanvas Canvas { get; set; } = new MacCanvas();
    }
}