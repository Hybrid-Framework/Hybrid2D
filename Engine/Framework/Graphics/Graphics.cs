using System;

namespace Hybrid
{
    // Internal
    public sealed unsafe partial class Graphics : Module
    {
        internal static SDL.Renderer* Handle
        {
            get; private set;
        }
        
        internal Graphics(bool vsync)
        {
            Handle = SDL.CreateRenderer(Window.Handle, null);
            {
                SDL.SetRenderVSync(Handle, vsync ? 1 : 0);
            }
            
            SDL.SetDefaultTextureScaleMode(Handle, SDL.ScaleMode.Pixel);
        }

        internal override void OnDispose()
        {
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
        public static void DrawTexture(Texture texture, Rect source, Rect destination)
        {
            SDL.RenderTexture(Handle, texture.Handle, source, destination);
        }
        
        public static void DrawRect(Rect rect)
        {
            SDL.RenderFillRect(Handle, rect);
        }

        public static void DrawRects(Rect[] rects)
        {
            SDL.RenderFillRects(Handle, rects, rects.Length);
        }

        public static void DrawLine(Point start, Point end)
        {
            SDL.RenderLine(Handle, start.X, start.Y, end.X, end.Y);
        }

        public static void DrawLines(Point[] points)
        {
            SDL.RenderLines(Handle, points, points.Length);
        }

        public static void DrawPoint(Point point)
        {
            SDL.RenderPoint(Handle, point.X, point.Y);
        }
        
        public static void DrawPoints(Point[] points)
        {
            SDL.RenderPoints(Handle, points, points.Length);
        }
        
        public static void DrawColor(Color32 color)
        {
            SDL.SetRenderDrawColor(Handle, color.R, color.G, color.B, color.A);
        }
        
        public static void DrawDebugText(int x, int y, string text)
        {
            SDL.RenderDebugText(Handle, x, y, text);
        }
        
        public static void DrawFps(int x, int y)
        {
            SDL.RenderDebugText(Handle, x, y, Time.GetFps().ToString("N0"));
        }
        
        public static void DrawClear()
        {
            SDL.RenderClear(Handle);
        }

        public static void DrawPresent()
        {
            SDL.RenderPresent(Handle);
        }
    }
}