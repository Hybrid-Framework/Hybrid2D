using static Hybrid.SDL2.SDL;
using System;

namespace Hybrid
{
    public static class Window
    {
        private static IntPtr window;
        private static IntPtr renderer;
        
        public static void CreateWindow(string title, int width, int height)
        {
            window = SDL_CreateWindow(title, width, height, SDL_WindowFlags.SDL_WINDOW_NONE);
            
            if (GetWindow() == IntPtr.Zero)
            {
                throw new Exception(SDL_GetError());
            }

            renderer = SDL_CreateRenderer(GetWindow(), -1, SDL_RendererFlags.SDL_RENDERER_NONE);
            
            if (GetRenderer() == IntPtr.Zero)
            {
                throw new Exception(SDL_GetError());
            }
        }

        public static void CloseWindow()
        {
            SDL_DestroyRenderer(GetRenderer());
            SDL_DestroyWindow(GetWindow());
            SDL_Quit();
        }

        public static void Resizeable(bool resizeable)
        {
            SDL_SetWindowResizable(GetWindow(), SDL_bool.SDL_TRUE);
        }

        public static void Fullscreen(bool fullscreen)
        {
            SDL_SetWindowFullscreen(GetWindow(), (uint)SDL_WindowFlags.SDL_WINDOW_FULLSCREEN);
        }
        
        public static void Vsync(bool vsync)
        {
            SDL_RenderSetVSync(GetWindow(), vsync ? 1 : 0);
        }

        public static IntPtr GetWindow()
        {
            return window;
        }

        public static IntPtr GetRenderer()
        {
            return renderer;
        }
    }
}