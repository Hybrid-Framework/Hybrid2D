using System;

namespace Hybrid
{
    internal unsafe class IOSDisplay : IPlatformDisplay
    {
        public Orientation GetOrientation()
        {
            return (Orientation)SDL.GetCurrentDisplayOrientation(SDL.GetWindowID(Window.Handle));
        }
        
        public bool SetTitle(string title)
        {
            return SDL.SetWindowTitle(Window.Handle, title);
        }

        public string GetTitle()
        {
            return SDL.GetWindowTitle(Window.Handle);
        }
        
        public bool SetFullscreen(bool fullscreen)
        {
            return SDL.SetWindowFullscreen(Window.Handle, true);
        }

        public bool GetFullscreen()
        {
            return (SDL.GetWindowFlags(Window.Handle) & SDL.WindowFlags.Fullscreen) != 0;
        }
        
        public bool SetResizable(bool resizable)
        {
            return SDL.SetWindowResizable(Window.Handle, resizable);
        }

        public bool GetResizable()
        {
            return (SDL.GetWindowFlags(Window.Handle) & SDL.WindowFlags.Resizable) != 0;
        }

        public bool Maximize()
        {
            return SDL.MaximizeWindow(Window.Handle);
        }
        
        public bool Minimize()
        {
            return SDL.MinimizeWindow(Window.Handle);
        }

        public bool Restore()
        {
            return SDL.RestoreWindow(Window.Handle);
        }
        
        public void Resize()
        {
            Window.Size = Window.Size;
        }
    }
}