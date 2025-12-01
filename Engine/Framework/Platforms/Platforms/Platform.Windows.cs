using System;

namespace Hybrid
{
    internal class WindowsPlatform : Platform
    {
        protected override IPlatformSystem System { get; set; } = new WindowsSystem();
        protected override IPlatformCanvas Canvas { get; set; } = new WindowsCanvas();
        protected override IPlatformEvents Events { get; set; } = new WindowsEvents();
    }
}