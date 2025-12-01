using System;

namespace Hybrid
{
    public interface IPlatformCanvas
    {
        Orientation GetNaturalOrientation();
        Orientation GetOrientation();
        
        bool SetFullscreen(bool fullscreen);
        bool GetFullscreen();
    }
}