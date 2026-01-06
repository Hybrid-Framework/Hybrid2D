using System;

namespace Hybrid
{
    // Internal
    public sealed unsafe partial class Graphics : Module
    {
        internal Graphics() { }
        
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

    public unsafe partial class Graphics
    {
        public static void Color(Color32 color)
        {
            SDL.SetRenderDrawColor(Handle, color.R, color.G, color.B, color.A);
        }
        
        public static void Clear()
        {
            SDL.RenderClear(Handle);
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
        
        public static void DrawTexture(Texture texture, Rect uv, Rect position)
        {
            SDL.RenderTexture(Handle, texture.Handle, uv, position);
        }

        public static void DrawGeometry(Texture texture, Vertex[] vertices, int[] indices)
        {
            SDL.RenderGeometry(Handle, texture.Handle, vertices, vertices.Length, indices, indices.Length);
        }

        public static void Present()
        {
            SDL.RenderPresent(Handle);
        }
    }
}