using System;

namespace Hybrid
{
    public unsafe static class Graphics
    {
        public static void Clear(Color color)
        {
            SDL.SetRenderDrawColor(Window.GetRenderer(), color.r, color.g, color.b, color.a);
            SDL.RenderClear(Window.GetRenderer());
        }

        public static void Present()
        {
            SDL.RenderPresent(Window.GetRenderer());
        }

        public static void DebugText(int x, int y, string text)
        {
            SDL.SetRenderDrawColor(Window.GetRenderer(), 0, 0, 0, 255);
            SDL.RenderDebugText(Window.GetRenderer(), x, y, text);
        }
    }
}