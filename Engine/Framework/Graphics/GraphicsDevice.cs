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
            
            Events.OnEvent += OnEvent;
        }
        
        internal override void Dispose()
        {
            Console.WriteLine("Graphics Device Disposed");
            
            SDL.DestroyRenderer(Renderer);
            SDL.DestroyWindow(Window);
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
        internal Action OnOrientation = null;
        internal Action OnMaximized = null;
        internal Action OnMinimized = null;
        internal Action OnResized = null;
        internal Action OnUnfocus = null;
        internal Action OnOpened = null;
        internal Action OnClosed = null;
        internal Action OnFocus = null;
        internal Action OnMoved = null;
        
        
        internal void OnEvent(SDL.Event e)
        {
            SDL.EventType type = (SDL.EventType)e.type;
            
            if (type == SDL.EventType.OrientationChanged) OnOrientation?.Invoke();
            if (type == SDL.EventType.Unfocused) OnUnfocus?.Invoke();
            if (type == SDL.EventType.Resized) OnResized?.Invoke();
            if (type == SDL.EventType.Focused) OnFocus?.Invoke();
            if (type == SDL.EventType.Moved) OnMoved?.Invoke();
        }
    }
}