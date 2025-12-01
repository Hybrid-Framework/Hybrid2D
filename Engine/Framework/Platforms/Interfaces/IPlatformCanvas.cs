using System;

namespace Hybrid
{
    internal interface IPlatformCanvas
    {
        Orientation GetOrientation();
        
        bool SetFullscreen(bool fullscreen);
        bool GetFullscreen();
    }
}