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
            get;
            set;
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

    // Window Size
    public unsafe partial class Window
    {
        private static Vector2 Size
        {
            get; set;
        }

        public static Vector2 RestoreSize
        {
            get => Size;
        }
    }
    
    // Window Title
    public unsafe partial class Window
    {
        public static void SetTitle(string title)
        {
            Platform.GetDisplay().SetTitle(title);
        }

        public static string GetTitle()
        {
            return Platform.GetDisplay().GetTitle();
        }
    }
    
    // Window Fullscreen
    public unsafe partial class Window
    {
        public static void SetFullscreen(bool fullscreen)
        {
            if(fullscreen) SetFlags(SDL.WindowFlags.Fullscreen);
            if(!fullscreen) ClearFlags(SDL.WindowFlags.Fullscreen);
            
            Platform.GetDisplay().SetFullscreen(fullscreen);
        }

        public static bool GetFullscreen()
        {
            return Platform.GetDisplay().GetFullscreen();
        }
    }
    
    // Window Resizable
    public unsafe partial class Window
    {
        public static void SetResizable(bool resizable)
        {
            if (GetFullscreen()) return;
            
            if(resizable) SetFlags(SDL.WindowFlags.Resizable);
            if(!resizable) ClearFlags(SDL.WindowFlags.Resizable);

            Platform.GetDisplay().SetResizable(resizable);
        }

        public static bool GetResizable()
        {
            return Platform.GetDisplay().GetResizable();
        }
    }
    
    
    // Window Maximize
    public unsafe partial class Window
    {
        public static void SetMaximized(bool maximize)
        {
            if (GetFullscreen()) return;
            
            if(maximize) SetFlags(SDL.WindowFlags.Maximized);
            if(!maximize) ClearFlags(SDL.WindowFlags.Maximized);

            Platform.GetDisplay().SetMaximized(maximize);
        }

        public static bool GetMaximized()
        {
            return Platform.GetDisplay().GetMaximized();
        }
    }
    
    // Window Minimize
    public unsafe partial class Window
    {
        public static void SetMinimized(bool minimized)
        {
            if (GetFullscreen()) return;
            
            if(minimized) SetFlags(SDL.WindowFlags.Minimized);
            if(!minimized) ClearFlags(SDL.WindowFlags.Minimized);

            Platform.GetDisplay().SetMinimized(minimized);
        }

        public static bool GetMinimized()
        {
            return Platform.GetDisplay().GetMinimized();
        }
    }
    
    // Window Position
    public unsafe partial class Window
    {
        public static void SetPosition(int x, int y)
        {
            SetPosition(new Vector2(x, y));
        }

        public static void SetPosition(Vector2 position)
        {
            if (GetFullscreen()) return;

            SDL.SetWindowPosition(Handle, (int)position.X, (int)position.Y);
        }

        public static Vector2 GetPosition()
        {
            SDL.GetWindowPosition(Handle, out int x, out int y);
            {
                return new Vector2(x, y);
            }
        }
    }
    
    // Window Size
    public unsafe partial class Window
    {
        public static void SetSize(int w, int h)
        {
            SetSize(new Vector2(w, h));
        }

        public static void SetSize(Vector2 size)
        {
            if (GetFullscreen()) return;
            if (GetMaximized()) return;
            if (GetMinimized()) return;

            SDL.SetWindowSize(Handle, (int)size.X, (int)size.Y);
            {
                Size = size;
            }
        }

        public static Vector2 GetSize()
        {
            SDL.GetWindowSize(Handle, out int w, out int h);
            {
                return new Vector2(w, h);
            }
        }
    }
    
    // Window Visibility
    public unsafe partial class Window
    {
        public static void Hide()
        {
            if (GetFullscreen()) return;

            SDL.HideWindow(Handle);
        }

        public static void Show()
        {
            if (GetFullscreen()) return;

            SDL.ShowWindow(Handle);
        }
    }
    
    // Window Restore
    public unsafe partial class Window
    {
        public static void Raise()
        {
            if (GetFullscreen()) return;

            SDL.RaiseWindow(Handle);
        }

        public static void Restore()
        {
            if(GetFullscreen()) return;
            
            ClearFlags(SDL.WindowFlags.Minimized | SDL.WindowFlags.Maximized);
            SDL.RestoreWindow(Handle);
            SetSize(Size);
        }
    }
    
    // Window Orientation
    public unsafe partial class Window
    {
        public static Orientation GetOrientation()
        {
            return Platform.GetDisplay().GetOrientation();
        }
    }
}