using System;

namespace Hybrid
{
    internal unsafe class LinuxDisplay : IPlatformDisplay
    {
        // Title
        public void SetTitle(string title)
        {
            SDL.SetWindowTitle(Window.Handle, title);
        }

        public string GetTitle()
        {
            return SDL.GetWindowTitle(Window.Handle);
        }
        
        // Fullscreen
        public void SetFullscreen(bool fullscreen)
        {
            SDL.SetWindowFullscreen(Window.Handle, fullscreen);
        }

        public bool GetFullscreen()
        {
            return (SDL.GetWindowFlags(Window.Handle) & SDL.WindowFlags.Fullscreen) != 0;
        }

        // Resizable
        public void SetResizable(bool resizable)
        {
            SDL.SetWindowResizable(Window.Handle, resizable);
        }

        public bool GetResizable()
        {
            return (SDL.GetWindowFlags(Window.Handle) & SDL.WindowFlags.Resizable) != 0;
        }

        // Maximize
        public void SetMaximized(bool maximized)
        {
            if (maximized)
            {
                SDL.MaximizeWindow(Window.Handle);
            }
            else
            {
                Restore();
            }
        }

        public bool GetMaximized()
        {
            return (SDL.GetWindowFlags(Window.Handle) & SDL.WindowFlags.Maximized) != 0;
        }

        // Minimize
        public void SetMinimized(bool minimized)
        {
            if (minimized)
            {
                SDL.MinimizeWindow(Window.Handle);
            }
            else
            {
                Restore();
            }
        }

        public bool GetMinimized()
        {
            return (SDL.GetWindowFlags(Window.Handle) & SDL.WindowFlags.Minimized) != 0;
        }

        // Restore
        public void Restore()
        {
            Window.Restore();
        }
        
        // Resize
        public void Resize()
        {
            Window.Size = Window.Size;
        }
        
        // Orientation
        public Orientation GetOrientation()
        {
            return (Orientation)SDL.GetCurrentDisplayOrientation(SDL.GetWindowID(Window.Handle));
        }
    }
}