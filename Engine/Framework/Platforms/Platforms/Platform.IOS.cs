using System;

namespace Hybrid
{
    internal class IOSPlatform : Platform
    {
        protected override IPlatformSystem System { get; set; } = new IOSSystem();
        protected override IPlatformCanvas Canvas { get; set; } = new IOSCanvas();
        protected override IPlatformEvents Events { get; set; } = new IOSEvents();
    }
}