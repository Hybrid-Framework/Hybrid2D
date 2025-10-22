using System;

namespace Hybrid
{
    public static unsafe class Graphics
    {
        private static void SetRenderColor(Color color)
        {
            SDL.SetRenderDrawColor(Window.GetRenderer(), color.r, color.g, color.b, color.a);
        }
        
        public static void Clear(Color color)
        {
            SetRenderColor(color);
            SDL.RenderClear(Window.GetRenderer());
        }

        public static void Present()
        {
            SDL.RenderPresent(Window.GetRenderer());
        }

        public static void DebugText(int x, int y, string text, Color color)
        {
            SetRenderColor(color);
            SDL.RenderDebugText(Window.GetRenderer(), x, y, text);
        }
    }
}