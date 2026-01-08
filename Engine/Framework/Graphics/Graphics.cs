using System;

namespace Hybrid
{
    // Internal
    public sealed unsafe partial class Graphics : Module
    {
        internal static SDL.Renderer* Handle
        {
            private set;
            get;
        }
        
        internal Graphics(bool vsync)
        {
            Handle = SDL.CreateRenderer(Window.Handle, null);
            {
                SDL.SetRenderVSync(Handle, vsync ? 1 : 0);
            }
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