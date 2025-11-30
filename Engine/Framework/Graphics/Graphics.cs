using System;

namespace Hybrid
{
    // Internal
    public unsafe partial class Graphics : Module<Graphics>
    {
        private Graphics() { }
        
        // Initialize
        internal override void OnInitialize()
        {
            // Create Renderer
            Handle = SDL.CreateRenderer(Window.Handle, null);
            Window.VSync = Platform.GetConfig().VSync;
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
        }

        // Dispose
        internal override void OnDispose()
        {
            base.OnDispose();
            
            if (Handle != null)
            {
                SDL.DestroyRenderer(Handle);
                Handle = null;
            }
        }
    }

    // Graphics API
    public unsafe partial class Graphics
    {
        internal static SDL.Renderer* Handle
        {
            private set;
            get;
        }
    }
}