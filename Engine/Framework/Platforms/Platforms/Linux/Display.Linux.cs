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
            return Window.HasFlags(SDL.WindowFlags.Fullscreen);
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
            return Window.HasFlags(SDL.WindowFlags.Resizable);
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
            return Window.HasFlags(SDL.WindowFlags.Maximized);
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
            return Window.HasFlags(SDL.WindowFlags.Minimized);
        }
    }
    

    // Resize
    internal unsafe partial class LinuxDisplay
    {
        public void Resize()
        {
            Window.Size = Window.Size;
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