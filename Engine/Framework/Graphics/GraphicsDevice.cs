using System;

namespace Hybrid
{
    // Graphics Device (Device)
    public static unsafe partial class GraphicsDevice
    {
        internal static SDL.Renderer* Renderer { get; private set; }
        internal static SDL.Window* Window { get; private set; }
        
        
        internal static void Create(Config config)
        {
            if (Window == null)
            {
                SDL.WindowFlags flags = SDL.WindowFlags.HighPixelDensity;
            
                if (Platform.Current.PlatformDevice == PlatformDevice.Mobile) config.Fullscreen = true;
                if (Platform.Current.PlatformDevice == PlatformDevice.Mobile) config.Resizable = true;
                if (config.Fullscreen) flags |= SDL.WindowFlags.Fullscreen;
                if (config.Resizable) flags |= SDL.WindowFlags.Resizable;

                Window = SDL.CreateWindow(config.Title, config.Width, config.Height, flags);

                SDL.Surface* icon = SDL_image.Load(config.Icon);
                if (icon != null) SDL.SetWindowIcon(Window, icon);
            }

            if (Renderer == null)
            {
                Renderer = SDL.CreateRenderer(Window, null);
                Fps = config.Fps;
                
                SDL.SetRenderVSync(Renderer, config.VSync ? 1 : 0);
            }
            
            Events.OnEvent += OnEvent;
        }

        internal static void Dispose()
        {
            SDL.DestroyRenderer(Renderer);
            SDL.DestroyWindow(Window);
        }
    }
}