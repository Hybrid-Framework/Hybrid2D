using System;

namespace Hybrid
{
    internal class IOSPlatform : Platform
    {
        protected internal override IPlatformSystem System { get; set; } = new IOSSystem();
        protected internal override IPlatformCanvas Canvas { get; set; } = new IOSCanvas();
    }
}