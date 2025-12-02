using System;

namespace Hybrid
{
    internal unsafe class IOSDisplay : IPlatformDisplay
    {
        public Orientation GetOrientation()
        {
            return (Orientation)SDL.GetCurrentDisplayOrientation(SDL.GetWindowID(Window.Handle));
        }
        
        public bool SetFullscreen(bool fullscreen)
        {
            return SDL.SetWindowFullscreen(Window.Handle, true);
        }

        public bool GetFullscreen()
        {
            return (SDL.GetWindowFlags(Window.Handle) & SDL.WindowFlags.Fullscreen) != 0;
        }
        
        public void Resize()
        {
            Window.Size = Window.Size;
        }
    }
}