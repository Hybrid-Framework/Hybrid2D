using System;

namespace Hybrid
{
    internal class IOSPlatform : Platform
    {
        protected override IPlatformDisplay Display { get; set; } = new IOSDisplay();
        protected override IPlatformSystem System { get; set; } = new IOSSystem();
        protected override IPlatformEvents Events { get; set; } = new IOSEvents();
    }
}