using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System;

namespace Hybrid
{
    // Internal API
    public sealed partial class Resources : Module<Resources>
    {
        private Resources() { }

        // Dispose
        internal override void OnDispose()
        {
            // For Each Resource In Resources
            foreach (var resource in AllResources.ToArray())
            {
                // Destroy
                Object.Destroy(resource);
            }
            
            // Empty
            AllResources.Clear();
        }
    }
    
    // Resources API
    public partial class Resources
    {
        private static readonly List<Resource> AllResources = new List<Resource>();
        
        
        public static T Create<T>(string path) where T : Resource
        {
            Resource resource = typeof(T) switch
            {
                var t when t == typeof(AudioClip) => CreateSound(path),
                var t when t == typeof(Texture) => CreateTexture(path),
                var t when t == typeof(Font) => CreateFont(path),
                
                _ => throw new Exception($"Unsupported resource type {typeof(T)}")
            };

            // Create Resource
            AllResources.Add(resource);
            resource.Path = path;
            return resource as T;
        }
    }
    
    // Texture Resources
    public unsafe partial class Resources
    {
        private static Texture CreateTexture(string path)
        {
            // Load Surface From File
            var surface = SDL_image.Load(path);
            
            // Invalid Surface
            if (surface == null)
                throw new Exception($"Failed to load texture '{path}': {SDL.GetError()}");

            // Convert surface to RGBA32 format
            var converted = SDL.ConvertSurface(surface, SDL.PixelFormat.RGBA32);
            
            // Invalid Convert
            if (converted == null)
                throw new Exception($"Failed to convert texture '{path}' to RGBA32: {SDL.GetError()}");

            // Surface Data
            int width  = converted->width;
            int height = converted->height;
            int pitch  = converted->pitch;
            int length = width * height * 4;
            byte[] pixels = new byte[length];
            byte* src = (byte*)converted->pixels.ToPointer();

            // Copy Data
            if (pitch == width * 4)
            {
                // Block copy
                fixed (byte* dst = pixels)
                {
                    Buffer.MemoryCopy(src, dst, length, length);
                }
            }
            else
            {
                // Row by row copy 
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

            // Destroy Resources
            SDL.DestroySurface(converted);
            SDL.DestroySurface(surface);

            // Create Texture
            var texture = new Texture(width, height);
            texture.Pixels = pixels;
            texture.Apply();
            return texture;
        }
    }
    
    // Audio Resources
    public unsafe partial class Resources
    {
        private static AudioClip CreateSound(string path)
        {
            // Load Sound From File
            var audio = SDL_mixer.LoadAudio(Audio.Handle, path, false);
            
            // Invalid Sound
            if (audio == null)
                throw new Exception($"Failed to load audio '{path}': {SDL.GetError()}");

            // Create Audio Clip
            return new AudioClip(audio);
        }
    }
    
    // Font Resources
    public unsafe partial class Resources
    {
        private static Font CreateFont(string path)
        {
            // Load Font From File
            var font = SDL_ttf.OpenFont(path, 32);
            
            // Invalid Font
            if (font == null)
                throw new Exception($"Failed to load font '{path}': {SDL.GetError()}");

            // Create Font
            return new Font(font);
        }
    }
}