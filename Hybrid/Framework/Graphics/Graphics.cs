using System;
using System.Numerics;

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

    // Geometry
    public unsafe partial class Graphics
    {
        // Draw rectangle with rect and color
        public static void DrawRectangle(Rect rect, Color color)
        {
            float x = rect.x;
            float y = rect.y;
            float w = rect.width;
            float h = rect.height;

            float[] positions = new float[]
            {
                x,     y,      // top-left
                x + w, y,      // top-right
                x + w, y + h,  // bottom-right
                x,     y + h   // bottom-left
            };

            Color[] colors = new Color[]
            {
                color,
                color,
                color,
                color
            };

            int[] indices = new int[]
            {
                0, 1, 2,
                2, 3, 0
            };

            DrawGeometry(positions, colors, indices);
        }
        
        // Draw circle with center, radius and color
        public static void DrawCircle(Point center, float radius, Color color)
        {
            int segments = 32;
            float[] positions = new float[(segments + 1) * 2];
            Color[] colors = new Color[segments + 1];
            int[] indices = new int[segments * 3];
            positions[0] = center.x;
            positions[1] = center.y;
            colors[0] = color;

            for (int i = 0; i < segments; i++)
            {
                float angle = (float)(i * 2.0 * Math.PI / segments);
                float x = center.x + radius * (float)Math.Cos(angle);
                float y = center.y + radius * (float)Math.Sin(angle);

                positions[(i + 1) * 2] = x;
                positions[(i + 1) * 2 + 1] = y;
                colors[i + 1] = color;

                indices[i * 3] = 0;
                indices[i * 3 + 1] = i + 1;
                indices[i * 3 + 2] = i + 2 <= segments ? i + 2 : 1;
            }

            DrawGeometry(positions, colors, indices);
        }
        
        // Draw ellipse with center, radius x, radius y and color
        public static void DrawEllipse(Point center, float radiusX, float radiusY, Color color)
        {
            int segments = 32;
            float[] positions = new float[(segments + 1) * 2];
            Color[] colors = new Color[segments + 1];
            int[] indices = new int[segments * 3];
            positions[0] = center.x;
            positions[1] = center.y;
            colors[0] = color;

            for (int i = 0; i < segments; i++)
            {
                float angle = (float)(i * 2.0 * Math.PI / segments);
                float x = center.x + radiusX * (float)Math.Cos(angle);
                float y = center.y + radiusY * (float)Math.Sin(angle);

                positions[(i + 1) * 2] = x;
                positions[(i + 1) * 2 + 1] = y;
                colors[i + 1] = color;

                indices[i * 3] = 0;
                indices[i * 3 + 1] = i + 1;
                indices[i * 3 + 2] = i + 2 <= segments ? i + 2 : 1;
            }

            DrawGeometry(positions, colors, indices);
        }
        
        // Draw triangle with a, b, c and color
        public static void DrawTriangle(Point a, Point b, Point c, Color color)
        {
            float[] positions = new float[]
            {
                a.x, a.y,
                b.x, b.y,
                c.x, c.y
            };

            Color[] colors = new Color[]
            {
                color,
                color,
                color
            };
            
            int[] indices = new int[] { 0, 1, 2 };

            DrawGeometry(positions, colors, indices);
        }
        
        // Draw poly with center, radius, color and sides
        public static void DrawPoly(Point center, float radius, Color color, int sides)
        {
            if (sides < 3)
            {
                sides = 3;
            }
            
            float[] positions = new float[(sides + 1) * 2];
            Color[] colors = new Color[sides + 1];
            int[] indices = new int[sides * 3];
            positions[0] = center.x;
            positions[1] = center.y;
            colors[0] = color;

            for (int i = 0; i < sides; i++)
            {
                float angle = (float)(i * 2.0 * Math.PI / sides);
                float x = center.x + radius * (float)Math.Cos(angle);
                float y = center.y + radius * (float)Math.Sin(angle);

                positions[(i + 1) * 2] = x;
                positions[(i + 1) * 2 + 1] = y;
                colors[i + 1] = color;

                indices[i * 3] = 0;
                indices[i * 3 + 1] = i + 1;
                indices[i * 3 + 2] = i + 2 <= sides ? i + 2 : 1;
            }

            DrawGeometry(positions, colors, indices);
        }
        
        // Draw line with a, b, thickness and color
        public static void DrawLine(Point a, Point b, float thickness, Color color)
        {
            Vector2 start = new Vector2(a.x, a.y);
            Vector2 end = new Vector2(b.x, b.y);
            Vector2 dir = end - start;
            Vector2 normal = Vector2.Normalize(new Vector2(-dir.Y, dir.X));
            Vector2 offset = normal * (thickness / 2);
            Vector2 v0 = start + offset;
            Vector2 v1 = end + offset;
            Vector2 v2 = end - offset;
            Vector2 v3 = start - offset;

            float[] positions = new float[]
            {
                v0.X, v0.Y,
                v1.X, v1.Y,
                v2.X, v2.Y,
                v3.X, v3.Y
            };

            Color[] colors = new Color[]
            {
                color,
                color,
                color,
                color
            };

            int[] indices = new int[]
            {
                0, 1, 2,
                2, 3, 0
            };

            DrawGeometry(positions, colors, indices);
        }
        
        // Draw pixel with point and color
        public static void DrawPixel(Point point, Color color)
        {
            float[] positions = new float[]
            {
                point.x,     point.y,     // top-left
                point.x + 1, point.y,     // top-right
                point.x + 1, point.y + 1, // bottom-right
                point.x,     point.y + 1  // bottom-left
            };

            Color[] colors = new Color[]
            {
                color,
                color,
                color,
                color
            };

            int[] indices = new int[]
            {
                0, 1, 2,
                2, 3, 0
            };

            DrawGeometry(positions, colors, indices);
        }

        // Draw geometry with texture
        public static void DrawGeometry(Texture texture, float[] positions, Color[] colors, float[] uvs, int[] indices)
        {
            SDL.RenderGeometryRaw(Handle, texture == null ? null : texture.Handle, positions, colors, uvs, indices);
        }
        
        // Draw geometry without texture
        public static void DrawGeometry(float[] positions, Color[] colors, int[] indices)
        {
            SDL.RenderGeometryRaw(Handle, null, positions, colors, null, indices);
        }
    }

    // Texture
    public unsafe partial class Graphics
    {
        // Draw section of texture at position
        public static void DrawTexture(Texture texture, Rect? uv, Rect? position)
        {
            SDL.RenderTexture(Handle, texture == null ? null : texture.Handle, Rect.ToSDLRect(uv), Rect.ToSDLRect(position));
        }
        
        // Draw full texture at position
        public static void DrawTexture(Texture texture, Rect? position)
        {
            SDL.RenderTexture(Handle, texture == null ? null : texture.Handle, null, Rect.ToSDLRect(position));
        }
    }
    
    // Text
    public unsafe partial class Graphics
    {
        // Draw text with a font, position, size and color
        public static void DrawText(Font font, string text, int x, int y, float size, Color color)
        {
            var surface = SDL_ttf.RenderTextSolid(font.Handle, text, Color.ToSDLColor32(color));
            {
                if (surface != null)
                {
                    var texture = SDL.CreateTextureFromSurface(Handle, surface);

                    if (texture != null)
                    {
                        var width = SDL.GetTextureWidth(texture);
                        var height = SDL.GetTextureHeight(texture);
                        var scale = size / Font.DefaultSize;
                        
                        var position = new Rect
                        {
                            x = x,
                            y = y,
                            width  = (int)(width * scale),
                            height = (int)(height * scale)
                        };
                        
                        SDL.RenderTexture(Handle, texture, null, Rect.ToSDLRect(position));
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
    
    // General
    public unsafe partial class Graphics
    {
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
}