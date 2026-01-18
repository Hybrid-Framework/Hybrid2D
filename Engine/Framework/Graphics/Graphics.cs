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
        // Draw single rectangle with color
        public static void DrawRect(Rectangle rectangle, Color color)
        {
            DrawRects([rectangle], [color]);
        }
        
        // Draw multiple rectangles with colors
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

        // Draw single line with color
        public static void DrawLine(Line line, Color color)
        {
            DrawLines([line], [color]);
        }
        
        // Draw multiple lines with colors
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
        
        // Draw single pixel with color
        public static void DrawPoint(Point point, Color color)
        {
            DrawPoints([point], [color]);
        }

        // Draw multiple pixels with colors
        public static void DrawPoints(Point[] points, Color[] colors)
        {
            if (points.Length != colors.Length)
                throw new ArgumentException("points and colors must have the same length.");

            int count = points.Length;
            int vertexCount = count * 4;
            float[] vertices = new float[vertexCount * 2];
            Color[] vertexColors = new Color[vertexCount];
            int[] indices = new int[count * 6];

            float half = 0.5f;

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

        // Draw single circle with color
        public static void DrawCircle(Circle circle, Color color)
        {
            DrawCircles([circle], [color]);
        }

        // Draw multiple circles with colors
        public static void DrawCircles(Circle[] circles, Color[] colors)
        {
            if (circles.Length != colors.Length)
                throw new ArgumentException("circles and colors must have the same length.");

            int segments = 32;
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
        
        // Draw single ellipse with color
        public static void DrawEllipse(Ellipse ellipse, Color color)
        {
            DrawEllipses([ellipse], [color]);
        }

        // Draw multiple ellipses with colors
        public static void DrawEllipses(Ellipse[] ellipses, Color[] colors)
        {
            if (ellipses.Length != colors.Length)
                throw new ArgumentException("ellipses and colors must have the same length.");

            int segments = 32;
            int count = ellipses.Length;
            int vertexCountPerEllipse = segments + 1;
            int indexCountPerEllipse = segments * 3;

            int totalVertices = count * vertexCountPerEllipse;
            int totalIndices  = count * indexCountPerEllipse;

            float[] positions = new float[totalVertices * 2];
            Color[] vertexColors = new Color[totalVertices];
            int[] indices = new int[totalIndices];

            for (int i = 0; i < count; i++)
            {
                Ellipse e = ellipses[i];
                Color color = colors[i];

                int vBase = i * vertexCountPerEllipse;
                int iBase = i * indexCountPerEllipse;

                positions[vBase * 2 + 0] = e.x;
                positions[vBase * 2 + 1] = e.y;
                vertexColors[vBase] = color;

                for (int j = 0; j < segments; j++)
                {
                    float angle = (float)(2 * Math.PI * j / segments);

                    float x = e.x + e.radiusX * (float)Math.Cos(angle);
                    float y = e.y + e.radiusY * (float)Math.Sin(angle);

                    int v = vBase + 1 + j;
                    positions[v * 2 + 0] = x;
                    positions[v * 2 + 1] = y;
                    vertexColors[v] = color;
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
        
        // Draw single triangle with color
        public static void DrawTriangle(Triangle triangle, Color color)
        {
            DrawTriangles([triangle], [color]);
        }

        // Draw multiple triangles with colors
        public static void DrawTriangles(Triangle[] triangles, Color[] colors)
        {
            if (triangles.Length != colors.Length)
                throw new ArgumentException("triangles and colors must have the same length.");

            int count = triangles.Length;

            int vertexCountPerTriangle = 3;
            int indexCountPerTriangle = 3;

            int totalVertices = count * vertexCountPerTriangle;
            int totalIndices  = count * indexCountPerTriangle;

            float[] positions = new float[totalVertices * 2];
            Color[] vertexColors = new Color[totalVertices];
            int[] indices = new int[totalIndices];

            for (int i = 0; i < count; i++)
            {
                Triangle t = triangles[i];
                Color color = colors[i];

                int vBase = i * vertexCountPerTriangle;
                int iBase = i * indexCountPerTriangle;

                positions[(vBase + 0) * 2 + 0] = t.point1.x;
                positions[(vBase + 0) * 2 + 1] = t.point1.y;
                positions[(vBase + 1) * 2 + 0] = t.point2.x;
                positions[(vBase + 1) * 2 + 1] = t.point2.y;
                positions[(vBase + 2) * 2 + 0] = t.point3.x;
                positions[(vBase + 2) * 2 + 1] = t.point3.y;
                
                vertexColors[vBase + 0] = color;
                vertexColors[vBase + 1] = color;
                vertexColors[vBase + 2] = color;
                
                indices[iBase + 0] = vBase + 0;
                indices[iBase + 1] = vBase + 1;
                indices[iBase + 2] = vBase + 2;
            }

            DrawGeometry(null, positions, vertexColors, null, indices);
        }
        
        // Draw custom geometry with texture
        public static void DrawGeometry(Texture texture, float[] positions, Color[] colors, float[] uvs, int[] indices)
        {
            SDL.RenderGeometryRaw(Handle, texture == null ? null : texture.Handle, positions, colors, uvs, indices);
        }
        
        // Draw custom geometry without texture
        public static void DrawGeometry(float[] positions, Color[] colors, int[] indices)
        {
            SDL.RenderGeometryRaw(Handle, null, positions, colors, null, indices);
        }
        
        // Draw section of texture at position
        public static void DrawTexture(Texture texture, Rectangle? uv, Rectangle? position)
        {
            SDL.RenderTexture(Handle, texture == null ? null : texture.Handle, Rectangle.ToSDLRect(uv), Rectangle.ToSDLRect(position));
        }
        
        // Draw full texture at position
        public static void DrawTexture(Texture texture, Rectangle? position)
        {
            SDL.RenderTexture(Handle, texture == null ? null : texture.Handle, null, Rectangle.ToSDLRect(position));
        }

        // Draw begin (draw after this call)
        public static void DrawBegin(Color color)
        {
            SDL.SetRenderDrawColor(Handle, Color.ToSDLColor32(color));
            {
                SDL.RenderClear(Handle);
            }
        }

        // Draw end (stop drawing after this call)
        public static void DrawEnd()
        {
            SDL.RenderPresent(Handle);
        }
    }
    
    // Graphics Text API
    public unsafe partial class Graphics
    {
        // Draw text with a font, position, size and color
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
        
        // Draw the frame rate
        public static void DrawFps(int x, int y, Color color)
        {
            SDL.SetRenderDrawColor(Handle, Color.ToSDLColor32(color));
            {
                SDL.RenderDebugText(Handle, x, y, Time.GetFps().ToString("N0"));
            }
        }
    }
}