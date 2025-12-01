using System;

namespace Hybrid
{
    internal class AndroidPlatform : Platform
    {
        protected internal override IPlatformSystem System { get; set; } = new AndroidSystem();
        protected internal override IPlatformCanvas Canvas { get; set; } = new AndroidCanvas();
    }
}