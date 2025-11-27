using System;

namespace Hybrid
{
    internal class WindowsPlatform : Platform
    {
        protected override IPlatformDevice Device { get; set; } = new WindowsDevice();
        protected override IPlatformCanvas Canvas { get; set; } = new WindowsCanvas();
    }
}