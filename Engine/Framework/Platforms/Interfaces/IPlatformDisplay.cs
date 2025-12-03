using System;

namespace Hybrid
{
    internal interface IPlatformDisplay
    {
        Orientation GetOrientation();

        void SetTitle(string title);
        string GetTitle();
        
        void SetFullscreen(bool fullscreen);
        bool GetFullscreen();

        void SetResizable(bool resizable);
        bool GetResizable();

        void SetMaximized(bool maximized);
        bool GetMaximized();
        
        void SetMinimized(bool minimized);
        bool GetMinimized();
        
        void Restore();
        void Resize();
    }
}