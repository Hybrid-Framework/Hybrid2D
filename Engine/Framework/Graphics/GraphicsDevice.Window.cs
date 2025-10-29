using System;

namespace Hybrid
{
    // Graphics Device (Window)
    public static unsafe partial class GraphicsDevice
    {
        public static int Fps
        {
            get; set;
        }

        public static string Title
        {
            set => SDL.SetWindowTitle(Window, value);
            get => SDL.GetWindowTitle(Window);
        }

        public static bool Fullscreen
        {
            set => SDL.SetWindowFullscreen(Window, value);
            get => (SDL.GetWindowFlags(Window) & SDL.WindowFlags.Fullscreen) != 0;
        }
        
        public static bool Resizable
        {
            set => SDL.SetWindowResizable(Window, value);
            get => (SDL.GetWindowFlags(Window) & SDL.WindowFlags.Resizable) != 0;
        }

        public static int Width
        {
            set => SDL.SetWindowSize(Window, value, Height);
            get
            {
                SDL.GetWindowSize(Window, out int width, out int height);
                {
                    return width;
                }
            }
        }
        
        public static int Height
        {
            set => SDL.SetWindowSize(Window, Width, value);
            get
            {
                SDL.GetWindowSize(Window, out int width, out int height);
                {
                    return height;
                }
            }
        }

        public static Vector2 Size
        {
            set => SDL.SetWindowSize(Window, (int)value.X, (int)value.Y);
            get
            {
                SDL.GetWindowSize(Window, out int width, out int height);
                {
                    return new Vector2(width, height);
                }
            }
        }
        
        public static Vector2 MinSize
        {
            set => SDL.SetWindowMinimumSize(Window, (int)value.X, (int)value.Y);
            get
            {
                SDL.GetWindowMinimumSize(Window, out int width, out int height);
                {
                    return new Vector2(width, height);
                }
            }
        }
        
        public static Vector2 MaxSize
        {
            set => SDL.SetWindowMaximumSize(Window, (int)value.X, (int)value.Y);
            get
            {
                SDL.GetWindowMinimumSize(Window, out int width, out int height);
                {
                    return new Vector2(width, height);
                }
            }
        }
        
        public static Vector2 Position
        {
            set => SDL.SetWindowPosition(Window, (int)value.X, (int)value.Y);
            get
            {
                SDL.GetWindowPosition(Window, out int x, out int y);
                {
                    return new Vector2(x, y);
                }
            }
        }
        
        public static bool VSync
        {
            set => SDL.SetRenderVSync(Renderer, value ? 1 : 0);
            get
            {
                SDL.GetRenderVSync(Renderer, out int vsync);
                {
                    return vsync > 0;
                }
            }
        }
        
        public static void Minimize()
        {
            if (SDL.MinimizeWindow(Window))
            {
                OnMinimized?.Invoke();
            }
        }

        public static void Maximize()
        {
            if (SDL.MaximizeWindow(Window))
            {
                OnMaximized?.Invoke();
            }
        }
    }
}