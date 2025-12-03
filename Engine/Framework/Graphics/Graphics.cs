using System;

namespace Hybrid
{
    // Internal
    public unsafe partial class Graphics : Module<Graphics>
    {
        private Graphics() { }
        
        internal static SDL.Renderer* Handle
        {
            private set;
            get;
        }
        
        
        // Initialize
        internal override void OnInitialize()
        {
            // Create Renderer
            Handle = SDL.CreateRenderer(Window.Handle, null);
            
            base.OnInitialize();
        }
        
        // Render
        internal override void OnRender()
        {
            // Presentation
            SDL.SetRenderDrawColor(Handle, 255, 128, 128, 255);
            SDL.RenderClear(Handle);
            
            // Rendering
            SDL.SetRenderDrawColor(Handle, 255, 255, 255, 255);
            SDL.RenderDebugText(Handle, 10, 10, $"FPS: {Time.Fps.ToString("N0")}");
            
            // Present
            SDL.RenderPresent(Handle);
            
            base.OnRender();
        }

        // Dispose
        internal override void OnDispose()
        {
            if (Handle != null)
            {
                SDL.DestroyRenderer(Handle);
                Handle = null;
            }
            
            base.OnDispose();
        }
    }
}