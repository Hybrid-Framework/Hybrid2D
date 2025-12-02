using System;

namespace Hybrid
{
    internal class WindowsPlatform : Platform
    {
        protected override IPlatformDisplay Display { get; set; } = new WindowsDisplay();
        protected override IPlatformSystem System { get; set; } = new WindowsSystem();
        protected override IPlatformEvents Events { get; set; } = new WindowsEvents();
    }
}