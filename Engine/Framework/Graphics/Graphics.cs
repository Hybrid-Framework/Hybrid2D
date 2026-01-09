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
        
        public static void DrawColor(Color32 color)
        {
            SDL.SetRenderDrawColor(Handle, color.R, color.G, color.B, color.A);
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