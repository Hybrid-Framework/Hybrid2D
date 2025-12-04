using System;

namespace Hybrid
{
    // Internal
    public unsafe partial class Window : Module<Window>
    {
        private Window() { }
        
        internal static WindowEvents Events { get; set; }
        internal static WindowFlags Flags { get; set; }
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
            Flags = new WindowFlags();
            Flags.SetFlags(SDL.WindowFlags.HighPixelDensity);
            if ((config.Fullscreen || mobile) && !web) Flags.SetFlags(SDL.WindowFlags.Fullscreen);
            if ((config.Resizable || mobile) && !web) Flags.SetFlags(SDL.WindowFlags.Resizable);
            
            // Window Events
            Events = new WindowEvents();
            Events.RegisterEvents();
        
            // Window Creation
            Handle = SDL.CreateWindow(config.Title, config.Width, config.Height, Flags.GetFlags());
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
            Flags.OnEvent(e);
            Events.OnEvent(e);

            switch (e.type)
            {
                case SDL.EventType.Resized:
                {
                    if (Platform.GetDisplay().Resize())
                    {
                        if (!GetFullscreen() && !GetMaximized() && !GetMinimized())
                        {
                            SDL.GetWindowSize(Handle, out var w, out var h);
                            {
                                Size = new Vector2(w, h);
                            }
                        }
                    }
                    
                    break;
                }
                
                case SDL.EventType.KeyboardButtonDown:
                {
                    if (e.keyboard.keyCode == SDL.KeyCode.F)
                    {
                        SetFullscreen(!GetFullscreen());
                    }
                
                    if (e.keyboard.keyCode == SDL.KeyCode.Num1)
                    {
                        SetSize(400, 400);
                    }
                
                    if (e.keyboard.keyCode == SDL.KeyCode.Num2)
                    {
                        SetSize(800, 600);
                    }
                
                    if (e.keyboard.keyCode == SDL.KeyCode.M)
                    {
                        SetMaximized(!GetMaximized());
                    }
                
                    if (e.keyboard.keyCode == SDL.KeyCode.N)
                    {
                        SetMinimized(!GetMinimized());
                    }
                
                    if (e.keyboard.keyCode == SDL.KeyCode.R)
                    {
                        Restore();
                    }
                    
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

    // Title
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

    // Fullscreen
    public unsafe partial class Window
    {
        public static void SetFullscreen(bool fullscreen)
        {
            if (Platform.GetDisplay().SetFullscreen(fullscreen))
            {
                if(fullscreen) Flags.SetFlags(SDL.WindowFlags.Fullscreen);
                if(!fullscreen) Flags.ClearFlags(SDL.WindowFlags.Fullscreen);
            }
        }

        public static bool GetFullscreen()
        {
            return Platform.GetDisplay().GetFullscreen();
        }
    }

    // Resizable
    public unsafe partial class Window
    {
        public static void SetResizable(bool resizable)
        {
            if (!GetFullscreen())
            {
                if (Platform.GetDisplay().SetResizable(resizable))
                {
                    if (resizable) Flags.SetFlags(SDL.WindowFlags.Resizable);
                    if (!resizable) Flags.ClearFlags(SDL.WindowFlags.Resizable);
                }
            }
        }

        public static bool GetResizable()
        {
            return Platform.GetDisplay().GetResizable();
        }
    }

    // Maximize
    public unsafe partial class Window
    {
        public static void SetMaximized(bool maximized)
        {
            if (!GetFullscreen())
            {
                if (Platform.GetDisplay().SetMaximized(maximized))
                {
                    if (maximized) Flags.SetFlags(SDL.WindowFlags.Maximized);
                    if (!maximized) Flags.ClearFlags(SDL.WindowFlags.Maximized);
                }
            }
        }

        public static bool GetMaximized()
        {
            return Platform.GetDisplay().GetMaximized();
        }
    }

    // Minimize
    public unsafe partial class Window
    {
        public static void SetMinimized(bool minimized)
        {
            if (!GetFullscreen())
            {
                if (Platform.GetDisplay().SetMinimized(minimized))
                {
                    if(minimized) Flags.SetFlags(SDL.WindowFlags.Minimized);
                    if(!minimized) Flags.ClearFlags(SDL.WindowFlags.Minimized);
                }
            }
        }

        public static bool GetMinimized()
        {
            return Platform.GetDisplay().GetMinimized();
        }
    }
    
    // Position
    public unsafe partial class Window
    {
        public static void SetPosition(int x, int y)
        {
            SetPosition(new Vector2(x, y));
        }

        public static void SetPosition(Vector2 position)
        {
            if (!GetFullscreen() && !GetMaximized() && !GetMinimized())
            {
                SDL.SetWindowPosition(Handle, (int)position.X, (int)position.Y);
            }
        }

        public static Vector2 GetPosition()
        {
            SDL.GetWindowPosition(Handle, out var x, out var y);
            {
                return new Vector2(x, y);
            }
        }
    }
    
    // Size
    public unsafe partial class Window
    {
        private static Vector2 Size
        {
            get; set;
        }

        public static void SetSize(int width, int height)
        {
            SetSize(new Vector2(width, height));
        }

        public static void SetSize(Vector2 size)
        {
            if (!GetFullscreen() && !GetMaximized() && !GetMinimized())
            {
                SDL.SetWindowSize(Handle, (int)size.X, (int)size.Y);
                {
                    Size = size;
                }
            }
        }

        public static Vector2 GetSize()
        {
            SDL.GetWindowSize(Handle, out var w, out var h);
            {
                return new Vector2(w, h);
            }
        }
    }

    // Width
    public unsafe partial class Window
    {
        public static void SetWidth(int width)
        {
            if (!GetFullscreen())
            {
                SetSize(width, (int)GetSize().Y);
            }
        }

        public static int GetWidth()
        {
            return (int)GetSize().X;
        }
    }
    
    // Height
    public unsafe partial class Window
    {
        public static void SetHeight(int height)
        {
            if (!GetFullscreen())
            {
                SetSize((int)GetSize().X, height);
            }
        }

        public static int GetHeight()
        {
            return (int)GetSize().Y;
        }
    }

    // Visibility
    public unsafe partial class Window
    {
        public static void Show()
        {
            if (!GetFullscreen())
            {
                SDL.ShowWindow(Handle);
            }
        }

        public static void Hide()
        {
            if (!GetFullscreen())
            {
                SDL.HideWindow(Handle);
            }
        }
    }
    
    // Functional
    public unsafe partial class Window
    {
        public static Orientation GetOrientation()
        {
            return Platform.GetDisplay().GetOrientation();
        }
        
        public static void Raise()
        {
            if (!GetFullscreen())
            {
                SDL.RaiseWindow(Handle);
            }
        }
        
        public static void Restore()
        {
            if (!GetFullscreen())
            {
                if ((int)GetSize().X != (int)Size.X && (int)GetSize().Y != (int)Size.Y)
                {
                    Flags.ClearFlags(SDL.WindowFlags.Minimized | SDL.WindowFlags.Maximized);
                    SetSize((int)Size.X, (int)Size.Y);
                    SDL.RestoreWindow(Handle);
                }
            }
        }
    }
}