using System;

namespace Hybrid
{
    // Graphics Device (Render)
    public static unsafe partial class GraphicsDevice
    {
        public static void Clear()
        {
            SDL.RenderClear(Renderer);
        }

        public static void Present()
        {
            SDL.RenderPresent(Renderer);
        }
        
        public static void ClearColor(Color color)
        {
            SetColor(color);
            Clear();
        }

        public static void DrawTexture(Texture texture, Rect? rect)
        {
            SDL.RenderTexture(Renderer, texture.Handle, null, Rect.SDLFRect(rect));
        }
        
        private static void SetColor(Color color)
        {
            SDL.SetRenderDrawColor(Renderer, color.R, color.G, color.B, color.A);
        }

        public static void DrawStats(Color color)
        {
            SetColor(color);
            
            SDL.RenderDebugText(Renderer, 10, 10, $"Target Frames Per Second: {Fps:F2}");
            SDL.RenderDebugText(Renderer, 10, 20, $"Frames Per Second: {Time.Fps:F2}");
            SDL.RenderDebugText(Renderer, 10, 30, $"Frame Time: {Time.FrameTime:F2}");
            SDL.RenderDebugText(Renderer, 10, 40, $"Delta Time: {Time.DeltaTime:F4}");
            SDL.RenderDebugText(Renderer, 10, 50, $"Unscaled Delta Time: {Time.UnscaledDeltaTime:F4}");
            SDL.RenderDebugText(Renderer, 10, 60, $"Timer: {Time.Timer:F2}");
            SDL.RenderDebugText(Renderer, 10, 70, $"Unscaled Time: {Time.UnscaledTimer:F2}");
            SDL.RenderDebugText(Renderer, 10, 80, $"Time Scale: {Time.TimeScale:F2}");
            SDL.RenderDebugText(Renderer, 10, 90, $"VSync: {VSync}");
        }
    }
}