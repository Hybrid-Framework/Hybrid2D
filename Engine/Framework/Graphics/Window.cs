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
        
        
        internal Window()
        {
            SDL.WindowFlags flags = SDL.WindowFlags.HighPixelDensity;
            
            // Calculate Flags
            var device = Platform.GetDevice();
            if (device == Device.Mobile) Engine.Config.Fullscreen = true;
            if (device == Device.Mobile) Engine.Config.Resizable = true;
            if (Engine.Config.Fullscreen) flags |= SDL.WindowFlags.Fullscreen;
            if (Engine.Config.Resizable) flags |= SDL.WindowFlags.Resizable;
            
            // Create Window Handle
            Handle = SDL.CreateWindow(Engine.Config.Title, Engine.Config.Width, Engine.Config.Height, flags);
            VSync = Engine.Config.VSync;
            Fps = Engine.Config.Fps;
            
            // Window Icon
            if (Engine.Config.Icon != null)
            {
                SDL.Surface* icon = SDL_image.Load(Engine.Config.Icon);
                    
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
    
    // Window API
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
        
        public static Orientation NaturalOrientation
        {
            get => Platform.GetNaturalOrientation();
        }

        public static Orientation Orientation
        {
            get => Platform.GetOrientation();
        }
    }

    // Events
    public unsafe partial class Window
    {
        public static Action<Orientation> OnOrientation = null;
        public static Action<bool> OnFullscreen = null;
        public static Action<Vector2> OnResized = null;
        public static Action<Vector2> OnMoved = null;
        public static Action OnMaximized = null;
        public static Action OnMinimized = null;
        public static Action OnUnfocus = null;
        public static Action OnFocus = null;
        
        
        internal override void OnEvent(SDL.Event e)
        {
            switch (e.type)
            {
                case SDL.EventType.Orientation:
                    OnOrientation?.Invoke(Orientation);
                    break;
                
                case SDL.EventType.EnterFullscreen:
                    OnFullscreen?.Invoke(true);
                    break;
                
                case SDL.EventType.ExitFullscreen:
                    OnFullscreen?.Invoke(false);
                    break;
                
                case SDL.EventType.Resized:
                    OnResized?.Invoke(Size);
                    break;
                
                case SDL.EventType.Moved:
                    OnMoved?.Invoke(Position);
                    break;
                
                case SDL.EventType.Focused:
                    OnFocus?.Invoke();
                    break;
                
                case SDL.EventType.Unfocused:
                    OnUnfocus?.Invoke();
                    break;
                
                case SDL.EventType.Minimized:
                    OnMinimized?.Invoke();
                    break;
                
                case SDL.EventType.Maximized:
                    OnMaximized?.Invoke();
                    break;
            }
        }
    }
}