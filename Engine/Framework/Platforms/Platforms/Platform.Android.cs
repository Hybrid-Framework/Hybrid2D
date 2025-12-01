using System;

namespace Hybrid
{
    internal class AndroidPlatform : Platform
    {
        protected override IPlatformSystem System { get; set; } = new AndroidSystem();
        protected override IPlatformCanvas Canvas { get; set; } = new AndroidCanvas();
        protected override IPlatformEvents Events { get; set; } = new AndroidEvents();
    }
}