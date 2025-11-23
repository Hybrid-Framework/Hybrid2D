using System;

namespace Hybrid
{
    // Window
    public unsafe partial class Window : Module
    {
        // SDL Window Handle
        internal static SDL.Window* Handle
        {
            private set;
            get;
        }
        
        internal Window(Config config)
        {
            SDL.WindowFlags flags = SDL.WindowFlags.HighPixelDensity;
            
            // Calculate Flags
            if (Platform.Device == Device.Mobile) config.Fullscreen = true;
            if (Platform.Device == Device.Mobile) config.Resizable = true;
            if (config.Fullscreen) flags |= SDL.WindowFlags.Fullscreen;
            if (config.Resizable) flags |= SDL.WindowFlags.Resizable;
            
            // Create Window Handle
            Handle = SDL.CreateWindow(config.Title, config.Width, config.Height, flags);
            VSync = config.VSync;
            Fps = config.Fps;
            
            // Window Icon
            if (config.Icon != null)
            {
                SDL.Surface* icon = SDL_image.Load(config.Icon);
                    
                if (icon != null)
                {
                    SDL.SetWindowIcon(Handle, icon);
                }
            }
        }
        
        internal override void OnDestroy()
        {
            Console.WriteLine("Window Disposed");
            
            if (Handle != null)
            {
                SDL.DestroyWindow(Handle);
            }
        }
    }
    
    // Properties
    public unsafe partial class Window
    {
        public static int Fps
        {
            set;
            get;
        }

        public static string Title
        {
            set => SDL.SetWindowTitle(Handle, value);
            get
            {
                return SDL.GetWindowTitle(Handle);
            }
        }

        public static bool Fullscreen
        {
            set => SDL.SetWindowFullscreen(Handle, value);
            get
            {
                var flags = SDL.GetWindowFlags(Handle);
                {
                    return (flags & SDL.WindowFlags.Fullscreen) != 0;
                }
            }
        }

        public static bool Resizable
        {
            set => SDL.SetWindowResizable(Handle, value);
            get
            {
                var flags = SDL.GetWindowFlags(Handle);
                {
                    return (flags & SDL.WindowFlags.Resizable) != 0;
                }
            }
        }

        public static Vector2 Size
        {
            set => SDL.SetWindowSize(Handle, (int)value.X, (int)value.Y);
            get
            {
                SDL.GetWindowSize(Handle, out int w, out int h);
                {
                    return new Vector2(w, h);
                }
            }
        }
        
        public static Vector2 MinSize
        {
            set => SDL.SetWindowMinimumSize(Handle, (int)value.X, (int)value.Y);
            get
            {
                SDL.GetWindowMinimumSize(Handle, out int w, out int h);
                {
                    return new Vector2(w, h);
                }
            }
        }
        
        public static Vector2 MaxSize
        {
            set => SDL.SetWindowMaximumSize(Handle, (int)value.X, (int)value.Y);
            get
            {
                SDL.GetWindowMaximumSize(Handle, out int w, out int h);
                {
                    return new Vector2(w, h);
                }
            }
        }
        
        public static Vector2 Position
        {
            set => SDL.SetWindowPosition(Handle, (int)value.X, (int)value.Y);
            get
            {
                SDL.GetWindowPosition(Handle, out int w, out int h);
                {
                    return new Vector2(w, h);
                }
            }
        }
        
        public static int Width
        {
            set => SDL.SetWindowSize(Handle, value, Height);
            get
            {
                SDL.GetWindowSize(Handle, out int w, out int h);
                {
                    return w;
                }
            }
        }
        
        public static int Height
        {
            set => SDL.SetWindowSize(Handle, Width, value);
            get
            {
                SDL.GetWindowSize(Handle, out int w, out int h);
                {
                    return h;
                }
            }
        }

        public static bool VSync
        {
            set => SDL.SetRenderVSync(Graphics.Handle, value ? 1 : 0);
            get
            {
                SDL.GetRenderVSync(Graphics.Handle, out int vsync);
                {
                    return vsync > 0;
                }
            }
        }
    }

    // Events
    public unsafe partial class Window
    {
        internal override void OnEvent(SDL.Event e)
        {
            // Quit Application
            if (e.type == SDL.EventType.Quit)
            {
                Platform.Quit();
                return;
            }
        }
    }
}