using System;

namespace Hybrid
{
    // Graphics API
    public static unsafe class Graphics
    {
        public static void Clear()
        {
            SDL.RenderClear(Engine.GraphicsDevice.Renderer);
        }

        public static void Present()
        {
            SDL.RenderPresent(Engine.GraphicsDevice.Renderer);
        }
        
        public static void ClearColor(Color color)
        {
            SetColor(color);
            Clear();
        }

        public static void DrawTexture(Texture texture, Rect? rect = null)
        {
            SDL.RenderTexture(Engine.GraphicsDevice.Renderer, texture.Handle, null, Rect.SDLFRect(rect));
        }
        
        public static void DrawText(Font font, string text, int x, int y, Color color)
        {
            var surface = SDL_ttf.RenderTextSolid(font.Handle, text, Color.SDLColor(color));

            if (surface != null)
            {
                var texture = SDL.CreateTextureFromSurface(Engine.GraphicsDevice.Renderer, surface);
                
                var rect = new SDL.FRect()
                {
                    x = x,
                    y = y,
                    w = texture->width,
                    h = texture->height
                };
                
                SDL.RenderTexture(Engine.GraphicsDevice.Renderer, texture, null, rect);
                SDL.DestroyTexture(texture);
            }
            
            SDL.DestroySurface(surface);
        }
        
        public static void SetColor(Color color)
        {
            SDL.SetRenderDrawColor(Engine.GraphicsDevice.Renderer, color.R, color.G, color.B, color.A);
        }

        public static void DrawStats(Color color)
        {
            SetColor(color);
            
            SDL.RenderDebugText(Engine.GraphicsDevice.Renderer, 10, 10, $"Target Frames Per Second: {Engine.GraphicsDevice.Fps:F2}");
            SDL.RenderDebugText(Engine.GraphicsDevice.Renderer, 10, 20, $"Frames Per Second: {Time.Fps:F2}");
            SDL.RenderDebugText(Engine.GraphicsDevice.Renderer, 10, 30, $"Frame Time: {Time.FrameTime:F2}");
            SDL.RenderDebugText(Engine.GraphicsDevice.Renderer, 10, 40, $"Delta Time: {Time.DeltaTime:F4}");
            SDL.RenderDebugText(Engine.GraphicsDevice.Renderer, 10, 50, $"Unscaled Delta Time: {Time.UnscaledDeltaTime:F4}");
            SDL.RenderDebugText(Engine.GraphicsDevice.Renderer, 10, 60, $"Timer: {Time.Timer:F2}");
            SDL.RenderDebugText(Engine.GraphicsDevice.Renderer, 10, 70, $"Unscaled Time: {Time.UnscaledTimer:F2}");
            SDL.RenderDebugText(Engine.GraphicsDevice.Renderer, 10, 80, $"Time Scale: {Time.TimeScale:F2}");
            SDL.RenderDebugText(Engine.GraphicsDevice.Renderer, 10, 90, $"VSync: {Engine.GraphicsDevice.VSync}");
        }
    }
}