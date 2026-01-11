using System;
using System.Collections.Generic;

namespace Hybrid
{
    // Internal
    public sealed unsafe partial class Window : Module
    {
        internal Window() { }
        
        internal static SDL.Window* Handle
        {
            get; set;
        }

        // Initialize
        internal override void OnInitialize()
        {
            Handle = SDL.CreateWindow("Hybrid2D", 600, 400, SDL.WindowFlags.Hidden | SDL.WindowFlags.HighPixelDensity);
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
        public static void SetPosition(Point position)
        {
            SDL.SetWindowPosition(Handle, (int)position.x, (int)position.y);
        }

        public static Point GetWindowPosition()
        {
            SDL.GetWindowPosition(Handle, out int x, out int y);
            {
                return new Point(x, y);
            }
        }
    }
    
    // Size
    public unsafe partial class Window
    {
        public static void SetSize(Point size)
        {
            SDL.SetWindowSize(Handle, (int)size.x, (int)size.y);
        }

        public static Point GetSize()
        {
            SDL.GetWindowSize(Handle, out int w, out int h);
            {
                return new Point(w, h);
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
        public static void SetMaximumSize(Point size)
        {
            SDL.SetWindowMaximumSize(Handle, (int)size.x, (int)size.y);
        }

        public static Point GetMaximumSize()
        {
            SDL.GetWindowMaximumSize(Handle, out int w, out int h);
            {
                return new Point(w, h);
            }
        }
    }

    // Minimum Size
    public unsafe partial class Window
    {
        public static void SetMinimumSize(Point size)
        {
            SDL.SetWindowMinimumSize(Handle, (int)size.x, (int)size.y);
        }

        public static Point GetMinimumSize()
        {
            SDL.GetWindowMinimumSize(Handle, out int w, out int h);
            {
                return new Point(w, h);
            }
        }
    }
    
    // Aspect Ratio
    public unsafe partial class Window
    {
        public static void SetAspectRatio(Point aspect)
        {
            SDL.SetWindowAspectRatio(Handle, aspect.x, aspect.y);
        }

        public static Point GetAspectRatio()
        {
            SDL.GetWindowAspectRatio(Handle, out float w, out float h);
            {
                return new Point(w, h);
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
    
    // Monitor
    public unsafe partial class Window
    {
        public static uint[] GetMonitors()
        {
            return SDL.GetDisplays(out var count);
        }

        public static uint GetCurrentMonitor()
        {
            return SDL.GetDisplayForWindow(Handle);
        }

        public static string GetCurrentMonitorName()
        {
            return GetMonitorName(GetCurrentMonitor());
        }
        
        public static Point GetCurrentMonitorSize()
        {
            return GetMonitorSize(GetCurrentMonitor());
        }
        
        public static string GetMonitorName(uint displayID)
        {
            return SDL.GetDisplayName(displayID);
        }
        
        public static Point GetMonitorSize(uint displayID)
        {
            SDL.GetDisplayBounds(displayID, out SDL.RectInt rect);
            {
                return new Point(rect.w, rect.h);
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