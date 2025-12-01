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
            if (SDL.SetWindowFullscreen(Window.Handle, fullscreen))
            {
                var state = GetFullscreen();

                if (state)
                {
                    // Enter Fullscreen
                }
                else
                {
                    // Exit Fullscreen
                }

                return true;
            }

            return false;
        }

        public bool GetFullscreen()
        {
            return (SDL.GetWindowFlags(Window.Handle) & SDL.WindowFlags.Fullscreen) != 0;
        }
    }
}