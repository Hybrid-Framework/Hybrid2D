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
        

        internal Graphics()
        {
            Handle = SDL.CreateRenderer(Window.Handle, null);
        }

        internal override void OnDestroy()
        {
            Console.WriteLine("Graphics Disposed");
            
            if (Handle != null)
            {
                SDL.DestroyRenderer(Handle);
            }
        }
    }

    // Graphics API
    public unsafe partial class Graphics
    {
        internal override void OnRender()
        {
            // Presentation
            SDL.SetRenderDrawColor(Handle, 255, 128, 128, 255);
            SDL.RenderClear(Handle);
            
            // Rendering
            SDL.SetRenderDrawColor(Handle, 255, 255, 255, 255);
            SDL.RenderDebugText(Handle, 10, 10, $"Screen: {Window.Width} {Window.Height}");
            
            // Present
            SDL.RenderPresent(Handle);
        }
    }
}