using System;

namespace Hybrid
{
    internal unsafe class IOSCanvas : IPlatformCanvas
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
}