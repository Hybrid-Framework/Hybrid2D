using System;

namespace Hybrid
{
    // Graphics Device
    internal unsafe partial class GraphicsDevice : Module
    {
        internal SDL.Renderer* Renderer { get; private set; }
        internal SDL.Window* Window { get; private set; }
        
        
        internal GraphicsDevice(Config config)
        {
            // Create Window
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

            // Create Renderer
            {
                Renderer = SDL.CreateRenderer(Window, null);
                Fps = config.Fps;
                
                SDL.SetRenderVSync(Renderer, config.VSync ? 1 : 0);
            }
        }
        
        internal override void OnDispose()
        {
            Console.WriteLine("Graphics Device Disposed");

            if (Renderer != null)
            {
                SDL.DestroyRenderer(Renderer);
                Renderer = null;
            }

            if (Window != null)
            {
                SDL.DestroyWindow(Window);
                Window = null;
            }
        }
    }
    
    // Properties
    internal unsafe partial class GraphicsDevice
    {
        internal int Fps
        {
            get; set;
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

        internal int Width
        {
            set => SDL.SetWindowSize(Window, value, Height);
            get
            {
                SDL.GetWindowSize(Window, out int width, out int height);
                {
                    return width;
                }
            }
        }
        
        internal int Height
        {
            set => SDL.SetWindowSize(Window, Width, value);
            get
            {
                SDL.GetWindowSize(Window, out int width, out int height);
                {
                    return height;
                }
            }
        }

        internal Vector2 Size
        {
            set => SDL.SetWindowSize(Window, (int)value.X, (int)value.Y);
            get
            {
                SDL.GetWindowSize(Window, out int width, out int height);
                {
                    return new Vector2(width, height);
                }
            }
        }
        
        internal Vector2 MinSize
        {
            set => SDL.SetWindowMinimumSize(Window, (int)value.X, (int)value.Y);
            get
            {
                SDL.GetWindowMinimumSize(Window, out int width, out int height);
                {
                    return new Vector2(width, height);
                }
            }
        }
        
        internal Vector2 MaxSize
        {
            set => SDL.SetWindowMaximumSize(Window, (int)value.X, (int)value.Y);
            get
            {
                SDL.GetWindowMinimumSize(Window, out int width, out int height);
                {
                    return new Vector2(width, height);
                }
            }
        }
        
        internal Vector2 Position
        {
            set => SDL.SetWindowPosition(Window, (int)value.X, (int)value.Y);
            get
            {
                SDL.GetWindowPosition(Window, out int x, out int y);
                {
                    return new Vector2(x, y);
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
    }

    // Events
    internal unsafe partial class GraphicsDevice
    {
        internal override void OnEvent(SDL.Event e)
        {
            switch (e.type)
            {
                // Handle Orientation Event
                case SDL.EventType.Orientation:
                {
                    var id = SDL.GetWindowID(Window);
                    Hybrid.Window.OnOrientation?.Invoke((Orientation)SDL.GetCurrentDisplayOrientation(id));
                    break;
                }

                // Handle Resize Event
                case SDL.EventType.Resized:
                {
                    Hybrid.Window.OnResized?.Invoke(Size);
                    break;
                }

                // Handle Move Event
                case SDL.EventType.Moved:
                {
                    Hybrid.Window.OnMoved?.Invoke(Position);
                    break;
                }

                // Handle Maximize Event
                case SDL.EventType.Maximized:
                {
                    Hybrid.Window.OnMaximized?.Invoke();
                    break;
                }
                
                // Handle Minimize Event
                case SDL.EventType.Minimized:
                {
                    Hybrid.Window.OnMinimized?.Invoke();
                    break;
                }

                // Handle Focused Event
                case SDL.EventType.Focused:
                {
                    Hybrid.Window.OnFocus?.Invoke();
                    break;
                }
                
                // Handle Unfocused Event
                case SDL.EventType.Unfocused:
                {
                    Hybrid.Window.OnUnfocus?.Invoke();
                    break;
                }

                // Handle Enter Fullscreen
                case SDL.EventType.EnterFullscreen:
                {
                    Hybrid.Window.OnFullscreen?.Invoke(true);
                    break;
                }
                
                // Handle Exit Fullscreen
                case SDL.EventType.ExitFullscreen:
                {
                    Hybrid.Window.OnFullscreen?.Invoke(false);
                    break;
                }
            }
        }
    }
}