using System;

namespace Hybrid
{
    public unsafe class IOSOrientation : IPlatformOrientation
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