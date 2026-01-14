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

        internal Texture(string path)
        {
            Handle = SDL_image.LoadTexture(Graphics.Handle, path);
            {
                if (Handle == null)
                {
                    throw new Exception($"Failed to create texture: {SDL.GetError()}");
                }
            }
        }
    }

    // Create & Destroy
    public unsafe partial class Texture
    {
        public static Texture CreateTexture(string path)
        {
            path = Path.Combine(SDL.GetBasePath() + path);
            {
                return new Texture(path);
            }
        }

        public static void DestroyTexture(Texture texture)
        {
            if (texture != null)
            {
                if (texture.Handle != null)
                {
                    SDL.DestroyTexture(texture.Handle);
                    texture.Handle = null;
                }
            }
        }
    }
    
    // Static
    public unsafe partial class Texture
    {
        public static string GetFormat(Texture texture)
        {
            return SDL.GetTextureFormat(texture.Handle).ToString();
        }

        public static int GetWidth(Texture texture)
        {
            return SDL.GetTextureWidth(texture.Handle);
        }
        
        public static int GetHeight(Texture texture)
        {
            return SDL.GetTextureHeight(texture.Handle);
        }
    }
    
    // Public
    public partial class Texture
    {
        public string GetFormat()
        {
            return GetFormat(this);
        }

        public int GetWidth()
        {
            return GetWidth(this);
        }
        
        public int GetHeight()
        {
            return GetHeight(this);
        }
    }
}