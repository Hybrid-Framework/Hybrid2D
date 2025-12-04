using System;

namespace Hybrid
{
    // Title
    internal unsafe partial class AndroidDisplay : IPlatformDisplay
    {
        public bool SetTitle(string title)
        {
            return SDL.SetWindowTitle(Window.Handle, title);
        }

        public string GetTitle()
        {
            return SDL.GetWindowTitle(Window.Handle);
        }
    }

    
    // Fullscreen
    internal unsafe partial class AndroidDisplay
    {
        public bool SetFullscreen(bool fullscreen)
        {
            return SDL.SetWindowFullscreen(Window.Handle, true);
        }

        public bool GetFullscreen()
        {
            return Window.Flags.HasFlags(SDL.WindowFlags.Fullscreen);
        }
    }
    

    // Resizable
    internal unsafe partial class AndroidDisplay
    {
        public bool SetResizable(bool resizable)
        {
            return SDL.SetWindowResizable(Window.Handle, resizable);
        }

        public bool GetResizable()
        {
            return Window.Flags.HasFlags(SDL.WindowFlags.Resizable);
        }
    }
    

    // Maximize
    internal unsafe partial class AndroidDisplay
    {
        public bool SetMaximized(bool maximized)
        {
            return false;
        }

        public bool GetMaximized()
        {
            return false;
        }
    }


    // Minimize
    internal unsafe partial class AndroidDisplay
    {
        public bool SetMinimized(bool minimized)
        {
            return false;
        }

        public bool GetMinimized()
        {
            return false;
        }
    }
    

    // Resize
    internal unsafe partial class AndroidDisplay
    {
        public bool Resize()
        {
            return true;
        }
    }
    
    
    // Orientation
    internal unsafe partial class AndroidDisplay
    {
        public Orientation GetOrientation()
        {
            return (Orientation)SDL.GetCurrentDisplayOrientation(SDL.GetWindowID(Window.Handle));
        }
    }
}