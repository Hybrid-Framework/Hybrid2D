using System;

namespace Hybrid
{
    // Orientation
    internal unsafe partial class MacCanvas : IPlatformCanvas
    {
        public Orientation GetOrientation()
        {
            return (Orientation)SDL.GetCurrentDisplayOrientation(SDL.GetWindowID(Window.Handle));
        }
    }
    
    // Fullscreen
    internal unsafe partial class MacCanvas
    {
        public bool SetFullscreen(bool fullscreen)
        {
            return SDL.SetWindowFullscreen(Window.Handle, fullscreen);
        }

        public bool GetFullscreen()
        {
            return (SDL.GetWindowFlags(Window.Handle) & SDL.WindowFlags.Fullscreen) != 0;
        }
    }
    
    // Resize
    internal unsafe partial class MacCanvas
    {
        public void Resize()
        {
            
        }
    }
}