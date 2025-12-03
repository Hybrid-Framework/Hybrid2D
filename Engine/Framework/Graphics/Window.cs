using System;

namespace Hybrid
{
    // Internal
    public unsafe partial class Window : Module<Window>
    {
        private Window() { }
        
        // SDL Window Handle
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
            var web = Platform.GetSystem().GetUnderlyingPlatform() == UnderlyingPlatform.Web;
            
            // Window Flags
            SetFlags(SDL.WindowFlags.HighPixelDensity);
            if ((config.Fullscreen || mobile) && !web) SetFlags(SDL.WindowFlags.Fullscreen);
            if ((config.Resizable || mobile) && !web) SetFlags(SDL.WindowFlags.Resizable);
        
            // Window Creation
            Handle = SDL.CreateWindow(config.Title, config.Width, config.Height, Flags);
            Size = new Vector2(config.Width, config.Height);
        
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
                
                case SDL.EventType.EnterFullscreen:
                {
                    SetFlags(SDL.WindowFlags.Fullscreen);
                    break;
                }
                
                case SDL.EventType.ExitFullscreen:
                {
                    ClearFlags(SDL.WindowFlags.Fullscreen);
                    break;
                }
                
                case SDL.EventType.Maximized:
                {
                    ClearFlags(SDL.WindowFlags.Minimized);
                    SetFlags(SDL.WindowFlags.Maximized);
                    break;
                }
                
                case SDL.EventType.Minimized:
                {
                    ClearFlags(SDL.WindowFlags.Maximized);
                    SetFlags(SDL.WindowFlags.Minimized);
                    break;
                }

                case SDL.EventType.Restored:
                {
                    ClearFlags(SDL.WindowFlags.Minimized);
                    ClearFlags(SDL.WindowFlags.Maximized);
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
    
    // Window Flags
    public unsafe partial class Window
    {
        private static SDL.WindowFlags Flags
        {
            get; set;
        }

        internal static void SetFlags(SDL.WindowFlags flags)
        {
            Flags |= flags;
        }

        internal static void ClearFlags(SDL.WindowFlags flags)
        {
            Flags &= ~flags;
        }
        
        internal static bool HasFlags(SDL.WindowFlags flags)
        {
            return (Flags & flags) == flags;
        }

        internal static SDL.WindowFlags GetFlags()
        {
            return Flags;
        }
    }

    // Window Properties
    public unsafe partial class Window
    {
        private static Vector2 Restoration
        {
            get;
            set;
        }
        
        public static Orientation Orientation
        {
            get => Platform.GetDisplay().GetOrientation();
        }

        public static string Title
        {
            set => Platform.GetDisplay().SetTitle(value);
            get => Platform.GetDisplay().GetTitle();
        }
        
        public static bool Fullscreen
        {
            get => Platform.GetDisplay().GetFullscreen();
            set
            {
                if(value) SetFlags(SDL.WindowFlags.Fullscreen);
                if(!value) ClearFlags(SDL.WindowFlags.Fullscreen);
                
                Platform.GetDisplay().SetFullscreen(value);
            }
        }

        public static bool Resizable
        {
            get => Platform.GetDisplay().GetResizable();
            set
            {
                if (!Fullscreen)
                {
                    if(value) SetFlags(SDL.WindowFlags.Resizable);
                    if(!value) ClearFlags(SDL.WindowFlags.Resizable);
                
                    Platform.GetDisplay().SetResizable(value);
                }
            }
        }

        public static bool Maximized
        {
            get => Platform.GetDisplay().GetMaximized();
            set
            {
                if (!Fullscreen)
                {
                    if(value) SetFlags(SDL.WindowFlags.Maximized);
                    if(!value) ClearFlags(SDL.WindowFlags.Maximized);
                
                    Platform.GetDisplay().SetMaximized(value);
                }
            }
        }
        
        public static bool Minimized
        {
            get => Platform.GetDisplay().GetMinimized();
            set
            {
                if (!Fullscreen)
                {
                    if(value) SetFlags(SDL.WindowFlags.Minimized);
                    if(!value) ClearFlags(SDL.WindowFlags.Minimized);
                
                    Platform.GetDisplay().SetMinimized(value);
                }
            }
        }
        
        public static Vector2 AspectRatio
        {
            get
            {
                SDL.GetWindowAspectRatio(Handle, out float min, out float max);
                {
                    return new Vector2(min, max);
                }
            }
            set
            {
                SDL.SetWindowAspectRatio(Handle, value.X, value.Y);
            }
        }

        public static Vector2 Position
        {
            get
            {
                SDL.GetWindowPosition(Handle, out int x, out int y);
                {
                    return new Vector2(x, y);
                }
            }
            set
            {
                if (!Fullscreen)
                {
                    SDL.SetWindowPosition(Handle, (int)value.X, (int)value.Y);
                }
            }
        }

        public static Vector2 Size
        {
            get
            {
                SDL.GetWindowSize(Handle, out int w, out int h);
                {
                    return new Vector2(w, h);
                }
            }
            set
            {
                if (!Fullscreen && !Maximized && !Minimized)
                {
                    SDL.SetWindowSize(Handle, (int)value.X, (int)value.Y);
                    {
                        Restoration = value;
                    }
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
        public static void EnterFullscreen()
        {
            if (!Fullscreen)
            {
                Fullscreen = true;
            }
        }
        
        public static void ExitFullscreen()
        {
            if (Fullscreen)
            {
                Fullscreen = false;
            }
        }
        
        public static void Maximize()
        {
            if (!Fullscreen)
            {
                Maximized = true;
            }
        }
        
        public static void Minimize()
        {
            if (!Fullscreen)
            {
                Minimized = true;
            }
        }

        public static void Show()
        {
            if (!Fullscreen)
            {
                SDL.ShowWindow(Handle);
            }
        }

        public static void Hide()
        {
            if (!Fullscreen)
            {
                SDL.HideWindow(Handle);
            }
        }

        public static void Raise()
        {
            if (!Fullscreen)
            {
                SDL.RaiseWindow(Handle);
            }
        }
        
        public static void Restore()
        {
            if (!Fullscreen)
            {
                ClearFlags(SDL.WindowFlags.Minimized | SDL.WindowFlags.Maximized);
                SDL.SetWindowSize(Handle, (int)Restoration.X, (int)Restoration.Y);
                SDL.RestoreWindow(Handle);
            }
        }
    }
}