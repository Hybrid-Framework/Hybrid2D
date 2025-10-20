using System;

namespace Hybrid
{
    public unsafe static partial class Graphics
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
    }
}