using System;

namespace Hybrid
{
    internal class MacPlatform : Platform
    {
        protected override IPlatformDisplay Display { get; set; } = new MacDisplay();
        protected override IPlatformSystem System { get; set; } = new MacSystem();
        protected override IPlatformEvents Events { get; set; } = new MacEvents();
    }
}