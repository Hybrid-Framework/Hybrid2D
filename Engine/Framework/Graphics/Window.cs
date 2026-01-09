using System;

namespace Hybrid
{
    // Internal
    public sealed unsafe partial class Window : Module
    {
        internal static SDL.Window* Handle
        {
            get; private set;
        }
        
        internal Window(string title, int width, int height)
        {
            Handle = SDL.CreateWindow(title, width, height, SDL.WindowFlags.HighPixelDensity);
        }
        
        internal override void OnDispose()
        {
            if (Handle != null)
            {
                SDL.DestroyWindow(Handle);
                Handle = null;
            }
        }
    }
    
    // Icon
    public unsafe partial class Window
    {
        public static void SetIcon(string path)
        {
            var icon = SDL_image.Load(SDL.GetBasePath() + path);
            {
                if (icon != null)
                {
                    SDL.SetWindowIcon(Handle, icon);
                    SDL.DestroySurface(icon);
                }
            }
        }
    }
    
    // Title
    public unsafe partial class Window
    {
        public static void SetTitle(string title)
        {
            SDL.SetWindowTitle(Handle, title);
        }

        public static string GeTitle()
        {
            return SDL.GetWindowTitle(Handle);
        }
    }

    // Fullscreen
    public unsafe partial class Window
    {
        public static void SetFullscreen(bool fullscreen)
        {
            SDL.SetWindowFullscreen(Handle, fullscreen);
        }

        public static bool GetFullscreen()
        {
            return (SDL.GetWindowFlags(Handle) & SDL.WindowFlags.Fullscreen) != 0;
        }
    }

    // Resizable
    public unsafe partial class Window
    {
        public static void SetResizable(bool resizable)
        {
            SDL.SetWindowResizable(Handle, resizable);
        }

        public static bool GetResizable()
        {
            return (SDL.GetWindowFlags(Handle) & SDL.WindowFlags.Resizable) != 0;
        }
    }
    
    // Borderless
    public unsafe partial class Window
    {
        public static void SetBorderless(bool borderless)
        {
            SDL.SetWindowBordered(Handle, !borderless);
        }

        public static bool GetBorderless()
        {
            return (SDL.GetWindowFlags(Handle) & SDL.WindowFlags.Borderless) != 0;
        }
    }

    // Maximized
    public unsafe partial class Window
    {
        public static void SetMaximized(bool maximized)
        {
            if (maximized)
            {
                SDL.MaximizeWindow(Handle);
                return;
            }

            SDL.RestoreWindow(Handle);
        }

        public static bool GetMaximized()
        {
            return (SDL.GetWindowFlags(Handle) & SDL.WindowFlags.Maximized) != 0;
        }
    }

    // Minimized
    public unsafe partial class Window
    {
        public static void SetMinimized(bool minimized)
        {
            if (minimized)
            {
                SDL.MinimizeWindow(Handle);
                return;
            }

            SDL.RestoreWindow(Handle);
        }

        public static bool GetMinimized()
        {
            return (SDL.GetWindowFlags(Handle) & SDL.WindowFlags.Minimized) != 0;
        }
    }
    
    // Position
    public unsafe partial class Window
    {
        public static void SetPosition(Vector2 position)
        {
            SDL.SetWindowPosition(Handle, (int)position.X, (int)position.Y);
        }

        public static Vector2 GetWindowPosition()
        {
            SDL.GetWindowPosition(Handle, out int x, out int y);
            {
                return new Vector2(x, y);
            }
        }
    }
    
    // Size
    public unsafe partial class Window
    {
        public static void SetSize(Vector2 size)
        {
            SDL.SetWindowSize(Handle, (int)size.X, (int)size.Y);
        }

        public static Vector2 GetSize()
        {
            SDL.GetWindowSize(Handle, out int w, out int h);
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
            SDL.SetWindowSize(Handle, width, GetHeight());
        }

        public static int GetWidth()
        {
            SDL.GetWindowSize(Handle, out int w, out int h);
            {
                return w;
            }
        }
    }
    
    // Height
    public unsafe partial class Window
    {
        public static void SetHeight(int height)
        {
            SDL.SetWindowSize(Handle, GetWidth(), height);
        }

        public static int GetHeight()
        {
            SDL.GetWindowSize(Handle, out int w, out int h);
            {
                return h;
            }
        }
    }

    // Maximum Size
    public unsafe partial class Window
    {
        public static void SetMaximumSize(Vector2 size)
        {
            SDL.SetWindowMaximumSize(Handle, (int)size.X, (int)size.Y);
        }

        public static Vector2 GetMaximumSize()
        {
            SDL.GetWindowMaximumSize(Handle, out int w, out int h);
            {
                return new Vector2(w, h);
            }
        }
    }

    // Minimum Size
    public unsafe partial class Window
    {
        public static void SetMinimumSize(Vector2 size)
        {
            SDL.SetWindowMinimumSize(Handle, (int)size.X, (int)size.Y);
        }

        public static Vector2 GetMinimumSize()
        {
            SDL.GetWindowMinimumSize(Handle, out int w, out int h);
            {
                return new Vector2(w, h);
            }
        }
    }
    
    // Aspect Ratio
    public unsafe partial class Window
    {
        public static void SetAspectRatio(Vector2 aspect)
        {
            SDL.SetWindowAspectRatio(Handle, aspect.X, aspect.Y);
        }

        public static Vector2 GetAspectRatio()
        {
            SDL.GetWindowAspectRatio(Handle, out float w, out float h);
            {
                return new Vector2(w, h);
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
            SDL.GetRenderLogicalPresentation(Graphics.Handle, out var w, out var h, out var presentation);
            {
                return new Vector2(w, h);
            }
        }
    }
    
    // VSync
    public unsafe partial class Window
    {
        public static void SetVSync(bool vsync)
        {
            SDL.SetRenderVSync(Graphics.Handle, vsync ? 1 : 0);
        }

        public static bool GetVSync()
        {
            SDL.GetRenderVSync(Graphics.Handle, out int vsync);
            {
                return vsync > 0 ? true : false;
            }
        }
    }

    // Functions
    public unsafe partial class Window
    {
        public static void Show()
        {
            SDL.ShowWindow(Handle);
        }

        public static void Hide()
        {
            SDL.HideWindow(Handle);
        }

        public static void Raise()
        {
            SDL.RaiseWindow(Handle);
        }

        public static void Restore()
        {
            SDL.RestoreWindow(Handle);
        }

        public static void Maximize()
        {
            SDL.MaximizeWindow(Handle);
        }

        public static void Minimize()
        {
            SDL.MinimizeWindow(Handle);
        }
    }
}