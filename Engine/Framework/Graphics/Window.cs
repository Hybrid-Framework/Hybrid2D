using System;

namespace Hybrid
{
    public static unsafe partial class Window
    {
        private static SDL.Window* WindowHandle;
        private static SDL.Renderer* RenderHandle;
        
        
        public static void Create(string title = "Hybrid", int width = 800, int height = 600, bool fullscreen = false, bool resizable = false)
        {
            // Window
            if (WindowHandle == null)
            {
                // Create Window
                SDL.WindowFlags flags = SDL.WindowFlags.HighPixelDensity;
                if (fullscreen || Platform.Current.SystemDevice == SystemDevice.Mobile) flags |= SDL.WindowFlags.Fullscreen;
                if (resizable || Platform.Current.SystemDevice == SystemDevice.Mobile) flags |= SDL.WindowFlags.Resizable;
                WindowHandle = SDL.CreateWindow(title, width, height, flags);
                
                // Create Icon
                var icon = SDL_image.Load("Hybrid.png");
                SDL.SetWindowIcon(WindowHandle, icon);
            }
            
            // Renderer
            if (RenderHandle == null)
            {
                // Create Renderer
                RenderHandle = SDL.CreateRenderer(GetWindow(), null);
            }
        }

        internal static void Dispose()
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