using System;

namespace Hybrid
{
    internal class AndroidPlatform : Platform
    {
        protected override IPlatformDisplay Display { get; set; } = new AndroidDisplay();
        protected override IPlatformSystem System { get; set; } = new AndroidSystem();
        protected override IPlatformEvents Events { get; set; } = new AndroidEvents();
    }
}