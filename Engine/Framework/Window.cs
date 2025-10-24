using System;

namespace Hybrid
{
    // Window
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
        
        
        public static void Create(string title = "Hybrid", int width = 800, int height = 600, bool fullscreen = false, bool resizable = false)
        {
            if (_handle == null)
            {
                SDL.WindowFlags flags = SDL.WindowFlags.HighPixelDensity;
                
                if (Platform.Current.PlatformDevice == PlatformDevice.Mobile) fullscreen = true;
                if (Platform.Current.PlatformDevice == PlatformDevice.Mobile) resizable = true;
                if (fullscreen) flags |= SDL.WindowFlags.Fullscreen;
                if (resizable) flags |= SDL.WindowFlags.Resizable;
                
                Handle = SDL.CreateWindow(title, width, height, flags);
                Renderer.Create(Handle);
                
                OnCreated?.Invoke();
            }
            else
            {
                throw new Exception("Only one window instance allowed");
            }
        }

        internal static void Events(SDL.Event e)
        {
            if (e.window.windowID == WindowID)
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

        public static void Destroy()
        {
            SDL.DestroyWindow(Handle);
            
            OnDestroyed?.Invoke();
        }
    }
    
    // Properties
    public static unsafe partial class Window
    {
        private static SDL.Window* _handle;
        internal static SDL.Window* Handle
        {
            set => _handle = value;
            get
            {
                if (_handle == null)
                {
                    throw new Exception("Window instance does not exist");
                }

                return _handle;
            }
        }

        public static int TargetFPS
        {
            get; set;
        }
        
        public static uint WindowID
        {
            get => SDL.GetWindowID(Handle);
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
                SDL.GetWindowSize(Handle, out int w, out int h);
                {
                    return w;
                }
            }
        }
        
        public static int Height
        {
            set => SDL.SetWindowSize(Handle, Width, value);
            get
            {
                SDL.GetWindowSize(Handle, out int w, out int h);
                {
                    return h;
                }
            }
        }

        public static Vector2 Size
        {
            set => SDL.SetWindowSize(Handle, (int)value.x, (int)value.y);
            get
            {
                SDL.GetWindowSize(Handle, out int w, out int h);
                {
                    return new Vector2(w, h);
                }
            }
        }
        
        public static Vector2 MinSize
        {
            set => SDL.SetWindowMinimumSize(Handle, (int)value.x, (int)value.y);
            get
            {
                SDL.GetWindowMinimumSize(Handle, out int w, out int h);
                {
                    return new Vector2(w, h);
                }
            }
        }
        
        public static Vector2 MaxSize
        {
            set => SDL.SetWindowMaximumSize(Handle, (int)value.x, (int)value.y);
            get
            {
                SDL.GetWindowMinimumSize(Handle, out int w, out int h);
                {
                    return new Vector2(w, h);
                }
            }
        }
        
        public static Vector2 Position
        {
            set => SDL.SetWindowPosition(Handle, (int)value.x, (int)value.y);
            get
            {
                SDL.GetWindowPosition(Handle, out int w, out int h);
                {
                    return new Vector2(w, h);
                }
            }
        }
        
        public static bool VSync
        {
            set => SDL.SetRenderVSync(Renderer.Handle, value ? 1 : 0);
            get
            {
                SDL.GetRenderVSync(Renderer.Handle, out int value);
                {
                    return value > 0;
                }
            }
        }
    }
}