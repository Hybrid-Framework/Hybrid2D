using System;

namespace Hybrid
{
    // Internal
    public unsafe partial class Window : Module<Window>
    {
        private Window() { }
        
        internal static SDL.Window* Handle
        {
            private set;
            get;
        }
        

        // Initialize
        internal override void OnInitialize()
        {
            // Platform
            var config = Platform.GetConfig();
            var mobile = Platform.GetSystem().GetUnderlyingDevice() == UnderlyingDevice.Mobile;
            
            // Calculate Flags
            SDL.WindowFlags flags = SDL.WindowFlags.HighPixelDensity;
            if (config.Fullscreen || mobile) flags |= SDL.WindowFlags.Fullscreen;
            if (config.Resizable || mobile) flags |= SDL.WindowFlags.Resizable;
        
            // Create Window
            Handle = SDL.CreateWindow(config.Title, config.Width, config.Height, flags);
            RestoreSize = new Vector2(config.Width, config.Height);
            Fps = config.Fps;
        
            // Icon
            var icon = SDL_image.Load(config.Icon);
            SDL.SetWindowIcon(Handle, icon);
            SDL.DestroySurface(icon);
            
            base.OnInitialize();
        }

        // Events
        internal override void OnEvent(SDL.Event e)
        {
            switch (e.type)
            {
                case SDL.EventType.Orientation:
                    Platform.GetDisplay().GetOrientation();
                    OnOrientation?.Invoke();
                    break;
                
                case SDL.EventType.Resized:
                    Platform.GetDisplay().Resize();
                    OnResized?.Invoke();
                    break;
                
                case SDL.EventType.Restored:
                    OnRestored?.Invoke();
                    break;
                
                case SDL.EventType.Moved:
                    OnMoved?.Invoke();
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
            
            base.OnEvent(e);
        }
        
        // Dispose
        internal override void OnDispose()
        {
            if (Handle != null)
            {
                SDL.DestroyWindow(Handle);
                Handle = null;
            }
            
            base.OnDispose();
        }
    }
    
    // Window API
    public unsafe partial class Window
    {
        public static Action OnOrientation = null;
        public static Action OnRestored = null;
        public static Action OnResized = null;
        public static Action OnMaximized = null;
        public static Action OnMinimized = null;
        public static Action OnUnfocus = null;
        public static Action OnFocus = null;
        public static Action OnMoved = null;


        public static int Fps
        {
            set; get;
        }

        public static Vector2 RestoreSize
        {
            get; set;
        }

        public static int Width
        {
            set => Size = new Vector2(value, Size.Y);
            get => (int)Size.X;
        }

        public static int Height
        {
            set => Size = new Vector2(Size.X, value);
            get => (int)Size.Y;
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
            set => Platform.GetDisplay().SetFullscreen(value);
            get
            {
                return Platform.GetDisplay().GetFullscreen();
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
            set
            {
                if (!Fullscreen)
                {
                    RestoreSize = value;
                }

                SDL.SetWindowSize(Handle, (int)value.X, (int)value.Y);
            }
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

        public static Orientation Orientation
        {
            get => Platform.GetDisplay().GetOrientation();
        }
    }
    
    // Window Methods
    public unsafe partial class Window
    {
        public static void Restore()
        {
            Fullscreen = false;
            Size = RestoreSize;
            
            SDL.RestoreWindow(Handle);
            OnRestored?.Invoke();
        }

        public static void Minimize()
        {
            SDL.MinimizeWindow(Handle);
            OnMinimized?.Invoke();
        }

        public static void Maximize()
        {
            SDL.MaximizeWindow(Handle);
            OnMaximized?.Invoke();
        }
    }
}