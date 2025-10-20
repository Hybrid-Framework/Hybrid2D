using System;

namespace Hybrid
{
    public static unsafe partial class Window
    {
        private static SDL.Window* WindowHandle;
        private static SDL.Renderer* RenderHandle;
        
        
        public static void Create(string title = "", int width = 600, int height = 600, bool fullscreen = false, bool resizable = false, bool borderless = false)
        {
            if (WindowHandle == null)
            {
                SDL.WindowFlags flags = SDL.WindowFlags.HighPixelDensity;
                if (fullscreen) flags |= SDL.WindowFlags.Fullscreen;
                if (borderless) flags |= SDL.WindowFlags.Borderless;
                if (resizable) flags |= SDL.WindowFlags.Resizable;
                
                WindowHandle = SDL.CreateWindow(title, width, height, flags);
            }

            if (RenderHandle == null)
            {
                RenderHandle = SDL.CreateRenderer(GetWindow(), null);
            }
        }

        public static void Dispose()
        {
            SDL.DestroyRenderer(GetRenderer());
            SDL.DestroyWindow(GetWindow());
        }
    }

    public static unsafe partial class Window
    {
        internal static SDL.Window* GetWindow()
        {
            return WindowHandle;
        }
        
        internal static SDL.Renderer* GetRenderer()
        {
            return RenderHandle;
        }
    }
}