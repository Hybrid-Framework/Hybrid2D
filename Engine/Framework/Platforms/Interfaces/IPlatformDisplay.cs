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

        bool SetResizable(bool resizable);
        bool GetResizable();

        bool Maximize();
        bool Minimize();
        bool Restore();

        void Resize();
    }
}