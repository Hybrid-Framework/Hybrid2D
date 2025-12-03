using System;

namespace Hybrid
{
    // Title
    internal unsafe partial class AndroidDisplay : IPlatformDisplay
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
    internal unsafe partial class AndroidDisplay
    {
        public void SetFullscreen(bool fullscreen)
        {
            SDL.SetWindowFullscreen(Window.Handle, true);
        }

        public bool GetFullscreen()
        {
            return Window.HasFlags(SDL.WindowFlags.Fullscreen);
        }
    }
    

    // Resizable
    internal unsafe partial class AndroidDisplay
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
    internal unsafe partial class AndroidDisplay
    {
        public void SetMaximized(bool maximized)
        {
            // stub
        }

        public bool GetMaximized()
        {
            return false;
        }
    }


    // Minimize
    internal unsafe partial class AndroidDisplay
    {
        public void SetMinimized(bool minimized)
        {
            // stub
        }

        public bool GetMinimized()
        {
            return false;
        }
    }
    

    // Resize
    internal unsafe partial class AndroidDisplay
    {
        public void Resize()
        {
            Window.Size = Window.Size;
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