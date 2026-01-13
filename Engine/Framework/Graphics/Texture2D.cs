using System.IO;
using System;

namespace Hybrid
{
    // Internal
    public unsafe partial class Texture2D : Resource
    {
        internal SDL.Texture* Handle
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

        internal byte[] Pixels
        {
            get; set;
        }

        internal Texture2D(string path)
        {
            path = Path.Combine(SDL.GetBasePath() + path);
            {
                var source = SDL_image.Load(path);
                if (source == null) throw new Exception($"Failed to load texture '{path}' {SDL.GetError()}");

                var surface = SDL.ConvertSurface(source, SDL.PixelFormat.RGBA32);
                if (surface == null) throw new Exception($"Failed to load texture '{path} {SDL.GetError()}'");

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
                    fixed (byte* dst = pixels)
                    {
                        for (int y = 0; y < height; y++)
                        {
                            byte* srcRow = src + y * pitch;
                            byte* dstRow = dst + y * width * 4;
                            Buffer.MemoryCopy(srcRow, dstRow, width * 4, width * 4);
                        }
                    }
                }
                
                Width = width;
                Height = height;
                Pixels = pixels;
                Handle = SDL.CreateTexture(Graphics.Handle, SDL.PixelFormat.RGBA32, SDL.TextureAccess.Static, width, height);
                {
                    if (Handle == null)
                    {
                        throw new Exception($"Failed to create texture: {SDL.GetError()}");
                    }
                }
                    
                SDL.DestroySurface(surface);
                SDL.DestroySurface(source);
                Apply();
            }
        }

        internal override void Destroy()
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

    public unsafe partial class Texture2D
    {
        public void SetPixel(int x, int y, Color color)
        {
            if (x < 0 || y < 0 || x >= Width || y >= Height)
            {
                throw new Exception($"Invalid position '({x}, {y})' in texture size: '{Width}, {Height}'");
            }
            
            var index = (y * Width + x) * 4;
            var color32 = Color.ToSDLColor32(color);
            
            Pixels[index + 0] = color32.r;
            Pixels[index + 1] = color32.g;
            Pixels[index + 2] = color32.b;
            Pixels[index + 3] = color32.a;
        }

        public Color GetPixel(int x, int y)
        {
            if (x < 0 || y < 0 || x >= Width || y >= Height)
            {
                throw new Exception($"Invalid position '({x}, {y})' in texture size: '{Width}, {Height}'");
            }
            
            int index = (y * Width + x) * 4;

            var color32 = new SDL.Color32
            (
                Pixels[index + 0],
                Pixels[index + 1],
                Pixels[index + 2],
                Pixels[index + 3]
            );
            
            return Color.FromSDLColor32(color32);
        }

        public void SetPixels(Color[] colors)
        {
            if (colors.Length != Width * Height)
            {
                throw new Exception($"Array length '{colors.Length}' must match the texture size: '{Width * Height}'");
            }

            for (int i = 0; i < colors.Length; i++)
            {
                var index = i * 4;
                var color32 = Color.ToSDLColor32(colors[i]);
            
                Pixels[index + 0] = color32.r;
                Pixels[index + 1] = color32.g;
                Pixels[index + 2] = color32.b;
                Pixels[index + 3] = color32.a;
            }
        }

        public Color[] GetPixels()
        {
            int count = Width * Height;
            Color[] result = new Color[count];

            for (int i = 0; i < count; i++)
            {
                int index = i * 4;
                
                var color32 = new SDL.Color32
                (
                    Pixels[index + 0],
                    Pixels[index + 1],
                    Pixels[index + 2],
                    Pixels[index + 3]
                );

                result[i] = Color.FromSDLColor32(color32);
            }

            return result;
        }

        public void Apply()
        {
            fixed (byte* p = Pixels)
            {
                if (!SDL.UpdateTexture(Handle, null, (IntPtr)p, (Width * 4)))
                {
                    throw new Exception($"Failed to apply texture");
                }
            }
        }
        
        public int GetWidth()
        {
            return Width;
        }
        
        public int GetHeight()
        {
            return Height;
        }
    }
}