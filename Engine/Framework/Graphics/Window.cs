using System;

namespace Hybrid
{
    public static unsafe partial class Window
    {
        private static SDL.Window* WindowHandle;
        private static SDL.Renderer* RenderHandle;
        
        
        public static void Create(string title = "Hybrid", int width = 800, int height = 600, bool fullscreen = false, bool resizable = false, bool vsync = true)
        {
            // Window
            if (WindowHandle == null)
            {
                SDL.WindowFlags flags = SDL.WindowFlags.HighPixelDensity;

                if (Platform.Current.SystemDevice == SystemDevice.Mobile) fullscreen = true;
                if (Platform.Current.SystemDevice == SystemDevice.Mobile) resizable = true;
                if (fullscreen) flags |= SDL.WindowFlags.Fullscreen;
                if (resizable) flags |= SDL.WindowFlags.Resizable;
                
                WindowHandle = SDL.CreateWindow(title, width, height, flags);
            }
            
            // Renderer
            if (RenderHandle == null)
            {
                RenderHandle = SDL.CreateRenderer(GetWindow(), null);
            }
            
            SDL.SetRenderVSync(RenderHandle, (vsync ? 1 : 0));
            SDL.SetWindowIcon(WindowHandle, SDL_image.Load("Hybrid.png"));
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