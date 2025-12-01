using System;

namespace Hybrid
{
    public interface IPlatformCanvas
    {
        Orientation GetOrientation();
        
        bool SetFullscreen(bool fullscreen);
        bool GetFullscreen();
    }
}