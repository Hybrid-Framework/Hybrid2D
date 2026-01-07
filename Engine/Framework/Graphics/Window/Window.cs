using System;

namespace Hybrid
{
    // Internal
    public sealed unsafe partial class Window : Module<Window>
    {
        private Window() { }
        
        internal static WindowEvents Events { get; private set; }
        internal static WindowFlags Flags { get; private set; }
        
        public static Action OnOrientation = null;
        public static Action OnFullscreen = null;
        public static Action OnMaximized = null;
        public static Action OnMouseEnter = null;
        public static Action OnMouseExit = null;
        public static Action OnMinimized = null;
        public static Action OnSafeArea = null;
        public static Action OnResized = null;
        public static Action OnUnfocus = null;
        public static Action OnFocus = null;
        public static Action OnHide = null;
        public static Action OnShow = null;
        public static Action OnMoved = null;
        public static Action OnBorder = null;
        public static Action OnRestore = null;
        public static Action OnRaise = null;
        
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
            
            // Window Objects
            Flags = new WindowFlags();
            Events = new WindowEvents();
            
            // Window Flags
            Flags.SetFlags(SDL.WindowFlags.HighPixelDensity);
            if ((config.Fullscreen || mobile) && !web) Flags.SetFlags(SDL.WindowFlags.Fullscreen);
            if (config.Resizable || mobile) Flags.SetFlags(SDL.WindowFlags.Resizable);
            
            // Window Creation
            Handle = SDL.CreateWindow(config.Title, config.Width, config.Height, Flags.GetFlags());
            Size = new Vector2(config.Width, config.Height);
        
            // Icon
            if (!web)
            {
                // Set Window Icon (Web handled)
                var icon = SDL_image.Load(config.Icon);
                SDL.SetWindowIcon(Handle, icon);
                SDL.DestroySurface(icon);
            }
        }

        // Events
        internal override void OnEvent(SDL.Event e)
        {
            Events.OnEvent(e);
            Flags.OnEvent(e);

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
            }
        }
        
        // Dispose
        internal override void OnDispose()
        {
            if (Handle != null)
            {
                SDL.DestroyWindow(Handle);
                Handle = null;
            }
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
                // BUG IN SDL (due to be fixed in SDL 3.6) (still fires event)
                // Events.Push(fullscreen ? SDL.EventType.FullscreenOn : SDL.EventType.FullscreenOff);
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
                    Events.Push(resizable ? SDL.EventType.ResizableOn : SDL.EventType.ResizableOff);
                }
            }
        }

        public static bool GetResizable()
        {
            return Platform.GetDisplay().GetResizable();
        }
    }

    // Borderless
    public unsafe partial class Window
    {
        public static void SetBorderless(bool borderless)
        {
            if (!GetFullscreen())
            {
                if (Platform.GetDisplay().SetBorderless(borderless))
                {
                    Events.Push(borderless ? SDL.EventType.BorderlessOn : SDL.EventType.BorderlessOff);
                }
            }
        }
        
        public static bool GetBorderless()
        {
            return Platform.GetDisplay().GetBorderless();
        }
    }

    // Maximize
    public unsafe partial class Window
    {
        public static void SetMaximized(bool maximized)
        {
            if (!GetFullscreen() && GetResizable())
            {
                if (Platform.GetDisplay().SetMaximized(maximized))
                {
                    if (maximized)
                    {
                        Events.Push(SDL.EventType.Maximized);
                    }
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
                    if (minimized)
                    {
                        Events.Push(SDL.EventType.Minimized);
                    }
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
        public static void SetPosition(Vector2 position)
        {
            if (!GetFullscreen() && !GetMaximized() && !GetMinimized())
            {
                if (SDL.SetWindowPosition(Handle, (int)position.X, (int)position.Y))
                {
                    Events.Push(SDL.EventType.Moved);
                }
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
                SetSize(new Vector2(width, (int)GetSize().Y));
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
                SetSize(new Vector2((int)GetSize().X, height));
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
                if (SDL.ShowWindow(Handle))
                {
                    Events.Push(SDL.EventType.Show);
                }
            }
        }

        public static void Hide()
        {
            if (!GetFullscreen())
            {
                if (SDL.HideWindow(Handle))
                {
                    Events.Push(SDL.EventType.Hide);
                }
            }
        }
    }
    
    // Presentation
    public unsafe partial class Window
    {
        public static void SetPresentationMode(Presentation mode)
        {
            SDL.GetRenderLogicalPresentation(Graphics.Handle, out var w, out var h, out var presentation);
            {
                SDL.SetRenderLogicalPresentation(Graphics.Handle, w, h, (SDL.Presentation)mode);
            }
        }

        public static Presentation GetPresentationMode()
        {
            SDL.GetRenderLogicalPresentation(Graphics.Handle, out var w, out var h, out var presentation);
            {
                return (Presentation)presentation;
            }
        }

        public static void SetPresentationSize(Vector2 size)
        {
            SDL.GetRenderLogicalPresentation(Graphics.Handle, out var w, out var h, out var presentation);
            {
                SDL.SetRenderLogicalPresentation(Graphics.Handle, (int)size.X, (int)size.Y, presentation);
            }
        }

        public static Vector2 GetPresentationSize()
        {
            SDL.GetRenderLogicalPresentation(Graphics.Handle, out var w, out var h, out var _);
            {
                return new Vector2(w, h);
            }
        }
    }
    
    // Orientation
    public unsafe partial class Window
    {
        public static void SetOrientation(Orientation orientation)
        {
            // Potentially implement at some point?
        }

        public static Orientation GetOrientation()
        {
            return Platform.GetDisplay().GetOrientation();
        }
    }
    
    // Functional
    public unsafe partial class Window
    {
        public static void Raise()
        {
            if (!GetFullscreen())
            {
                if (SDL.RaiseWindow(Handle))
                {
                    Events.Push(SDL.EventType.Raised);
                }
            }
        }
        
        public static void Restore()
        {
            if (!GetFullscreen())
            {
                if (GetMaximized() || GetMaximized())
                {
                    Events.Push(SDL.EventType.Restored);
                    SDL.RestoreWindow(Handle);
                }
                
                SetSize(new Vector2((int)Size.X, (int)Size.Y));
            }
        }
    }
}