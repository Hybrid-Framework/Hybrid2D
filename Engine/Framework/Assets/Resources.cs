using System.Collections.Generic;
using System.IO;
using System;

namespace Hybrid
{
    public unsafe class Resources : Module
    {
        private static Dictionary<string, Resource> Cache = new Dictionary<string, Resource>();
        public static string Root = "Content";
        
        
        internal Resources(Config config)
        {
            
        }
        

        // Generic Load Method
        public static T Load<T>(string path) where T : Resource
        {
            // Resolve Path
            string fullPath = Path.Combine(FileSystem.BasePath, Path.Combine(Root, path));
            
            // Fetch From Cache
            if (Cache.TryGetValue(fullPath, out var cached))
            {
                return (T)cached;
            }
            
            // Load Resource
            Resource resource = typeof(T) switch
            {
                var t when t == typeof(TextureResource) => LoadTexture(fullPath),
                _ => throw new Exception($"Unsupported asset type {typeof(T)}")
            };
            
            // Cache Resource
            if (resource != null)
            {
                Cache[fullPath] = resource;
                return resource as T;
            }
            
            // Failed
            return null;
        }
        
        // Texture Resource
        private static TextureResource LoadTexture(string path)
        {
            // Load surface
            var surface = SDL_image.Load(path);
            if (surface == null) throw new Exception($"Could not load surface '{path}': {SDL.GetError()}");

            // Convert format
            var converted = SDL.ConvertSurface(surface, SDL.PixelFormat.RGBA32);
            if (converted == null) throw new Exception($"Failed to convert surface '{path}' to RGBA32: {SDL.GetError()}");
            
            // Fetch information
            int height = converted->height;
            int width = converted->width;
            int pitch = converted->pitch;
            int size = height * pitch;
            byte[] pixels = new byte[size];
            byte* src = (byte*)converted->pixels.ToPointer();
            fixed (byte* dst = pixels) Buffer.MemoryCopy(src, dst, size, size);

            // Create Resource
            TextureResource instance = new TextureResource(width, height)
            {
                Path = path,
                Pixels = pixels
            };
            
            // Return
            SDL.DestroySurface(converted);
            SDL.DestroySurface(surface);
            return instance;
        }

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
}