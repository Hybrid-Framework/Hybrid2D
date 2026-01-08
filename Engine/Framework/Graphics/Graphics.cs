using System;

namespace Hybrid
{
    public sealed unsafe class Graphics : Module
    {
        internal static SDL.Renderer* Handle { get; private set; }
        
        internal Graphics()
        {
            Handle = SDL.CreateRenderer(Window.Handle, null);
            SDL.SetRenderVSync(Handle, 1);
        }
    }
}