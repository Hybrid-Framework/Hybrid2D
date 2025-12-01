using System;

namespace Hybrid
{
    internal class WebPlatform : Platform
    {
        protected override IPlatformSystem System { get; set; } = new WebSystem();
        protected override IPlatformCanvas Canvas { get; set; } = new WebCanvas();
        protected override IPlatformEvents Events { get; set; } = new WebEvents();
    }
}