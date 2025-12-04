using System;

namespace Hybrid
{
    // Internal
    public unsafe partial class Window : Module<Window>
    {
        private Window() { }
        
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
            Flags = new WindowFlags(SDL.WindowFlags.HighPixelDensity);
            if ((config.Fullscreen || mobile) && !web) Flags.SetFlags(SDL.WindowFlags.Fullscreen);
            if ((config.Resizable || mobile) && !web) Flags.SetFlags(SDL.WindowFlags.Resizable);
        
            // Window Creation
            Handle = SDL.CreateWindow(config.Title, config.Width, config.Height, Flags.GetFlags());
            Size = new Vector2(config.Width, config.Height);
        
            // Window Icon
            var icon = SDL_image.Load(config.Icon);
            SDL.SetWindowIcon(Handle, icon);
            SDL.DestroySurface(icon);

            RegisterEvents();
            
            base.OnInitialize();
        }

        // Events
        internal override void OnEvent(SDL.Event e)
        {
            Flags.OnEvent(e);
            Events(e);
            
            // Fullscreen
            if (e.type == SDL.EventType.KeyboardButtonDown)
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
                
                OnFullscreen?.Invoke();
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
                    
                    OnMaximized?.Invoke();
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
                    
                    OnMinimized?.Invoke();
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
                OnShow?.Invoke();
            }
        }

        public static void Hide()
        {
            if (!GetFullscreen())
            {
                SDL.HideWindow(Handle);
                OnHide?.Invoke();
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
                    OnRestore?.Invoke();
                }
            }
        }
    }
    
    // Events
    public unsafe partial class Window
    {
        public static Action OnOrientation = null;
        public static Action OnFullscreen = null;
        public static Action OnMaximized = null;
        public static Action OnMinimized = null;
        public static Action OnResized = null;
        public static Action OnUnfocus = null;
        public static Action OnFocus = null;
        public static Action OnHide = null;
        public static Action OnShow = null;
        public static Action OnMoved = null;
        public static Action OnRestore = null;


        internal void RegisterEvents()
        {
            OnOrientation += CallOnOrientation;
            OnFullscreen += CallOnFullscreen;
            OnMaximized += CallOnMaximized;
            OnMinimized += CallOnMinimized;
            OnResized += CallOnResized;
            OnUnfocus += CallOnUnfocus;
            OnFocus += CallOnFocus;
            OnHide += CallOnHide;
            OnShow += CallOnShow;
            OnMoved += CallOnMoved;
            OnRestore += CallOnRestore;
        }

        private void CallOnOrientation() => Console.WriteLine("OnOrientation");
        private void CallOnFullscreen() => Console.WriteLine("OnFullscreen");
        private void CallOnMaximized() => Console.WriteLine("OnMaximized");
        private void CallOnMinimized() => Console.WriteLine("OnMinimized");
        private void CallOnResized() => Console.WriteLine("OnResized");
        private void CallOnUnfocus() => Console.WriteLine("OnUnfocus");
        private void CallOnFocus() => Console.WriteLine("OnFocus");
        private void CallOnHide() => Console.WriteLine("OnHide");
        private void CallOnShow() => Console.WriteLine("OnShow");
        private void CallOnMoved() => Console.WriteLine("OnMoved");
        private void CallOnRestore() => Console.WriteLine("OnRestore");

        internal void Events(SDL.Event e)
        {
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
                    
                    OnResized?.Invoke();
                    break;
                }
                
                case SDL.EventType.Orientation:
                {
                    OnOrientation?.Invoke();
                    break;
                }
                
                case SDL.EventType.EnterFullscreen:
                {
                    OnFullscreen?.Invoke();
                    break;
                }
                
                case SDL.EventType.ExitFullscreen:
                {
                    OnFullscreen?.Invoke();
                    break;
                }

                case SDL.EventType.Maximized:
                {
                    OnMaximized?.Invoke();
                    break;
                }
                
                case SDL.EventType.Minimized:
                {
                    OnMinimized?.Invoke();
                    break;
                }
                
                case SDL.EventType.Moved:
                {
                    OnMoved?.Invoke();
                    break;
                }
                
                case SDL.EventType.Restored:
                {
                    OnRestore?.Invoke();
                    break;
                }
                
                case SDL.EventType.Hidden:
                {
                    OnHide?.Invoke();
                    break;
                }
                
                case SDL.EventType.Shown:
                {
                    OnShow?.Invoke();
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
        }
    }
}