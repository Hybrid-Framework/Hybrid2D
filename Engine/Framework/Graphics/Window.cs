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
                case SDL.EventType.Resized:
                {
                    Platform.GetDisplay().Resize();
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
    
    // Window Properties
    public unsafe partial class Window
    {
        private static Vector2 RestoredSize
        {
            get; set;
        }
        
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
                var fullscreen = Platform.GetDisplay().GetFullscreen();
                var minimized = Platform.GetDisplay().GetMinimized();
                var maximized = Platform.GetDisplay().GetMaximized();
                
                SDL.SetWindowSize(Handle, (int)value.X, (int)value.Y);
                {
                    if (!fullscreen && !maximized && !minimized)
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
        public static void Hide()
        {
            SDL.HideWindow(Handle);
        }

        public static void Show()
        {
            SDL.ShowWindow(Handle);
        }

        public static void Raise()
        {
            SDL.RaiseWindow(Handle);
        }
        
        public static void Maximize()
        {
            Platform.GetDisplay().SetMaximized(true);
        }

        public static void Minimize()
        {
            Platform.GetDisplay().SetMinimized(true);
        }
        
        public static void Restore()
        {
            Fullscreen = false;
            Size = RestoredSize;
            
            SDL.RestoreWindow(Handle);
        }
    }
}