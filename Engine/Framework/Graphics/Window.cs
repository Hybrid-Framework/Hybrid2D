using System;

namespace Hybrid
{
    public static unsafe partial class Window
    {
        private static SDL.Window* WindowHandle;
        private static SDL.Renderer* RenderHandle;
        internal static SDL.Window* GetWindow() => WindowHandle;
        internal static SDL.Renderer* GetRenderer() => RenderHandle;
        
        
        public static void Create(string title = "Hybrid", int width = 800, int height = 600, int fps = 60, bool fullscreen = false, bool resizable = false, bool vsync = true)
        {
            // Fps
            Vsync = vsync;
            TargetFPS = fps;
            
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

    public static partial class Window
    {
        private static int TargetFPS;
        
        public static void SetTargetFPS(int value)
        {
            if (value <= 0) value = 0;
            TargetFPS = value;
        }

        public static int GetTargetFPS()
        {
            return TargetFPS;
        }

        private static bool Vsync = false;

        public static void SetVsync(bool state)
        {
            Vsync = state;
        }

        public static bool GetVsync()
        {
            return Vsync;
        }
    }
}