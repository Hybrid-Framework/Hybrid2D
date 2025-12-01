using System;

namespace Hybrid
{
    internal class LinuxPlatform : Platform
    {
        protected override IPlatformSystem System { get; set; } = new LinuxSystem();
        protected override IPlatformCanvas Canvas { get; set; } = new LinuxCanvas();
        protected override IPlatformEvents Events { get; set; } = new LinuxEvents();
    }
}