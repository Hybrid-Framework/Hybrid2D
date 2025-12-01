using System;

namespace Hybrid
{
    internal class WebPlatform : Platform
    {
        protected internal override IPlatformSystem System { get; set; } = new WebSystem();
        protected internal override IPlatformCanvas Canvas { get; set; } = new WebCanvas();
    }
}