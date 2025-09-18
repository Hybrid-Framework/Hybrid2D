using static Hybrid.SDL2.SDL;

namespace Hybrid
{
    public static class Graphics
    {
        public static void ClearColor(byte r, byte g, byte b, byte a)
        {
            SDL_SetRenderDrawColor(Window.GetRenderer(), r, g, b, a);
        }

        public static void Begin()
        {
            SDL_RenderClear(Window.GetRenderer());
        }

        public static void End()
        {
            SDL_RenderPresent(Window.GetRenderer());
        }
    }
}