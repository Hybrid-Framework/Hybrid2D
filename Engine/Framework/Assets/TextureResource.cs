using System;

namespace Hybrid
{
    // Texture Resource
    public unsafe class TextureResource : Resource
    {
        internal TextureResource(int width, int height)
        {
            // Enforce Maximum Size
            if (width > Texture.MaxTextureSize || height > Texture.MaxTextureSize)
            {
                throw new ArgumentException($"Texture can't be larger than '({Texture.MaxTextureSize}x{Texture.MaxTextureSize})'");
            }
            
            // Create SDL Texture
            {
                Width = width;
                Height = height;
                Pixels = new byte[width * height * 4];
                Handle = SDL.CreateTexture
                (
                    Engine.GraphicsDevice.Renderer,
                    (SDL.PixelFormat)Format,
                    (SDL.TextureAccess)TextureAccess.Static,
                    width,
                    height
                );
            }
            
            // Set Scaling Mode
            SDL.SetTextureScaleMode(Handle, (SDL.ScaleMode)TextureScaleMode.Pixel);
        }
        
        internal SDL.Texture* Handle
        {
            set;
            get;
        }
        
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
            internal set => SDL.SetTextureScaleMode(Handle, (SDL.ScaleMode)value);
            get
            {
                SDL.GetTextureScaleMode(Handle, out var mode);
                {
                    return (TextureScaleMode)mode;
                }
            }
        }

        internal override void Dispose()
        {
            if (Handle != null)
            {
                SDL.DestroyTexture(Handle);
            }
        }
    }
}