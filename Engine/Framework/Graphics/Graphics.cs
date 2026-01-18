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
        public static void DrawGeometry(Texture texture, float[] positions, Color[] colors, float[] uvs, int[] indices)
        {
            SDL.RenderGeometryRaw(Handle, texture.Handle, positions, colors, uvs, indices);
        }
        
        public static void DrawGeometry(float[] positions, Color[] colors, int[] indices)
        {
            SDL.RenderGeometryRaw(Handle, null, positions, colors, null, indices);
        }
        
        public static void DrawTexture(Texture texture, Rect? uv, Rect? position)
        {
            SDL.RenderTexture(Handle, texture.Handle, Rect.ToSDLRect(uv), Rect.ToSDLRect(position));
        }
        
        public static void DrawTexture(Texture texture, Rect? position)
        {
            SDL.RenderTexture(Handle, texture.Handle, null, Rect.ToSDLRect(position));
        }

        public static void DrawBegin(Color color)
        {
            SDL.SetRenderDrawColor(Handle, Color.ToSDLColor32(color));
            {
                SDL.RenderClear(Handle);
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
        
        public static void DrawFps(int x, int y, Color color)
        {
            SDL.SetRenderDrawColor(Handle, Color.ToSDLColor32(color));
            {
                SDL.RenderDebugText(Handle, x, y, Time.GetFps().ToString("N0"));
            }
        }
    }
}