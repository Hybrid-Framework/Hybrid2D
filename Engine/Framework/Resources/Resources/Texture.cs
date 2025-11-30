using System;

namespace Hybrid
{
    // Texture
    public unsafe partial class Texture : Resource
    {
        // SDL Texture Handle
        internal SDL.Texture* Handle
        {
            get;
            set;
        }
        
        // Create Texture from another Texture
        public Texture(Texture texture, TextureAccess access = TextureAccess.Static, TextureScaling scaling = TextureScaling.Pixel)
        {
            // Invalid Texture
            if (texture == null) throw new ArgumentNullException(nameof(texture));

            // Create Texture
            {
                Width = texture.Width;
                Height = texture.Height;
                Pixels = new byte[Width * Height * 4];
                Array.Copy(texture.Pixels, Pixels, Pixels.Length);
                Handle = SDL.CreateTexture
                (
                    Graphics.Handle,
                    SDL.PixelFormat.RGBA32,
                    (SDL.TextureAccess)access,
                    Width,
                    Height
                );
            }

            // Apply
            Scaling = scaling;
            Apply();
        }

        // Create Texture from constructor
        public Texture(int width, int height, TextureAccess access = TextureAccess.Static, TextureScaling scaling = TextureScaling.Pixel)
        {
            // Create Texture
            {
                Width = width;
                Height = height;
                Pixels = new byte[width * height * 4];
                Handle = SDL.CreateTexture
                (
                    Graphics.Handle,
                    SDL.PixelFormat.RGBA32,
                    (SDL.TextureAccess)access,
                    width,
                    height
                );
            }

            // Apply
            Scaling = scaling;
            Apply();
        }
        
        // Create Texture with pixels
        internal Texture(byte[] pixels, int width, int height, TextureAccess access = TextureAccess.Static, TextureScaling scaling = TextureScaling.Pixel)
        {
            // Create Texture
            {
                Width = width;
                Height = height;
                Pixels = pixels;
                Handle = SDL.CreateTexture
                (
                    Graphics.Handle,
                    SDL.PixelFormat.RGBA32,
                    (SDL.TextureAccess)access,
                    Width,
                    Height
                );
            }
            
            // Apply
            Scaling = scaling;
            Apply();
        }
        
        internal override void OnDispose()
        {
            base.OnDispose();
            
            if (Handle != null)
            {
                SDL.DestroyTexture(Handle);
                Handle = null;
            }
            
            Array.Clear(Pixels);
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
                return;
            }
            
            // Invalid Position
            throw new Exception($"Invalid position '({x}, {y})' in texture size: '{Size}'");
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
            
            // Invalid Position
            throw new Exception($"Invalid position '({x}, {y})' in texture size: '{Size}'");
        }
        
        public void SetPixels(Color[] colors)
        {
            if (colors.Length == (Width * Height))
            {
                for (int i = 0; i < colors.Length; i++)
                {
                    int index = i * 4;
                    Color c = colors[i];

                    Pixels[index + 0] = c.R;
                    Pixels[index + 1] = c.G;
                    Pixels[index + 2] = c.B;
                    Pixels[index + 3] = c.A;
                }
                
                return;
            }
            
            // Invalid Array Length
            throw new Exception($"Array length '{colors.Length}' must match the texture size: '{Width * Height}'");
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
                if (!SDL.UpdateTexture(Handle, null, (IntPtr)p, (Width * 4)))
                {
                    throw new Exception($"Failed to apply texture: {SDL.GetError()}");
                }
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
        }
        
        public Vector2 Size
        {
            get => new Vector2(Width, Height);
        }

        public TextureFormat Format
        {
            get => (TextureFormat)SDL.GetTextureFormat(Handle);
        }

        public TextureAccess Access
        {
            get => (TextureAccess)SDL.GetTextureAccess(Handle);
        }
        
        public TextureScaling Scaling
        {
            set => SDL.SetTextureScaleMode(Handle, (SDL.ScaleMode)value);
            get
            {
                SDL.GetTextureScaleMode(Handle, out var mode);
                {
                    return (TextureScaling)mode;
                }
            }
        }
    }
}