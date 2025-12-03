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
            
            // Settings
            Application.TargetFrameRate = Platform.GetConfig().TargetFrameRate;
            Application.VSync = Platform.GetConfig().VSync;
            
            // Window Flags
            SDL.WindowFlags flags = SDL.WindowFlags.HighPixelDensity;
            if (config.Fullscreen || mobile) flags |= SDL.WindowFlags.Fullscreen;
            if (config.Resizable || mobile) flags |= SDL.WindowFlags.Resizable;
        
            // Window Creation
            Handle = SDL.CreateWindow(config.Title, config.Width, config.Height, flags);
            RestoredSize = new Vector2(config.Width, config.Height);
        
            // Window Icon
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
                {
                    Platform.GetDisplay().GetOrientation();
                    OnOrientation?.Invoke();
                    break;
                }

                case SDL.EventType.Resized:
                {
                    Platform.GetDisplay().Resize();
                    OnResized?.Invoke();
                    break;
                }

                case SDL.EventType.Restored:
                {
                    OnRestored?.Invoke();
                    break;
                }

                case SDL.EventType.Minimized:
                {
                    OnMinimized?.Invoke();
                    break;
                }

                case SDL.EventType.Maximized:
                {
                    OnMaximized?.Invoke();
                    break;
                }

                case SDL.EventType.Moved:
                {
                    OnMoved?.Invoke();
                    break;
                }

                case SDL.EventType.Focused:
                {
                    OnFocus?.Invoke();
                    break;
                }

                case SDL.EventType.Unfocused:
                {
                    OnUnfocus?.Invoke();
                    break;
                }
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
        private static Vector2 RestoredSize { get; set; }
        
        public static Action OnOrientation = null;
        public static Action OnRestored = null;
        public static Action OnResized = null;
        public static Action OnMaximized = null;
        public static Action OnMinimized = null;
        public static Action OnUnfocus = null;
        public static Action OnFocus = null;
        public static Action OnMoved = null;
        
        
        public static Orientation Orientation
        {
            get => Platform.GetDisplay().GetOrientation();
        }

        public static string Title
        {
            set => Platform.GetDisplay().SetTitle(value);
            get
            {
                return Platform.GetDisplay().GetTitle();
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
            set => Platform.GetDisplay().SetResizable(value);
            get
            {
                return Platform.GetDisplay().GetResizable();
            }
        }

        public static bool Maximized
        {
            set => Platform.GetDisplay().SetMaximized(value);
            get
            {
                return Platform.GetDisplay().GetMaximized();
            }
        }
        
        public static bool Minimized
        {
            set => Platform.GetDisplay().SetMinimized(value);
            get
            {
                return Platform.GetDisplay().GetMinimized();
            }
        }
        
        public static Vector2 AspectRatio
        {
            set => SDL.SetWindowAspectRatio(Handle, value.X, value.Y);
            get
            {
                SDL.GetWindowAspectRatio(Handle, out float min, out float max);
                {
                    return new Vector2(min, max);
                }
            }
        }

        public static Vector2 Position
        {
            set => SDL.SetWindowPosition(Handle, (int)value.X, (int)value.Y);
            get
            {
                SDL.GetWindowPosition(Handle, out var x, out var y);
                {
                    return new Vector2(x, y);
                }
            }
        }

        public static Vector2 Size
        {
            set
            {
                SDL.SetWindowSize(Handle, (int)value.X, (int)value.Y);
                {
                    if (!Fullscreen && !Maximized && !Minimized)
                    {
                        RestoredSize = value;
                    }
                }
            }
            get
            {
                SDL.GetWindowSize(Handle, out int w, out int h);
                {
                    return new Vector2(w, h);
                }
            }
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
    }
    
    // Window Methods
    public unsafe partial class Window
    {
        public static void Maximize()
        {
            Maximized = true;
        }

        public static void Minimize()
        {
            Minimized = true;
        }
        
        public static void Restore()
        {
            Fullscreen = false;
            Size = RestoredSize;
            
            SDL.RestoreWindow(Handle);
        }
    }
}