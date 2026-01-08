using System;

namespace Hybrid
{
    // Internal
    public sealed unsafe class Window : Module
    {
        internal static SDL.Window* Handle
        {
            private set;
            get;
        }
        
        internal Window(string title, int width, int height)
        {
            Handle = SDL.CreateWindow(title, width, height, SDL.WindowFlags.HighPixelDensity);
        }
        
        internal override void OnDispose()
        {
            if (Handle != null)
            {
                SDL.DestroyWindow(Handle);
                Handle = null;
            }
        }
    }
}