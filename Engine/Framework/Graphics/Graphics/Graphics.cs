using System;

namespace Hybrid
{
    // Internal
    public unsafe partial class Graphics : Module<Graphics>
    {
        private Graphics() { }
        
        // SDL Renderer Handle
        internal static SDL.Renderer* Handle
        {
            private set;
            get;
        }
        
        
        // Initialize
        internal override void OnInitialize()
        {
            // Render Creation
            Handle = SDL.CreateRenderer(Window.Handle, null);
            
            base.OnInitialize();
        }
        
        // Render
        internal override void OnRender()
        {
            // TODO: PRESENTATION SUCH AS LETTERBOX, ETC
            // THIS ALREADY WORKS BUT NO BLACK BARS
            
            // Clear
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