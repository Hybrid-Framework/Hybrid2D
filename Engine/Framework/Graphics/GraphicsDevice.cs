using System;

namespace Hybrid
{
    // Graphics Device
    internal unsafe partial class GraphicsDevice
    {
        internal SDL.Window* Window { get; }
        internal SDL.Renderer* Renderer { get; }
        

        internal GraphicsDevice(Config config)
        {
            // Create Window
            {
                // Calculate Window Flags
                SDL.WindowFlags flags = SDL.WindowFlags.HighPixelDensity;
                if (Platform.Current.PlatformDevice == PlatformDevice.Mobile) config.Fullscreen = true;
                if (Platform.Current.PlatformDevice == PlatformDevice.Mobile) config.Resizable = true;
                if (config.Fullscreen) flags |= SDL.WindowFlags.Fullscreen;
                if (config.Resizable) flags |= SDL.WindowFlags.Resizable;
                
                // Create Window
                Window = SDL.CreateWindow(config.Title, config.Width, config.Height, flags);

                // Set Icon
                if (config.Icon != null)
                {
                    SDL.Surface* icon = SDL_image.Load(config.Icon);
                    
                    if (icon != null)
                    {
                        SDL.SetWindowIcon(Window, icon);
                    }
                }
            }
                
            // Create Renderer
            {
                // Create Renderer
                Renderer = SDL.CreateRenderer(Window, null);
                
                // Assign Values
                MinSize = new Vector2(300, 300);
                VSync = config.VSync;
                Fps = config.Fps;
            }
        }
    }

    internal unsafe partial class GraphicsDevice
    {
        internal int Fps
        {
            set;
            get;
        }

        internal string Title
        {
            set => SDL.SetWindowTitle(Window, value);
            get => SDL.GetWindowTitle(Window);
        }

        internal bool Fullscreen
        {
            set => SDL.SetWindowFullscreen(Window, value);
            get => (SDL.GetWindowFlags(Window) & SDL.WindowFlags.Fullscreen) != 0;
        }

        internal bool Resizable
        {
            set => SDL.SetWindowResizable(Window, value);
            get => (SDL.GetWindowFlags(Window) & SDL.WindowFlags.Resizable) != 0;
        }

        internal Vector2 Size
        {
            set => SDL.SetWindowSize(Window, (int)value.X, (int)value.Y);
            get
            {
                SDL.GetWindowSize(Window, out int w, out int h);
                {
                    return new Vector2(w, h);
                }
            }
        }
        
        internal Vector2 MinSize
        {
            set => SDL.SetWindowMinimumSize(Window, (int)value.X, (int)value.Y);
            get
            {
                SDL.GetWindowMinimumSize(Window, out int w, out int h);
                {
                    return new Vector2(w, h);
                }
            }
        }
        
        internal Vector2 MaxSize
        {
            set => SDL.SetWindowMaximumSize(Window, (int)value.X, (int)value.Y);
            get
            {
                SDL.GetWindowMaximumSize(Window, out int w, out int h);
                {
                    return new Vector2(w, h);
                }
            }
        }
        
        internal Vector2 Position
        {
            set => SDL.SetWindowPosition(Window, (int)value.X, (int)value.Y);
            get
            {
                SDL.GetWindowPosition(Window, out int w, out int h);
                {
                    return new Vector2(w, h);
                }
            }
        }
        
        internal int Width
        {
            set => SDL.SetWindowSize(Window, value, Height);
            get
            {
                SDL.GetWindowSize(Window, out int w, out int h);
                {
                    return w;
                }
            }
        }
        
        internal int Height
        {
            set => SDL.SetWindowSize(Window, Width, value);
            get
            {
                SDL.GetWindowSize(Window, out int w, out int h);
                {
                    return h;
                }
            }
        }

        internal bool VSync
        {
            set => SDL.SetRenderVSync(Renderer, value ? 1 : 0);
            get
            {
                SDL.GetRenderVSync(Renderer, out int vsync);
                {
                    return vsync > 0;
                }
            }
        }

        internal string GraphicsDriver
        {
            get => SDL.GetRendererName(Renderer);
        }
    }
}