using System.Collections.Generic;
using System;

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
            Handle = SDL.CreateWindow("", 600, 400, SDL.WindowFlags.Hidden | SDL.WindowFlags.HighPixelDensity);
        }
        
        // Dispose
        internal override void Destroy()
        {
            if (Handle != null)
            {
                SDL.DestroyWindow(Handle);
                Handle = null;
            }
        }
    }
    
    // Window API
    public unsafe partial class Window
    {
        // Set window icon
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
        
        // Set window title
        public static void SetTitle(string title)
        {
            SDL.SetWindowTitle(Handle, title);
        }

        // Get window fullscreen
        public static string GetTitle()
        {
            return SDL.GetWindowTitle(Handle);
        }
        
        // Set window fullscreen
        public static void SetFullscreen(bool fullscreen)
        {
            SDL.SetWindowFullscreen(Handle, fullscreen);
        }

        // Get window fullscreen
        public static bool GetFullscreen()
        {
            return (SDL.GetWindowFlags(Handle) & SDL.WindowFlags.Fullscreen) != 0;
        }
        
        // Set window resizable
        public static void SetResizable(bool resizable)
        {
            SDL.SetWindowResizable(Handle, resizable);
        }

        // Get window resizable
        public static bool GetResizable()
        {
            return (SDL.GetWindowFlags(Handle) & SDL.WindowFlags.Resizable) != 0;
        }
        
        // Set window borderless
        public static void SetBorderless(bool borderless)
        {
            SDL.SetWindowBordered(Handle, !borderless);
        }

        // Get window borderless
        public static bool GetBorderless()
        {
            return (SDL.GetWindowFlags(Handle) & SDL.WindowFlags.Borderless) != 0;
        }
        
        // Set window maximized
        public static void SetMaximized(bool maximized)
        {
            if (maximized)
            {
                SDL.MaximizeWindow(Handle);
                return;
            }

            SDL.RestoreWindow(Handle);
        }

        // Get window maximized
        public static bool GetMaximized()
        {
            return (SDL.GetWindowFlags(Handle) & SDL.WindowFlags.Maximized) != 0;
        }
        
        // Set window minimized
        public static void SetMinimized(bool minimized)
        {
            if (minimized)
            {
                SDL.MinimizeWindow(Handle);
                return;
            }

            SDL.RestoreWindow(Handle);
        }

        // Get window minimized
        public static bool GetMinimized()
        {
            return (SDL.GetWindowFlags(Handle) & SDL.WindowFlags.Minimized) != 0;
        }
        
        // Set window position
        public static void SetPosition(Point position)
        {
            SDL.SetWindowPosition(Handle, (int)position.x, (int)position.y);
        }

        // Get window position
        public static Point GetWindowPosition()
        {
            SDL.GetWindowPosition(Handle, out int x, out int y);
            {
                return new Point(x, y);
            }
        }
        
        // Set window size
        public static void SetSize(Point size)
        {
            SDL.SetWindowSize(Handle, (int)size.x, (int)size.y);
        }

        // Get window size
        public static Point GetSize()
        {
            SDL.GetWindowSize(Handle, out int w, out int h);
            {
                return new Point(w, h);
            }
        }
        
        // Set window width
        public static void SetWidth(int width)
        {
            SDL.SetWindowSize(Handle, width, GetHeight());
        }

        // Get window width
        public static int GetWidth()
        {
            SDL.GetWindowSize(Handle, out int w, out int h);
            {
                return w;
            }
        }
        
        // Set window height
        public static void SetHeight(int height)
        {
            SDL.SetWindowSize(Handle, GetWidth(), height);
        }

        // Get window height
        public static int GetHeight()
        {
            SDL.GetWindowSize(Handle, out int w, out int h);
            {
                return h;
            }
        }
        
        // Set window maximum size
        public static void SetMaximumSize(Point size)
        {
            SDL.SetWindowMaximumSize(Handle, (int)size.x, (int)size.y);
        }

        // Get window maximum size
        public static Point GetMaximumSize()
        {
            SDL.GetWindowMaximumSize(Handle, out int w, out int h);
            {
                return new Point(w, h);
            }
        }
        
        // Set window minimum size
        public static void SetMinimumSize(Point size)
        {
            SDL.SetWindowMinimumSize(Handle, (int)size.x, (int)size.y);
        }

        // Get window minimum size
        public static Point GetMinimumSize()
        {
            SDL.GetWindowMinimumSize(Handle, out int w, out int h);
            {
                return new Point(w, h);
            }
        }
        
        // Set window aspect ratio
        public static void SetAspectRatio(Point ratio)
        {
            SDL.SetWindowAspectRatio(Handle, ratio.x, ratio.y);
        }

        // Get window aspect ratio
        public static Point GetAspectRatio()
        {
            SDL.GetWindowAspectRatio(Handle, out float w, out float h);
            {
                return new Point(w, h);
            }
        }
        
        // Set window vsync
        public static void SetVSync(bool vsync)
        {
            SDL.SetRenderVSync(Graphics.Handle, vsync ? 1 : 0);
        }

        // Get window vsync
        public static bool GetVSync()
        {
            SDL.GetRenderVSync(Graphics.Handle, out int vsync);
            {
                return vsync > 0 ? true : false;
            }
        }
        
        // Get all display ids
        public static uint[] GetDisplays()
        {
            return SDL.GetDisplays(out var count);
        }

        // Get current display id
        public static uint GetCurrentDisplay()
        {
            return SDL.GetDisplayForWindow(Handle);
        }

        // Get current display name
        public static string GetCurrentDisplayName()
        {
            return GetDisplayName(GetCurrentDisplay());
        }
        
        // Get current display size
        public static Point GetCurrentDisplaySize()
        {
            return GetDisplaySize(GetCurrentDisplay());
        }
        
        // Get specific display name
        public static string GetDisplayName(uint displayID)
        {
            return SDL.GetDisplayName(displayID);
        }
        
        // Get specific display size
        public static Point GetDisplaySize(uint displayID)
        {
            SDL.GetDisplayBounds(displayID, out SDL.RectInt rect);
            {
                return new Point(rect.w, rect.h);
            }
        }
        
        // Show window
        public static void Show()
        {
            SDL.ShowWindow(Handle);
        }

        // Hide window
        public static void Hide()
        {
            SDL.HideWindow(Handle);
        }

        // Raise window
        public static void Raise()
        {
            SDL.RaiseWindow(Handle);
        }

        // Restore window
        public static void Restore()
        {
            SDL.RestoreWindow(Handle);
        }

        // Maximize window
        public static void Maximize()
        {
            SDL.MaximizeWindow(Handle);
        }

        // Minimize window
        public static void Minimize()
        {
            SDL.MinimizeWindow(Handle);
        }
    }
}