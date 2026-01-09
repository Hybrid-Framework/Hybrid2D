using System;

namespace Hybrid
{
    // Internal
    public unsafe partial class Texture
    {
        internal SDL.Texture* Handle
        {
            get; private set;
        }
        
        internal int Width
        {
            get; set;
        }

        internal int Height
        {
            get; set;
        }

        internal byte[] Pixels
        {
            get; set;
        }

        internal Texture(int width, int height, byte[] pixels)
        {
            Width = width;
            Height = height;
            Pixels = pixels;
            Handle = SDL.CreateTexture
            (
                Graphics.Handle,
                SDL.PixelFormat.RGBA32,
                SDL.TextureAccess.Static,
                width,
                height
            );
            
            Apply(this);
        }
    }

    // Texture Management
    public unsafe partial class Texture
    {
        public static Texture Create(string path)
        {
            path = SDL.GetBasePath() + path;
            
            var source = SDL_image.Load(path);
            if (source == null) throw new Exception($"Failed to load texture '{path}'");

            var surface = SDL.ConvertSurface(source, SDL.PixelFormat.RGBA32);
            if (surface == null) throw new Exception($"Failed to load texture '{path}'");

            int width = surface->width;
            int height = surface->height;
            int pitch = surface->pitch;
            int length = width * height * 4;
            byte[] pixels = new byte[length];
            byte* src = (byte*)surface->pixels.ToPointer();

            if (pitch == width * 4)
            {
                fixed (byte* dst = pixels)
                {
                    Buffer.MemoryCopy(src, dst, length, length);
                }
            }
            else
            {
                fixed (byte* dstBase = pixels)
                {
                    for (int y = 0; y < height; y++)
                    {
                        byte* srcRow = src + y * pitch;
                        byte* dstRow = dstBase + y * width * 4;
                        Buffer.MemoryCopy(srcRow, dstRow, width * 4, width * 4);
                    }
                }
            }

            SDL.DestroySurface(surface);
            SDL.DestroySurface(source);

            return new Texture(width, height, pixels);
        }

        public static void Destroy(Texture texture)
        {
            if (texture.Handle != null)
            {
                SDL.DestroyTexture(texture.Handle);
                texture.Handle = null;
            }
            
            Array.Clear(texture.Pixels);
            texture.Height = 0;
            texture.Width = 0;
        }
    }
    
    // Pixels
    public unsafe partial class Texture
    {
        public static void SetPixel(Texture texture, int x, int y, Color32 color32)
        {
            if (x >= 0 && y >= 0 && x < texture.Width && y < texture.Height)
            {
                int index = (y * texture.Width + x) * 4;

                texture.Pixels[index + 0] = color32.R;
                texture.Pixels[index + 1] = color32.G;
                texture.Pixels[index + 2] = color32.B;
                texture.Pixels[index + 3] = color32.A;
                return;
            }

            // Invalid Position
            throw new Exception($"Invalid position '({x}, {y})' in texture size: '{texture.Width}, {texture.Height}'");
        }

        public static Color32 GetPixel(Texture texture, int x, int y)
        {
            if (x >= 0 && y >= 0 && x < texture.Width && y < texture.Height)
            {
                int index = (y * texture.Width + x) * 4;

                byte r = texture.Pixels[index + 0];
                byte g = texture.Pixels[index + 1];
                byte b = texture.Pixels[index + 2];
                byte a = texture.Pixels[index + 3];

                return new Color32(r, g, b, a);
            }

            // Invalid Position
            throw new Exception($"Invalid position '({x}, {y})' in texture size: '{texture.Width}, {texture.Height}'");
        }

        public static void SetPixels(Texture texture, Color32[] colors)
        {
            if (colors.Length == (texture.Width * texture.Height))
            {
                for (int i = 0; i < colors.Length; i++)
                {
                    int index = i * 4;
                    Color32 c = colors[i];

                    texture.Pixels[index + 0] = c.R;
                    texture.Pixels[index + 1] = c.G;
                    texture.Pixels[index + 2] = c.B;
                    texture.Pixels[index + 3] = c.A;
                }

                return;
            }

            // Invalid Array Length
            throw new Exception($"Array length '{colors.Length}' must match the texture size: '{texture.Width * texture.Height}'");
        }

        public static Color32[] GetPixels(Texture texture)
        {
            int count = (texture.Width * texture.Height);
            Color32[] result = new Color32[count];

            for (int i = 0; i < count; i++)
            {
                int index = i * 4;

                byte r = texture.Pixels[index + 0];
                byte g = texture.Pixels[index + 1];
                byte b = texture.Pixels[index + 2];
                byte a = texture.Pixels[index + 3];

                result[i] = new Color32(r, g, b, a);
            }

            return result;
        }

        public static void Apply(Texture texture)
        {
            fixed (byte* p = texture.Pixels)
            {
                if (!SDL.UpdateTexture(texture.Handle, null, (IntPtr)p, (texture.Width * 4)))
                {
                    throw new Exception($"Failed to apply texture");
                }
            }
        }
    }
    
    // Properties
    public partial class Texture
    {
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