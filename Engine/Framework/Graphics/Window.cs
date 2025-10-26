using System;

namespace Hybrid
{
    // Window
    public static unsafe partial class Window
    {
        internal static SDL.Window* Handle
        {
            set;
            get;
        }
        
        
        public static void Create(string title = "Hybrid", int width = 800, int height = 600, bool fullscreen = false, bool resizable = false)
        {
            if (Handle != null) throw new Exception("Only one window instance allowed");
            
            SDL.WindowFlags flags = SDL.WindowFlags.HighPixelDensity;
                
            if (Platform.Current.PlatformDevice == PlatformDevice.Mobile) fullscreen = true;
            if (Platform.Current.PlatformDevice == PlatformDevice.Mobile) resizable = true;
            if (fullscreen) flags |= SDL.WindowFlags.Fullscreen;
            if (resizable) flags |= SDL.WindowFlags.Resizable;
                
            Handle = SDL.CreateWindow(title, width, height, flags);
            Renderer.Create(Handle);
                
            Events.OnEvent += WindowEvents;
            OnCreated?.Invoke();
        }

        internal static void WindowEvents(SDL.Event e)
        {
            SDL.EventType type = (SDL.EventType)e.type;
            
            if (type == SDL.EventType.OrientationChanged) OnOrientation?.Invoke();
            if (type == SDL.EventType.Unfocused) OnUnfocus?.Invoke();
            if (type == SDL.EventType.Resized) OnResized?.Invoke();
            if (type == SDL.EventType.Focused) OnFocus?.Invoke();
            if (type == SDL.EventType.Hidden) OnHidden?.Invoke();
            if (type == SDL.EventType.Moved) OnMoved?.Invoke();
            if (type == SDL.EventType.Shown) OnShown?.Invoke();
        }
        
        public static void Minimize()
        {
            SDL.MinimizeWindow(Handle);
        }

        public static void Maximize()
        {
            SDL.MaximizeWindow(Handle);
        }

        public static void Show()
        {
            SDL.ShowWindow(Handle);
        }

        public static void Hide()
        {
            SDL.HideWindow(Handle);
        }

        internal static void Destroy()
        {
            SDL.DestroyWindow(Handle);
            
            OnDestroyed?.Invoke();
        }
    }
    
    // Properties
    public static unsafe partial class Window
    {
        public static Action OnCreated = null;
        public static Action OnDestroyed = null;
        public static Action OnFocus = null;
        public static Action OnUnfocus = null;
        public static Action OnShown = null;
        public static Action OnHidden = null;
        public static Action OnMoved = null;
        public static Action OnResized = null;
        public static Action OnOrientation = null;
        
        
        public static int Fps
        {
            get; set;
        }

        public static string Title
        {
            set => SDL.SetWindowTitle(Handle, value);
            get => SDL.GetWindowTitle(Handle);
        }

        public static bool Fullscreen
        {
            set => SDL.SetWindowFullscreen(Handle, value);
            get => (SDL.GetWindowFlags(Handle) & SDL.WindowFlags.Fullscreen) != 0;
        }
        
        public static bool Resizable
        {
            set => SDL.SetWindowResizable(Handle, value);
            get => (SDL.GetWindowFlags(Handle) & SDL.WindowFlags.Resizable) != 0;
        }

        public static int Width
        {
            set => SDL.SetWindowSize(Handle, value, Height);
            get
            {
                SDL.GetWindowSize(Handle, out int width, out int height);
                {
                    return width;
                }
            }
        }
        
        public static int Height
        {
            set => SDL.SetWindowSize(Handle, Width, value);
            get
            {
                SDL.GetWindowSize(Handle, out int width, out int height);
                {
                    return height;
                }
            }
        }

        public static Vector2 Size
        {
            set => SDL.SetWindowSize(Handle, (int)value.X, (int)value.Y);
            get
            {
                SDL.GetWindowSize(Handle, out int width, out int height);
                {
                    return new Vector2(width, height);
                }
            }
        }
        
        public static Vector2 MinSize
        {
            set => SDL.SetWindowMinimumSize(Handle, (int)value.X, (int)value.Y);
            get
            {
                SDL.GetWindowMinimumSize(Handle, out int width, out int height);
                {
                    return new Vector2(width, height);
                }
            }
        }
        
        public static Vector2 MaxSize
        {
            set => SDL.SetWindowMaximumSize(Handle, (int)value.X, (int)value.Y);
            get
            {
                SDL.GetWindowMinimumSize(Handle, out int width, out int height);
                {
                    return new Vector2(width, height);
                }
            }
        }
        
        public static Vector2 Position
        {
            set => SDL.SetWindowPosition(Handle, (int)value.X, (int)value.Y);
            get
            {
                SDL.GetWindowPosition(Handle, out int x, out int y);
                {
                    return new Vector2(x, y);
                }
            }
        }
        
        public static bool VSync
        {
            set => SDL.SetRenderVSync(Renderer.Handle, value ? 1 : 0);
            get
            {
                SDL.GetRenderVSync(Renderer.Handle, out int vsync);
                {
                    return vsync > 0;
                }
            }
        }
    }
}