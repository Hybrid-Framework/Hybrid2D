using System;

namespace Hybrid
{
    internal class WebPlatform : Platform
    {
        protected override IPlatformDisplay Display { get; set; } = new WebDisplay();
        protected override IPlatformSystem System { get; set; } = new WebSystem();
        protected override IPlatformEvents Events { get; set; } = new WebEvents();
    }
}