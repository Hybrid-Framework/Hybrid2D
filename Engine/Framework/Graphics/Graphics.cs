using System;

namespace Hybrid
{
    public static unsafe class Graphics
    {
        private static void SetRenderColor(Color color)
        {
            SDL.SetRenderDrawColor(Window.GetRenderer(), color.r, color.g, color.b, color.a);
        }
        
        public static void Clear(Color color)
        {
            SetRenderColor(color);
            
            SDL.RenderClear(Window.GetRenderer());
        }

        public static void Present()
        {
            SDL.RenderPresent(Window.GetRenderer());
        }

        public static void DebugText(int x, int y, string text, Color color)
        {
            SetRenderColor(color);
            
            SDL.RenderDebugText(Window.GetRenderer(), x, y, text);
        }

        public static void DebugStats(Color color)
        {
            SetRenderColor(color);
            
            SDL.RenderDebugText(Window.GetRenderer(), 10, 10, $"Frames Per Second: {Time.fps:F2}");
            SDL.RenderDebugText(Window.GetRenderer(), 10, 20, $"Frame Time: {Time.frameTime:F2}");
            SDL.RenderDebugText(Window.GetRenderer(), 10, 30, $"Delta Time: {Time.deltaTime:F4}");
            SDL.RenderDebugText(Window.GetRenderer(), 10, 40, $"Unscaled Delta Time: {Time.unscaledDeltaTime:F4}");
            SDL.RenderDebugText(Window.GetRenderer(), 10, 50, $"Time: {Time.time:F2}");
            SDL.RenderDebugText(Window.GetRenderer(), 10, 60, $"Unscaled Time: {Time.unscaledTime:F2}");
            SDL.RenderDebugText(Window.GetRenderer(), 10, 70, $"Time Scale: {Time.timeScale:F2}");
        }
    }
}