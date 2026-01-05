using System;

namespace Hybrid
{
    // Internal
    public sealed unsafe class Graphics : Module<Graphics>
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
            SDL.RenderDebugText(Handle, 10, 10, $"FPS: {Time.FramesPerSecond.ToString("N0")} MS: {Time.FrameTime}");
            SDL.RenderDebugText(Handle, 10, 30, $"Text: {Input.InputText}");
            
            // Present
            SDL.RenderPresent(Handle);
        }

        // Dispose
        internal override void OnDispose()
        {
            if (Handle != null)
            {
                SDL.DestroyRenderer(Handle);
                Handle = null;
            }
        }
    }
}