using System;

namespace Hybrid
{
    // Internal
    public sealed unsafe partial class Graphics : Module
    {
        internal static SDL.Renderer* Handle { get; private set; }
        
        internal Graphics()
        {
            Handle = SDL.CreateRenderer(Window.Handle, null);
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

    public unsafe partial class Graphics
    {
        public static void DrawColor(Color32 color)
        {
            SDL.SetRenderDrawColor(Handle, color.R, color.G, color.B, color.A);
        }
        
        public static void DrawFPS(int x, int y)
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