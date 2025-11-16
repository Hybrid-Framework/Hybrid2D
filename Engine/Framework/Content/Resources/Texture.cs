using System;

namespace Hybrid
{
    // Texture
    public unsafe partial class Texture : Resource
    {
        internal int MaxTextureSize { get; set; } = 4096;
        internal SDL.Texture* Handle { set; get; }
        

        public Texture(Texture texture, TextureAccess access = TextureAccess.Static, TextureScaleMode scaleMode = TextureScaleMode.Pixel)
        {
            // Invalid Source
            if (texture == null)
                throw new ArgumentNullException(nameof(texture));

            // Invalid Texture Size
            if (texture.Width > MaxTextureSize || texture.Height > MaxTextureSize)
                throw new ArgumentException($"Texture can't be larger than '({MaxTextureSize}x{MaxTextureSize})'");

            // Create SDL Texture
            {
                Width = texture.Width;
                Height = texture.Height;
                Pixels = new byte[Width * Height * 4];
                Array.Copy(texture.Pixels, Pixels, Pixels.Length);
                Handle = SDL.CreateTexture(
                    Engine.GraphicsDevice.Renderer,
                    (SDL.PixelFormat)Format,
                    (SDL.TextureAccess)access,
                    Width,
                    Height
                );
            }

            // Set texture scaling mode
            SDL.SetTextureScaleMode(Handle, (SDL.ScaleMode)scaleMode);
            Apply();
        }


        // Create Texture
        public Texture(int width, int height, TextureAccess access = TextureAccess.Static, TextureScaleMode scaleMode = TextureScaleMode.Pixel)
        {
            // Invalid Texture Size
            if (width > MaxTextureSize || height > MaxTextureSize)
                throw new ArgumentException($"Texture can't be larger than '({MaxTextureSize}x{MaxTextureSize})'");

            // Create SDL Texture
            {
                Width = width;
                Height = height;
                Pixels = new byte[width * height * 4];
                Handle = SDL.CreateTexture
                (
                    Engine.GraphicsDevice.Renderer,
                    (SDL.PixelFormat)Format,
                    (SDL.TextureAccess)access,
                    width,
                    height
                );
            }

            // Set texture scaling mode
            SDL.SetTextureScaleMode(Handle, (SDL.ScaleMode)scaleMode);
            Apply();
        }

        internal override void OnDispose()
        {
            if (Handle != null)
            {
                SDL.DestroyTexture(Handle);
                Handle = null;
            }
            
            Array.Clear(Pixels);
            Height = 0;
            Width = 0;
        }
    }
    
    // Texture API
    public unsafe partial class Texture
    {
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
        
        public void SetPixels(Color[] colors)
        {
            // Invalid Array Length
            if (colors.Length != (Width * Height))
                throw new ArgumentException("Array length must match the texture size");

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
        
        public void Apply()
        {
            fixed (byte* p = Pixels)
            {
                // Update SDL Texture
                if (!SDL.UpdateTexture(Handle, null, (IntPtr)p, (Width * 4)))
                    throw new Exception($"Failed to apply texture: {SDL.GetError()}");
            }
        }
    }
    
    // Properties
    public unsafe partial class Texture
    {
        public int Width
        {
            get;
            internal set;
        }

        public int Height
        {
            get;
            internal set;
        }

        public byte[] Pixels
        {
            get;
            internal set;
        }

        public TextureFormat Format
        {
            get => TextureFormat.RGBA32;
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
}