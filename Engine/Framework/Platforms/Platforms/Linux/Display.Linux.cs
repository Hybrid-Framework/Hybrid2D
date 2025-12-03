using System;

namespace Hybrid
{
    // Title
    internal unsafe partial class LinuxDisplay : IPlatformDisplay
    {
        public void SetTitle(string title)
        {
            SDL.SetWindowTitle(Window.Handle, title);
        }

        public string GetTitle()
        {
            return SDL.GetWindowTitle(Window.Handle);
        }
    }

    
    // Fullscreen
    internal unsafe partial class LinuxDisplay
    {
        public void SetFullscreen(bool fullscreen)
        {
            SDL.SetWindowFullscreen(Window.Handle, fullscreen);
        }

        public bool GetFullscreen()
        {
            return (SDL.GetWindowFlags(Window.Handle) & SDL.WindowFlags.Fullscreen) != 0;
        }
    }

    
    // Resizable
    internal unsafe partial class LinuxDisplay
    {
        public void SetResizable(bool resizable)
        {
            SDL.SetWindowResizable(Window.Handle, resizable);
        }

        public bool GetResizable()
        {
            return (SDL.GetWindowFlags(Window.Handle) & SDL.WindowFlags.Resizable) != 0;
        }
    }


    // Maximize
    internal unsafe partial class LinuxDisplay
    {
        public void SetMaximized(bool maximized)
        {
            if (maximized)
            {
                SDL.MaximizeWindow(Window.Handle);
            }
            else
            {
                Window.Restore();
            }
        }

        public bool GetMaximized()
        {
            return (SDL.GetWindowFlags(Window.Handle) & SDL.WindowFlags.Maximized) != 0;
        }
    }

    
    // Minimize
    internal unsafe partial class LinuxDisplay
    {
        public void SetMinimized(bool minimized)
        {
            if (minimized)
            {
                SDL.MinimizeWindow(Window.Handle);
            }
            else
            {
                Window.Restore();
            }
        }

        public bool GetMinimized()
        {
            return (SDL.GetWindowFlags(Window.Handle) & SDL.WindowFlags.Minimized) != 0;
        }
    }
    

    // Resize
    internal unsafe partial class LinuxDisplay
    {
        public void Resize()
        {
            Window.SetSize(Window.GetSize());
        }
    }
    
    
    // Orientation
    internal unsafe partial class LinuxDisplay
    {
        public Orientation GetOrientation()
        {
            return (Orientation)SDL.GetCurrentDisplayOrientation(SDL.GetWindowID(Window.Handle));
        }
    }
}