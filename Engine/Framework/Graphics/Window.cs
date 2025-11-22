using System;

namespace Hybrid
{
    // Window API
    public static class Window
    {
        public static int Fps
        {
            get => Engine.GraphicsDevice.Fps;
            set => Engine.GraphicsDevice.Fps = value;
        }

        public static string Title
        {
            get => Engine.GraphicsDevice.Title;
            set => Engine.GraphicsDevice.Title = value;
        }

        public static bool Fullscreen
        {
            get => Engine.GraphicsDevice.Fullscreen;
            set => Engine.GraphicsDevice.Fullscreen = value;
        }

        public static bool Resizable
        {
            get => Engine.GraphicsDevice.Resizable;
            set => Engine.GraphicsDevice.Resizable = value;
        }

        public static Vector2 Size
        {
            get => Engine.GraphicsDevice.Size;
            set => Engine.GraphicsDevice.Size = value;
        }
        
        public static Vector2 MinSize
        {
            get => Engine.GraphicsDevice.MinSize;
            set => Engine.GraphicsDevice.MinSize = value;
        }
        
        public static Vector2 MaxSize
        {
            get => Engine.GraphicsDevice.MaxSize;
            set => Engine.GraphicsDevice.MaxSize = value;
        }
        
        public static Vector2 Position
        {
            get => Engine.GraphicsDevice.Position;
            set => Engine.GraphicsDevice.Position = value;
        }
        
        public static int Width
        {
            get => Engine.GraphicsDevice.Width;
            set => Engine.GraphicsDevice.Width = value;
        }
        
        public static int Height
        {
            get => Engine.GraphicsDevice.Height;
            set => Engine.GraphicsDevice.Height = value;
        }

        public static bool VSync
        {
            get => Engine.GraphicsDevice.VSync;
            set => Engine.GraphicsDevice.VSync = value;
        }

        public static string GraphicsDriver
        {
            get => Engine.GraphicsDevice.GraphicsDriver;
        }
    }
}