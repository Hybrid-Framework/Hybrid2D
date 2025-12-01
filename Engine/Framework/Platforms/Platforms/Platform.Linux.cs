using System;

namespace Hybrid
{
    internal class LinuxPlatform : Platform
    {
        protected internal override IPlatformSystem System { get; set; } = new LinuxSystem();
        protected internal override IPlatformCanvas Canvas { get; set; } = new LinuxCanvas();
    }
}