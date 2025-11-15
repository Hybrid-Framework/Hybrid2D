using System.Collections.Generic;
using System.IO;
using System;

namespace Hybrid
{
    // Resources
    public partial class Resources : Module
    {
        private static readonly Dictionary<string, Resource> Cache = new();
        public static string Root = "Assets";

        internal Resources(Config config)
        {

        }
        
        internal override void OnDispose()
        {
            Console.WriteLine("Resources Disposed");

            foreach (var resource in Cache)
            {
                Console.WriteLine($"Resource '{resource.Value.Name}' Disposed");
                resource.Value.OnDispose();
            }

            Cache.Clear();
        }
    }
    
    // Resources API
    public partial class Resources
    {
        // Generic Load Resource
        public static T Load<T>(string path) where T : Resource
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
            Resource resource = CreateResource<T>(path);
            Cache[path] = resource;

            // Return new instance
            return CreateInstance<T>(resource);
        }

        // Generic Create Resource
        private static T CreateResource<T>(string path) where T : Resource
        {
            // Create Texture Resource
            if (typeof(T) == typeof(Texture))
            {
                var instance = CreateTextureResource(path);
                instance.Name = path;
                
                return instance as T;
            }
            else
            {
                throw new Exception($"Unsupported asset type {typeof(T)}");
            }
        }

        // Generic Create Instance
        private static T CreateInstance<T>(Resource resource) where T : Resource
        {
            // Create Texture Instance
            if (typeof(T) == typeof(Texture))
            {
                return new Texture((Texture)resource) as T;
            }
            else
            {
                throw new Exception($"Unsupported asset type {typeof(T)}");
            }
        }
    }
    
    // Texture Resources
    public unsafe partial class Resources
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