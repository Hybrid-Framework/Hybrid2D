using System;

namespace Hybrid
{
    // Internal
    public sealed unsafe partial class Graphics : Module
    {
        internal Graphics() { }
        
        internal static SDL.Renderer* Handle
        {
            get; set;
        }

        // Initialize
        internal override void OnInitialize()
        {
            Handle = SDL.CreateRenderer(Window.Handle, null);
            {
                SDL.SetDefaultTextureScaleMode(Handle, SDL.ScaleMode.Pixel);
                SDL.SetRenderVSync(Handle, 1);
            }
        }

        // Dispose
        internal override void Destroy()
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
        public static void DrawRect(Rectangle rectangle, Color color)
        {
            DrawRects([rectangle], [color]);
        }
        
        public static void DrawRects(Rectangle[] rects, Color[] colors)
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

                vertices[(vBase + 0) * 2 + 0] = r.x;
                vertices[(vBase + 0) * 2 + 1] = r.y;
                vertices[(vBase + 1) * 2 + 0] = r.x + r.width;
                vertices[(vBase + 1) * 2 + 1] = r.y;
                vertices[(vBase + 2) * 2 + 0] = r.x + r.width;
                vertices[(vBase + 2) * 2 + 1] = r.y + r.height;
                vertices[(vBase + 3) * 2 + 0] = r.x;
                vertices[(vBase + 3) * 2 + 1] = r.y + r.height;

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

            DrawGeometry(null, vertices, vertexColors, null, indices);
        }

        public static void DrawLine(Line line, Color color)
        {
            DrawLines([line], [color]);
        }
        
        public static void DrawLines(Line[] lines, Color[] colors)
        {
            if (lines.Length != colors.Length)
                throw new ArgumentException("All arrays must have the same length.");
            
            int count = lines.Length;
            int vertexCount = count * 4;
            float[] vertices = new float[vertexCount * 2];
            Color[] vertexColors = new Color[vertexCount];
            int[] indices = new int[count * 6];

            for (int i = 0; i < count; i++)
            {
                float thickness = lines[i].thickness;
                var p0 = lines[i].start;
                var p1 = lines[i].end;
                var c = colors[i];

                // TODO: USE OWN VECTOR STRUCT
                var dir = new System.Numerics.Vector2(p1.x - p0.x, p1.y - p0.y);
                var perp = System.Numerics.Vector2.Normalize(new System.Numerics.Vector2(-dir.Y, dir.X)) * (thickness / 2);
                int vBase = i * 4;
                int iBase = i * 6;

                vertices[(vBase + 0) * 2 + 0] = p0.x + perp.X;
                vertices[(vBase + 0) * 2 + 1] = p0.y + perp.Y;
                vertices[(vBase + 1) * 2 + 0] = p1.x + perp.X;
                vertices[(vBase + 1) * 2 + 1] = p1.y + perp.Y;
                vertices[(vBase + 2) * 2 + 0] = p1.x - perp.X;
                vertices[(vBase + 2) * 2 + 1] = p1.y - perp.Y;
                vertices[(vBase + 3) * 2 + 0] = p0.x - perp.X;
                vertices[(vBase + 3) * 2 + 1] = p0.y - perp.Y;

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

            DrawGeometry(null, vertices, vertexColors, null, indices);
        }
        
        public static void DrawPoint(Point point, Color color)
        {
            DrawPoints([point], [color]);
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

                vertices[(vBase + 0) * 2 + 0] = p.x - half;
                vertices[(vBase + 0) * 2 + 1] = p.y - half;
                vertices[(vBase + 1) * 2 + 0] = p.x + half;
                vertices[(vBase + 1) * 2 + 1] = p.y - half;
                vertices[(vBase + 2) * 2 + 0] = p.x + half;
                vertices[(vBase + 2) * 2 + 1] = p.y + half;
                vertices[(vBase + 3) * 2 + 0] = p.x - half;
                vertices[(vBase + 3) * 2 + 1] = p.y + half;

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

            DrawGeometry(null, vertices, vertexColors, null, indices);
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

                positions[vBase * 2 + 0] = circle.x;
                positions[vBase * 2 + 1] = circle.y;
                vertexColors[vBase] = color;

                for (int j = 0; j < segments; j++)
                {
                    float angle = (float)(2 * Math.PI * j / segments);
                    float x = circle.x + circle.radius * (float)Math.Cos(angle);
                    float y = circle.y + circle.radius * (float)Math.Sin(angle);

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

            DrawGeometry(null, positions, vertexColors, null, indices);
        }
        
        public static void DrawTexture(Texture texture, Rectangle? position)
        {
            var textureHandle = texture == null ? null : texture.Handle;
            {
                SDL.RenderTexture(Handle, textureHandle, null, Rectangle.ToSDLRect(position));
            }
        }
        
        public static void DrawTexture(Texture texture, Rectangle? uv, Rectangle? position)
        {
            var textureHandle = texture == null ? null : texture.Handle;
            {
                SDL.RenderTexture(Handle, textureHandle, Rectangle.ToSDLRect(uv), Rectangle.ToSDLRect(position));
            }
        }
        
        public static void DrawGeometry(float[] positions, Color[] colors, int[] indices)
        {
            SDL.RenderGeometryRaw(Handle, null, positions, colors, null, indices);
        }

        public static void DrawGeometry(Texture texture, float[] positions, Color[] colors, float[] uvs, int[] indices)
        {
            var textureHandle = texture == null ? null : texture.Handle;
            {
                SDL.RenderGeometryRaw(Handle, textureHandle, positions, colors, uvs, indices);
            }
        }
        
        public static void DrawBegin(Color color)
        {
            var color32 = Color.ToSDLColor32(color);
            {
                SDL.SetRenderDrawColor(Handle, color32.r, color32.g, color32.b, color32.a);
                {
                    SDL.RenderClear(Handle);
                }
            }
        }

        public static void DrawEnd()
        {
            SDL.RenderPresent(Handle);
        }
    }
    
    // Graphics Text API
    public unsafe partial class Graphics
    {
        public static void DrawText(Font font, string text, int x, int y, float size, Color color)
        {
            var surface = SDL_ttf.RenderTextSolid(font.FontHandle, text, Color.ToSDLColor32(color));
            {
                if (surface != null)
                {
                    var texture = SDL.CreateTextureFromSurface(Handle, surface);

                    if (texture != null)
                    {
                        var width = SDL.GetTextureWidth(texture);
                        var height = SDL.GetTextureHeight(texture);
                        var scale = size / Font.DefaultFontSize;
                        
                        var position = new Rectangle
                        {
                            x = x,
                            y = y,
                            width  = (int)(width * scale),
                            height = (int)(height * scale)
                        };
                        
                        SDL.RenderTexture(Handle, texture, null, Rectangle.ToSDLRect(position));
                        SDL.DestroyTexture(texture);
                    }
                    
                    SDL.DestroySurface(surface);
                }
            }
        }
        
        public static void DrawDebugText(int x, int y, string text, Color color)
        {
            var color32 = Color.ToSDLColor32(color);
            {
                SDL.SetRenderDrawColor(Handle, color32.r, color32.g, color32.b, color32.a);
                {
                    SDL.RenderDebugText(Handle, x, y, text);
                }
            }
        }
        
        public static void DrawFps(int x, int y, Color color)
        {
            var color32 = Color.ToSDLColor32(color);
            {
                SDL.SetRenderDrawColor(Handle, color32.r, color32.g, color32.b, color32.a);
                {
                    SDL.RenderDebugText(Handle, x, y, Time.GetFps().ToString("N0"));
                }
            }
        }
    }
}