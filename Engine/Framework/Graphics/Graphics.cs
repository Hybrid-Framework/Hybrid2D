using System;

namespace Hybrid
{
    // Base Graphics
    public static unsafe partial class Graphics
    {
        // Set Render Color
        private static void SetRenderColor(Color color)
        {
            SDL.SetRenderDrawColor(Renderer.Handle, color.R, color.G, color.B, color.A);
        }
        
        // Clear Color
        public static void ClearColor(Color color)
        {
            SetRenderColor(color);

            SDL.RenderClear(Renderer.Handle);
        }

        // Clear Graphics
        public static void Begin()
        {
            SDL.RenderClear(Renderer.Handle);
        }

        // Present Graphics
        public static void Present()
        {
            SDL.RenderPresent(Renderer.Handle);
        }
    }
    
    // Drawing
    public static unsafe partial class Graphics
    {
        // Draw Texture
        public static void DrawTexture(Texture texture, Rect? rect)
        {
            var sdl_FRect = Rect.SDLFRect(rect);
            
            SDL.RenderTexture(Renderer.Handle, texture.Handle, null, sdl_FRect);
        }
        
        // Draw Debug Text
        public static void DrawDebugText(int x, int y, string text, Color color)
        {
            SetRenderColor(color);
            
            SDL.RenderDebugText(Renderer.Handle, x, y, text);
        }
        
        // Draw Debug Stats
        public static void DrawDebugStats(Color color)
        {
            SetRenderColor(color);
            
            SDL.RenderDebugText(Renderer.Handle, 10, 10, $"Frames Per Second: {Time.Fps:F2}");
            SDL.RenderDebugText(Renderer.Handle, 10, 20, $"Frame Time: {Time.FrameTime:F2}");
            SDL.RenderDebugText(Renderer.Handle, 10, 30, $"Delta Time: {Time.DeltaTime:F4}");
            SDL.RenderDebugText(Renderer.Handle, 10, 40, $"Unscaled Delta Time: {Time.UnscaledDeltaTime:F4}");
            SDL.RenderDebugText(Renderer.Handle, 10, 50, $"Timer: {Time.Timer:F2}");
            SDL.RenderDebugText(Renderer.Handle, 10, 60, $"Unscaled Time: {Time.UnscaledTimer:F2}");
            SDL.RenderDebugText(Renderer.Handle, 10, 70, $"Time Scale: {Time.TimeScale:F2}");
            SDL.RenderDebugText(Renderer.Handle, 10, 80, $"Target FPS: {Window.Fps:F2}");
        }
    }
}