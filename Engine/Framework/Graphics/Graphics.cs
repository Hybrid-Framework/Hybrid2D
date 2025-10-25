using System;

namespace Hybrid
{
    public static unsafe class Graphics
    {
        private static void SetRenderColor(Color color)
        {
            SDL.SetRenderDrawColor(Renderer.Handle, color.r, color.g, color.b, color.a);
        }
        
        public static void Clear()
        {
            SDL.RenderClear(Renderer.Handle);
        }

        public static void ClearColor(Color color)
        {
            SetRenderColor(color);
            
            SDL.RenderClear(Renderer.Handle);
        }

        public static void Present()
        {
            SDL.RenderPresent(Renderer.Handle);
        }

        public static void DebugText(int x, int y, string text, Color color)
        {
            SetRenderColor(color);
            
            SDL.RenderDebugText(Renderer.Handle, x, y, text);
        }

        public static void DrawTexture(Texture texture, Rect? rect)
        {
            if (rect.HasValue)
            {
                var sdl = new SDL.FRect()
                {
                    x = rect.Value.x,
                    y = rect.Value.y,
                    w = rect.Value.w,
                    h = rect.Value.h,
                };
                
                SDL.RenderTexture(Renderer.Handle, texture.Handle, null, sdl);
                return;
            }

            SDL.RenderTexture(Renderer.Handle, texture.Handle, null, null);
        }

        public static void DrawText(Font font, int x, int y, string text, Color color)
        {
            var sdl = new SDL.Color()
            {
                r = color.r,
                g = color.g,
                b = color.b,
                a = color.a,
            };
            
            var surface = SDL_ttf.RenderTextSolid(font.Handle, text, sdl);
            var texture = SDL.CreateTextureFromSurface(Renderer.Handle, surface);
            SDL.DestroySurface(surface);
            
            int width = SDL.GetTextureWidth(texture);
            int height = SDL.GetTextureHeight(texture);
            SDL.FRect rect = new SDL.FRect() { x = x, y = y, w = width, h = height };
            
            SDL.RenderTexture(Renderer.Handle, texture, null, rect);
        }

        public static void DebugStats(Color color)
        {
            SetRenderColor(color);
            
            SDL.RenderDebugText(Renderer.Handle, 10, 10, $"Frames Per Second: {Time.Fps:F2}");
            SDL.RenderDebugText(Renderer.Handle, 10, 20, $"Frame Time: {Time.FrameTime:F2}");
            SDL.RenderDebugText(Renderer.Handle, 10, 30, $"Delta Time: {Time.DeltaTime:F4}");
            SDL.RenderDebugText(Renderer.Handle, 10, 40, $"Unscaled Delta Time: {Time.UnscaledDeltaTime:F4}");
            SDL.RenderDebugText(Renderer.Handle, 10, 50, $"Timer: {Time.Timer:F2}");
            SDL.RenderDebugText(Renderer.Handle, 10, 60, $"Unscaled Time: {Time.UnscaledTimer:F2}");
            SDL.RenderDebugText(Renderer.Handle, 10, 70, $"Time Scale: {Time.TimeScale:F2}");
            SDL.RenderDebugText(Renderer.Handle, 10, 80, $"Target FPS: {Window.TargetFPS:F2}");
        }
    }
}