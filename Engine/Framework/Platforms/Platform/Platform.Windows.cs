using System;

namespace Hybrid
{
    public class WindowsPlatform : Platform
    {
        internal override IPlatformDevice Device { get; } = new WindowsDevice();
        internal override IPlatformSystem System { get; } = new WindowsSystem();
    }
}