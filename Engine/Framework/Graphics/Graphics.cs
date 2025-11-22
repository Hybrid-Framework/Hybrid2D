using System;

namespace Hybrid
{
    // Graphics
    public unsafe partial class Graphics : Module
    {
        // SDL Renderer Handle
        internal static SDL.Renderer* Handle
        {
            private set;
            get;
        }

        internal Graphics(Config config)
        {
            Handle = SDL.CreateRenderer(Window.Handle, null);
        }
    }

    // Graphics
    public unsafe partial class Graphics
    {
        internal override void OnRender()
        {
            SDL.SetRenderDrawColor(Handle, 255, 128, 128, 255);
            SDL.RenderClear(Handle);
            
            // Draw Here
            
            SDL.RenderPresent(Handle);
        }
    }
}