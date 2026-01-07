using System;

namespace Hybrid
{
    internal class LinuxPlatform : Platform
    {
        protected override IPlatformDisplay Display { get; set; } = new LinuxDisplay();
        protected override IPlatformSystem System { get; set; } = new LinuxSystem();
        protected override IPlatformEvents Events { get; set; } = new LinuxEvents();
    }
}