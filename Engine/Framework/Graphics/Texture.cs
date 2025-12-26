using System;

namespace Hybrid
{
    // Internal
    public unsafe partial class Texture : Resource
    {
        // SDL Texture Handle
        internal SDL.Texture* Handle
        {
            private set;
            get;
        }
        

        internal override void OnDispose()
        {
            if (Handle != null)
            {
                SDL.DestroyTexture(Handle);
                Array.Clear(Pixels);
                Handle = null;
            }
        }
    }
    
    // Texture API
    public unsafe partial class Texture
    {
        // Create Texture from another Texture
        public Texture(Texture texture, TextureAccess access = TextureAccess.Static, TextureScaling scaling = TextureScaling.Pixel)
        {
            // Invalid Texture
            if (texture == null)
                throw new Exception("Invalid texture parameter");

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
    }
    
    // Texture API
    public unsafe partial class Texture
    {
        public void SetPixel(int x, int y, Color32 color32)
        {
            if (x >= 0 && y >= 0 && x < Width && y < Height)
            {
                int index = (y * Width + x) * 4;
                
                Pixels[index + 0] = color32.R;
                Pixels[index + 1] = color32.G;
                Pixels[index + 2] = color32.B;
                Pixels[index + 3] = color32.A;
                return;
            }
            
            // Invalid Position
            throw new Exception($"Invalid position '({x}, {y})' in texture size: '{Size}'");
        }
    
        public Color32 GetPixel(int x, int y)
        {
            if (x >= 0 && y >= 0 && x < Width && y < Height)
            {
                int index = (y * Width + x) * 4;
                
                byte r = Pixels[index + 0];
                byte g = Pixels[index + 1];
                byte b = Pixels[index + 2];
                byte a = Pixels[index + 3];

                return new Color32(r, g, b, a);
            }
            
            // Invalid Position
            throw new Exception($"Invalid position '({x}, {y})' in texture size: '{Size}'");
        }
        
        public void SetPixels(Color32[] colors)
        {
            if (colors.Length == (Width * Height))
            {
                for (int i = 0; i < colors.Length; i++)
                {
                    int index = i * 4;
                    Color32 c = colors[i];

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
        
        public Color32[] GetPixels()
        {
            int count = (Width * Height);
            Color32[] result = new Color32[count];

            for (int i = 0; i < count; i++)
            {
                int index = i * 4;
                
                byte r = Pixels[index + 0];
                byte g = Pixels[index + 1];
                byte b = Pixels[index + 2];
                byte a = Pixels[index + 3];

                result[i] = new Color32(r, g, b, a);
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