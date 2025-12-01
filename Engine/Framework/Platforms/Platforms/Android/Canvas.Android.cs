using System;

namespace Hybrid
{
    // Orientation
    internal unsafe partial class AndroidCanvas : IPlatformCanvas
    {
        public Orientation GetNaturalOrientation()
        {
            return (Orientation)SDL.GetNaturalDisplayOrientation(SDL.GetWindowID(Window.Handle));
        }

        public Orientation GetOrientation()
        {
            return (Orientation)SDL.GetCurrentDisplayOrientation(SDL.GetWindowID(Window.Handle));
        }
    }
    
    // Fullscreen
    internal unsafe partial class AndroidCanvas
    {
        public bool SetFullscreen(bool fullscreen)
        {
            fullscreen = true; // Force fullscreen
            
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