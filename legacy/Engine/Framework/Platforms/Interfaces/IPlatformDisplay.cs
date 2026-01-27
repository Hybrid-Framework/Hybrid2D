using System;

namespace Hybrid
{
    internal interface IPlatformDisplay
    {
        Orientation GetOrientation();

        bool SetTitle(string title);
        string GetTitle();
        
        bool SetFullscreen(bool fullscreen);
        bool GetFullscreen();
        
        bool SetBorderless(bool borderless);
        bool GetBorderless();

        bool SetResizable(bool resizable);
        bool GetResizable();

        bool SetMaximized(bool maximized);
        bool GetMaximized();
        
        bool SetMinimized(bool minimized);
        bool GetMinimized();
        
        bool Resize();
    }
}