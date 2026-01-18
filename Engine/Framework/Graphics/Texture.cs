using System.IO;
using System;

namespace Hybrid
{
    // Internal
    public sealed unsafe partial class Texture
    {
        internal SDL.Texture* Handle
        {
            get; set;
        }
        
        internal string Format
        {
            get; set;
        }

        internal byte[] Pixels
        {
            get; set;
        }
        
        internal int Width
        {
            get; set;
        }
        
        internal int Height
        {
            get; set;
        }

        internal Texture(string path)
        {
            path = Path.Combine(SDL.GetBasePath() + path);
            {
                var surface = SDL_image.Load(path);
                if (surface == null) throw new Exception($"Failed to load texture '{path}' {SDL.GetError()}");

                var converted = SDL.ConvertSurface(surface, SDL.PixelFormat.RGBA32);
                if (converted == null) throw new Exception($"Failed to load texture '{path} {SDL.GetError()}'");

                Width = converted->width;
                Height = converted->height;
                int length = Width * Height * 4;
                {
                    Pixels = new byte[length];
                    fixed (byte* dst = Pixels)
                    {
                        byte* src = (byte*)converted->pixels.ToPointer();
                        Buffer.MemoryCopy(src, dst, length, length);
                    }
                
                    SDL.DestroySurface(surface);
                    SDL.DestroySurface(converted);
                    Handle = SDL.CreateTexture(Graphics.Handle, SDL.PixelFormat.RGBA32, SDL.TextureAccess.Static, Width, Height);
                    {
                        Format = SDL.GetTextureFormat(Handle).ToString();
                    
                        if (Handle == null)
                        {
                            throw new Exception($"Failed to create texture: {SDL.GetError()}");
                        }
                    }
                
                    Apply(this);
                }
            }
        }
    }

    // Create & Destroy
    public unsafe partial class Texture
    {
        public static Texture CreateTexture(string path)
        {
            return new Texture(path);
        }

        public static void DestroyTexture(Texture texture)
        {
            if (texture.Handle != null)
            {
                SDL.DestroyTexture(texture.Handle);
                texture.Handle = null;
            }
            
            Array.Clear(texture.Pixels);
            texture.Format = "Unknown";
            texture.Height = 0;
            texture.Width = 0;
        }
    }
    
    // Texture API
    public unsafe partial class Texture
    {
        public static void SetPixel(Texture texture, int x, int y, Color color)
        {
            if (x < 0 || y < 0 || x >= texture.Width || y >= texture.Height)
            {
                throw new Exception($"Invalid position '({x}, {y})' in texture size: '{texture.Width}, {texture.Height}'");
            }

            int index = (y * texture.Width + x) * 4;

            texture.Pixels[index + 0] = (byte)(color.r * 255f);
            texture.Pixels[index + 1] = (byte)(color.g * 255f);
            texture.Pixels[index + 2] = (byte)(color.b * 255f);
            texture.Pixels[index + 3] = (byte)(color.a * 255f);
        }
        
        public static Color GetPixel(Texture texture, int x, int y)
        {
            if (x < 0 || y < 0 || x >= texture.Width || y >= texture.Height)
            {
                throw new Exception($"Invalid position '({x}, {y})' in texture size: '{texture.Width}, {texture.Height}'");
            }

            int index = (y * texture.Width + x) * 4;

            return new Color
            (
                texture.Pixels[index + 0] / 255f,
                texture.Pixels[index + 1] / 255f,
                texture.Pixels[index + 2] / 255f,
                texture.Pixels[index + 3] / 255f
            );
        }
        
        public static void SetPixels(Texture texture, Color[] pixels)
        {
            if (pixels.Length != texture.Width * texture.Height)
            {
                throw new Exception($"Array length '{pixels.Length}' must match the texture size: '{texture.Width * texture.Height}'");
            }

            for (int i = 0; i < pixels.Length; i++)
            {
                int index = i * 4;
                Color c = pixels[i];

                texture.Pixels[index + 0] = (byte)(c.r * 255f);
                texture.Pixels[index + 1] = (byte)(c.g * 255f);
                texture.Pixels[index + 2] = (byte)(c.b * 255f);
                texture.Pixels[index + 3] = (byte)(c.a * 255f);
            }
        }

        public static Color[] GetPixels(Texture texture)
        {
            int count = texture.Width * texture.Height;
            Color[] result = new Color[count];

            for (int i = 0; i < count; i++)
            {
                int index = i * 4;

                result[i] = new Color
                (
                    texture.Pixels[index + 0] / 255f,
                    texture.Pixels[index + 1] / 255f,
                    texture.Pixels[index + 2] / 255f,
                    texture.Pixels[index + 3] / 255f
                );
            }

            return result;
        }
        
        public static void Apply(Texture texture, Rect? rect = null)
        {
            fixed (byte* p = texture.Pixels)
            {
                if (!SDL.UpdateTexture(texture.Handle, Rect.ToSDLRectInt(rect), (IntPtr)p, texture.Width * 4))
                {
                    throw new Exception("Failed to apply texture");
                }
            }
        }
        
        public static string GetFormat(Texture texture)
        {
            return texture.Format;
        }

        public static int GetWidth(Texture texture)
        {
            return texture.Width;
        }
        
        public static int GetHeight(Texture texture)
        {
            return texture.Height;
        }
    }
}
