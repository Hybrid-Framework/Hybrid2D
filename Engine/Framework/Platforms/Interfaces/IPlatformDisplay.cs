using System;

namespace Hybrid
{
    internal interface IPlatformDisplay
    {
        Orientation GetOrientation();
        
        bool SetFullscreen(bool fullscreen);
        bool GetFullscreen();

        void Resize();
    }
}