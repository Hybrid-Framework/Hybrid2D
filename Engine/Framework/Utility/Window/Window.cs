using System;

namespace Hybrid
{
    #region Window
    public static unsafe partial class Window
    {
        private static SDL.Window* WindowHandle;
        internal static SDL.Window* GetWindow()
        {
            return WindowHandle;
        }
        
        
        private static SDL.Renderer* RenderHandle;
        internal static SDL.Renderer* GetRenderer()
        {
            return RenderHandle;
        }
        
        public static void Create(string title = "", int width = 800, int height = 600, bool fullscreen = false, bool resizable = false)
        {
            if (WindowHandle == null)
            {
                SDL.WindowFlags flags = SDL.WindowFlags.HighPixelDensity;
                if (fullscreen) flags |= SDL.WindowFlags.Fullscreen;
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
    #endregion
    

    #region Properties
    public static unsafe partial class Window
    {
        // Set Window Properties, Size, Position, Title, etc
    }
    #endregion
}