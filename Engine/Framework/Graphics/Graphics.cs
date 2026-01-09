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
        public static void DrawRect(Rect rect, Color color)
        {
            DrawRects([rect], [color]);
        }
        
        public static void DrawRects(Rect[] rects, Color[] colors)
        {
            if (rects.Length != colors.Length)
                throw new ArgumentException("All arrays must have the same length.");
            
            int vertexCount = rects.Length * 4;
            int[] indices = new int[rects.Length * 6];
            float[] vertices = new float[vertexCount * 2];
            Color[] vertexColors = new Color[vertexCount];

            for (int i = 0; i < rects.Length; i++)
            {
                var r = rects[i];
                var c = colors[i];
                int vBase = i * 4;
                int iBase = i * 6;

                vertices[(vBase + 0) * 2 + 0] = r.X;
                vertices[(vBase + 0) * 2 + 1] = r.Y;
                vertices[(vBase + 1) * 2 + 0] = r.X + r.W;
                vertices[(vBase + 1) * 2 + 1] = r.Y;
                vertices[(vBase + 2) * 2 + 0] = r.X + r.W;
                vertices[(vBase + 2) * 2 + 1] = r.Y + r.H;
                vertices[(vBase + 3) * 2 + 0] = r.X;
                vertices[(vBase + 3) * 2 + 1] = r.Y + r.H;

                indices[iBase + 0] = vBase + 0;
                indices[iBase + 1] = vBase + 1;
                indices[iBase + 2] = vBase + 2;
                indices[iBase + 3] = vBase + 2;
                indices[iBase + 4] = vBase + 3;
                indices[iBase + 5] = vBase + 0;
                
                vertexColors[vBase + 0] = c;
                vertexColors[vBase + 1] = c;
                vertexColors[vBase + 2] = c;
                vertexColors[vBase + 3] = c;
            }

            DrawGeometryExtended(null, vertices, vertexColors, null, indices);
        }

        public static void DrawLine(Point start, Point end, float thickness, Color color)
        {
            DrawLines([start], [end], [thickness], [color]);
        }
        
        public static void DrawLines(Point[] starts, Point[] ends, float[] thicknesses, Color[] colors)
        {
            if (starts.Length != ends.Length || starts.Length != thicknesses.Length || starts.Length != colors.Length)
                throw new ArgumentException("All arrays must have the same length.");
            
            int count = starts.Length;
            int vertexCount = count * 4;
            float[] vertices = new float[vertexCount * 2];
            Color[] vertexColors = new Color[vertexCount];
            int[] indices = new int[count * 6];

            for (int i = 0; i < count; i++)
            {
                float thickness = thicknesses[i];
                var p0 = starts[i];
                var p1 = ends[i];
                var c = colors[i];

                // TODO: USE OWN VECTOR STRUCT
                var dir = new System.Numerics.Vector2(p1.X - p0.X, p1.Y - p0.Y);
                var perp = System.Numerics.Vector2.Normalize(new System.Numerics.Vector2(-dir.Y, dir.X)) * (thickness / 2);
                int vBase = i * 4;
                int iBase = i * 6;

                vertices[(vBase + 0) * 2 + 0] = p0.X + perp.X;
                vertices[(vBase + 0) * 2 + 1] = p0.Y + perp.Y;
                vertices[(vBase + 1) * 2 + 0] = p1.X + perp.X;
                vertices[(vBase + 1) * 2 + 1] = p1.Y + perp.Y;
                vertices[(vBase + 2) * 2 + 0] = p1.X - perp.X;
                vertices[(vBase + 2) * 2 + 1] = p1.Y - perp.Y;
                vertices[(vBase + 3) * 2 + 0] = p0.X - perp.X;
                vertices[(vBase + 3) * 2 + 1] = p0.Y - perp.Y;

                indices[iBase + 0] = vBase + 0;
                indices[iBase + 1] = vBase + 1;
                indices[iBase + 2] = vBase + 2;
                indices[iBase + 3] = vBase + 2;
                indices[iBase + 4] = vBase + 3;
                indices[iBase + 5] = vBase + 0;
                
                vertexColors[vBase + 0] = c;
                vertexColors[vBase + 1] = c;
                vertexColors[vBase + 2] = c;
                vertexColors[vBase + 3] = c;
            }

            DrawGeometryExtended(null, vertices, vertexColors, null, indices);
        }
        
        public static void DrawPoint(Point p, Color color)
        {
            DrawPoints([p], [color]);
        }

        public static void DrawPoints(Point[] points, Color[] colors, float size = 1f)
        {
            if (points.Length != colors.Length)
                throw new ArgumentException("points and colors must have the same length.");

            int count = points.Length;
            int vertexCount = count * 4;
            float[] vertices = new float[vertexCount * 2];
            Color[] vertexColors = new Color[vertexCount];
            int[] indices = new int[count * 6];

            float half = size / 2f;

            for (int i = 0; i < count; i++)
            {
                var p = points[i];
                var c = colors[i];
                int vBase = i * 4;
                int iBase = i * 6;

                vertices[(vBase + 0) * 2 + 0] = p.X - half;
                vertices[(vBase + 0) * 2 + 1] = p.Y - half;
                vertices[(vBase + 1) * 2 + 0] = p.X + half;
                vertices[(vBase + 1) * 2 + 1] = p.Y - half;
                vertices[(vBase + 2) * 2 + 0] = p.X + half;
                vertices[(vBase + 2) * 2 + 1] = p.Y + half;
                vertices[(vBase + 3) * 2 + 0] = p.X - half;
                vertices[(vBase + 3) * 2 + 1] = p.Y + half;

                indices[iBase + 0] = vBase + 0;
                indices[iBase + 1] = vBase + 1;
                indices[iBase + 2] = vBase + 2;
                indices[iBase + 3] = vBase + 2;
                indices[iBase + 4] = vBase + 3;
                indices[iBase + 5] = vBase + 0;
                
                vertexColors[vBase + 0] = c;
                vertexColors[vBase + 1] = c;
                vertexColors[vBase + 2] = c;
                vertexColors[vBase + 3] = c;
            }

            DrawGeometryExtended(null, vertices, vertexColors, null, indices);
        }

        public static void DrawCircle(Circle circle, Color color, int segments = 32)
        {
            DrawCircles([circle], [color], segments);
        }

        public static void DrawCircles(Circle[] circles, Color[] colors, int segments = 32)
        {
            if (circles.Length != colors.Length)
                throw new ArgumentException("circles and colors must have the same length.");

            int count = circles.Length;
            int vertexCountPerCircle = segments + 1;
            int indexCountPerCircle = segments * 3;
            int totalVertices = count * vertexCountPerCircle;
            int totalIndices = count * indexCountPerCircle;
            float[] positions = new float[totalVertices * 2];
            Color[] vertexColors = new Color[totalVertices];
            int[] indices = new int[totalIndices];

            for (int i = 0; i < count; i++)
            {
                Circle circle = circles[i];
                var color = colors[i];

                int vBase = i * vertexCountPerCircle;
                int iBase = i * indexCountPerCircle;

                positions[vBase * 2 + 0] = circle.X;
                positions[vBase * 2 + 1] = circle.Y;
                vertexColors[vBase] = color;

                for (int j = 0; j < segments; j++)
                {
                    float angle = (float)(2 * Math.PI * j / segments);
                    float x = circle.X + circle.R * (float)Math.Cos(angle);
                    float y = circle.Y + circle.R * (float)Math.Sin(angle);

                    positions[(vBase + 1 + j) * 2 + 0] = x;
                    positions[(vBase + 1 + j) * 2 + 1] = y;
                    vertexColors[vBase + 1 + j] = color;
                }

                for (int j = 0; j < segments; j++)
                {
                    indices[iBase + j * 3 + 0] = vBase;
                    indices[iBase + j * 3 + 1] = vBase + 1 + j;
                    indices[iBase + j * 3 + 2] = vBase + 1 + ((j + 1) % segments);
                }
            }

            DrawGeometryExtended(null, positions, vertexColors, null, indices);
        }

        public static void DrawTexture(Texture texture, Rect? source, Rect? destination)
        {
            var textureHandle = texture == null ? null : texture.Handle;
            {
                SDL.RenderTexture(Handle, textureHandle, source, destination);
            }
        }
        
        public static void DrawTextureExtended(Texture texture, Rect? source, Rect? destination, double angle, Point? center, FlipMode flipMode)
        {
            var textureHandle = texture == null ? null : texture.Handle;
            {
                SDL.RenderTextureRotated(Handle, textureHandle, source, destination, angle, center, (SDL.FlipMode)flipMode);
            }
        }
        
        public static void DrawGeometry(Texture texture, Vertex[] vertices, int[] indices)
        {
            var textureHandle = texture == null ? null : texture.Handle;
            {
                SDL.RenderGeometry(Handle, textureHandle, vertices, vertices.Length, indices, indices.Length);
            }
        }

        public static void DrawGeometryExtended(Texture texture, float[] positions, Color[] colors, float[] uvs, int[] indices)
        {
            var textureHandle = texture == null ? null : texture.Handle;
            {
                SDL.RenderGeometryRaw(Handle, textureHandle, positions, colors, uvs, indices);
            }
        }
        
        public static void DrawDebugText(int x, int y, string text, Color color)
        {
            Color32 color32 = (Color32)color;
            {
                SDL.SetRenderDrawColor(Handle, color32.R, color32.G, color32.B, color32.A);
                SDL.RenderDebugText(Handle, x, y, text);
            }
        }
        
        public static void DrawFps(int x, int y, Color color)
        {
            Color32 color32 = (Color32)color;
            {
                SDL.SetRenderDrawColor(Handle, color32.R, color32.G, color32.B, color32.A);
                SDL.RenderDebugText(Handle, x, y, Time.GetFps().ToString("N0"));
            }
        }
        
        public static void DrawBegin(Color color)
        {
            Color32 color32 = (Color32)color;
            {
                SDL.SetRenderDrawColor(Handle, color32.R, color32.G, color32.B, color32.A);
                SDL.RenderClear(Handle);
            }
        }

        public static void DrawEnd()
        {
            SDL.RenderPresent(Handle);
        }
    }
}