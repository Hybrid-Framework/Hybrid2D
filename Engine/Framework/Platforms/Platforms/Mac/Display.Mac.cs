using System;

namespace Hybrid
{
    // Title
    internal unsafe partial class MacDisplay : IPlatformDisplay
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
    internal unsafe partial class MacDisplay
    {
        public bool SetFullscreen(bool fullscreen)
        {
            return SDL.SetWindowFullscreen(Window.Handle, fullscreen);
        }

        public bool GetFullscreen()
        {
            return Window.Flags.HasFlags(SDL.WindowFlags.Fullscreen);
        }
    }
    
    
    // Borderless
    internal unsafe partial class MacDisplay
    {
        public bool SetBorderless(bool borderless)
        {
            return SDL.SetWindowBordered(Window.Handle, !borderless);
        }

        public bool GetBorderless()
        {
            return Window.Flags.HasFlags(SDL.WindowFlags.Borderless);
        }
    }

    
    // Resizable
    internal unsafe partial class MacDisplay
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
    internal unsafe partial class MacDisplay
    {
        public bool SetMaximized(bool maximized)
        {
            if (maximized)
            {
                return SDL.MaximizeWindow(Window.Handle);
            }
            
            Window.Restore();
            return true;
        }

        public bool GetMaximized()
        {
            return Window.Flags.HasFlags(SDL.WindowFlags.Maximized);
        }
    }

    
    // Minimize
    internal unsafe partial class MacDisplay
    {
        public bool SetMinimized(bool minimized)
        {
            if (minimized)
            {
                return SDL.MinimizeWindow(Window.Handle);
            }
            
            Window.Restore();
            return true;
        }

        public bool GetMinimized()
        {
            return Window.Flags.HasFlags(SDL.WindowFlags.Minimized);
        }
    }

    
    // Resize
    internal unsafe partial class MacDisplay
    {
        public bool Resize()
        {
            return true;
        }
    }
    
    
    // Orientation
    internal unsafe partial class MacDisplay
    {
        public Orientation GetOrientation()
        {
            return (Orientation)SDL.GetCurrentDisplayOrientation(SDL.GetWindowID(Window.Handle));
        }
    }
}