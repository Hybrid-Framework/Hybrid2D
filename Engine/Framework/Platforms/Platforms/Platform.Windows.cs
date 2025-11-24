using System;

namespace Hybrid
{
    public class WindowsPlatform : Platform
    {
        protected override IPlatformDevice Device { get; } = new WindowsDevice();
        protected override IPlatformCanvas Canvas { get; } = new WindowsCanvas();
    }
}