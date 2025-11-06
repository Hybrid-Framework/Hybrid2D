using System.Collections.Generic;
using System.IO;
using System;

namespace Hybrid
{
    // Resource Management
    public partial class Assets : Module
    {
        private static Dictionary<string, Asset> Cache = new Dictionary<string, Asset>();
        public static string Root = "Assets";
        
        internal Assets(Config config)
        {
            
        }
        

        // Generic Load Resource
        public static T Load<T>(string path) where T : Asset
        {
            // Resolve path
            path = Path.Combine(FileSystem.BasePath, Path.Combine(Root, path));

            // Fetch from cache
            if (Cache.TryGetValue(path, out var cached))
            {
                // Return new instance
                return CreateInstance<T>(cached);
            }

            // Create resource
            Asset resource = CreateResource<T>(path);
            Cache[path] = resource;

            // Return new instance
            return CreateInstance<T>(resource);
        }

        // Generic Create Resource
        private static T CreateResource<T>(string path) where T : Asset
        {
            if (typeof(T) == typeof(Texture))
            {
                return CreateTextureResource(path) as T;
            }
            else
            {
                throw new Exception($"Unsupported asset type {typeof(T)}");
            }
        }

        // Generic Create Instance
        private static T CreateInstance<T>(Asset resource) where T : Asset
        {
            if (typeof(T) == typeof(Texture))
            {
                return new Texture((Texture)resource) as T;
            }
            else
            {
                throw new Exception($"Unsupported asset type {typeof(T)}");
            }
        }
        
        // Dispose
        internal override void Dispose()
        {
            Console.WriteLine("Resources Disposed");

            foreach (var resource in Cache)
            {
                resource.Value.Dispose();
            }

            Cache.Clear();
        }
    }
    
    // Texture Resources
    public unsafe partial class Assets
    {
        private static Texture CreateTextureResource(string path)
        {
            // Load surface
            var surface = SDL_image.Load(path);
            if (surface == null) throw new Exception($"Could not load surface '{path}': {SDL.GetError()}");

            // Convert surface
            var converted = SDL.ConvertSurface(surface, SDL.PixelFormat.RGBA32);
            if (converted == null) throw new Exception($"Failed to convert surface '{path}' to RGBA32: {SDL.GetError()}");
            
            // Create Texture from surface
            int height = converted->height;
            int width = converted->width;
            int pitch = converted->pitch;
            int size = height * pitch;
            byte[] pixels = new byte[size];
            byte* src = (byte*)converted->pixels.ToPointer();
            fixed (byte* dst = pixels) Buffer.MemoryCopy(src, dst, size, size);
            Texture instance = new Texture(width, height)
            {
                Pixels = pixels
            };
            
            // Destroy surfaces
            SDL.DestroySurface(converted);
            SDL.DestroySurface(surface);
            
            // Return
            return instance;
        }
    }
}