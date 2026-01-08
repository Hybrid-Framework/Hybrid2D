using System;

namespace Hybrid
{
    public sealed unsafe class Window : Module
    {
        internal static SDL.Window* Handle { get; private set; }
        
        internal Window(int width, int height)
        {
            Handle = SDL.CreateWindow("Hybrid", width, height, SDL.WindowFlags.HighPixelDensity | SDL.WindowFlags.Resizable);
        }
    }
}