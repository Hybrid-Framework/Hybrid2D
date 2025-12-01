using System;

namespace Hybrid
{
    internal class WindowsPlatform : Platform
    {
        protected internal override IPlatformSystem System { get; set; } = new WindowsSystem();
        protected internal override IPlatformCanvas Canvas { get; set; } = new WindowsCanvas();
    }
}