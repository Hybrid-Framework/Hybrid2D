using System;

namespace Hybrid
{
    public static unsafe partial class Window
    {
        private static SDL.Window* WindowHandle;
        private static SDL.Renderer* RenderHandle;
        internal static SDL.Window* GetWindow() => WindowHandle;
        internal static SDL.Renderer* GetRenderer() => RenderHandle;
        
        
        public static void Create(string title = "Hybrid", int width = 800, int height = 600, bool fullscreen = false, bool resizable = false, bool vsync = true)
        {
            if (WindowHandle == null)
            {
                SDL.WindowFlags flags = SDL.WindowFlags.HighPixelDensity;
                
                if (Platform.Current.PlatformDevice == PlatformDevice.Mobile) fullscreen = true;
                if (Platform.Current.PlatformDevice == PlatformDevice.Mobile) resizable = true;
                if (fullscreen) flags |= SDL.WindowFlags.Fullscreen;
                if (resizable) flags |= SDL.WindowFlags.Resizable;
                
                WindowHandle = SDL.CreateWindow(title, width, height, flags);
                SDL.SetWindowIcon(GetWindow(), SDL_image.Load("Hybrid.png"));
            }
            
            if (RenderHandle == null)
            {
                RenderHandle = SDL.CreateRenderer(GetWindow(), null);
                SDL.SetRenderVSync(GetRenderer(), (vsync ? 1 : 0));
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
        private static int targetFPS;
        public static int TargetFPS
        {
            get => targetFPS;
            set
            {
                if (value < 0) value = 0;
                targetFPS = value;
            }
        }

        public static bool VSync
        {
            get
            {
                SDL.GetRenderVSync(GetRenderer(), out int vsync);
                {
                    return vsync > 0;
                }
            }
            set
            {
                SDL.SetRenderVSync(GetRenderer(), value ? 1 : 0);
            }
        }
    }
}