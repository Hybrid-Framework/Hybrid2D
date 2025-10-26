using System;
using Hybrid.Interfaces;

namespace Hybrid
{
    // Texture
    public unsafe partial class Texture : IContentResource, IGraphicsResource
    {
        internal SDL.Texture* Handle
        {
            set;
            get;
        }
        
        // Create Texture
        public Texture(int width, int height, TextureAccess access, TextureScaleMode scaleMode)
        {
            Width = width;
            Height = height;
            Pixels = new byte[width * height * 4];
            Handle = SDL.CreateTexture
            (
                Renderer.Handle,
                SDL.PixelFormat.RGBA32,
                (SDL.TextureAccess)access,
                width,
                height
            );

            if (Handle == null)
            {
                throw new Exception($"Failed to create texture: {SDL.GetError()}");
            }

            SDL.SetTextureScaleMode(Handle, (SDL.ScaleMode)scaleMode);
        }
    
        // Set Pixel
        public void SetPixel(int x, int y, Color color)
        {
            if (x >= 0 && y >= 0 && x < Width && y < Height)
            {
                int index = (y * Width + x) * 4;
                
                Pixels[index + 0] = color.R;
                Pixels[index + 1] = color.G;
                Pixels[index + 2] = color.B;
                Pixels[index + 3] = color.A;
            }
        }
    
        // Get Pixel
        public Color GetPixel(int x, int y)
        {
            if (x >= 0 && y >= 0 && x < Width && y < Height)
            {
                int index = (y * Width + x) * 4;
                
                byte r = Pixels[index + 0];
                byte g = Pixels[index + 1];
                byte b = Pixels[index + 2];
                byte a = Pixels[index + 3];

                return new Color(r, g, b, a);
            }
            
            return Color.Transparent;
        }
        
        // Set Pixels
        public void SetPixels(Color[] colors)
        {
            if (colors.Length != (Width * Height))
            {
                throw new ArgumentException("Array length must match the texture size.");
            }

            for (int i = 0; i < colors.Length; i++)
            {
                int index = i * 4;
                Color c = colors[i];

                Pixels[index + 0] = c.R;
                Pixels[index + 1] = c.G;
                Pixels[index + 2] = c.B;
                Pixels[index + 3] = c.A;
            }
        }
        
        // Get Pixels
        public Color[] GetPixels()
        {
            int count = (Width * Height);
            Color[] result = new Color[count];

            for (int i = 0; i < count; i++)
            {
                int index = i * 4;
                
                byte r = Pixels[index + 0];
                byte g = Pixels[index + 1];
                byte b = Pixels[index + 2];
                byte a = Pixels[index + 3];

                result[i] = new Color(r, g, b, a);
            }

            return result;
        }
        
        // Apply Texture
        public void Apply()
        {
            fixed (byte* p = Pixels)
            {
                SDL.UpdateTexture(Handle, null, (IntPtr)p, (Width * 4));
            }
        }
    }
    
    // Properties
    public unsafe partial class Texture
    {
        public int Width
        {
            get;
        }

        public int Height
        {
            get;
        }

        public byte[] Pixels
        {
            get;
            set;
        }

        public TextureAccess Access
        {
            get => (TextureAccess)SDL.GetTextureAccess(Handle);
        }
        
        public TextureScaleMode ScaleMode
        {
            set => SDL.SetTextureScaleMode(Handle, (SDL.ScaleMode)value);
            get
            {
                SDL.GetTextureScaleMode(Handle, out var mode);
                {
                    return (TextureScaleMode)mode;
                }
            }
        }
    }
    
    // Dispose
    public unsafe partial class Texture
    {
        public bool Disposed { get; set; }
        
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool dispose)
        {
            if (Disposed) return;
            Disposed = true;

            if (dispose)
            {
                SDL.DestroyTexture(Handle);
            }
        }

        ~Texture()
        {
            Dispose(true);
        }
    }
}