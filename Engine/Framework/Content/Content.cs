using System;

namespace Hybrid
{
    public static unsafe class Content
    {
        private static Dictionary<string, IContentResource> Cache = new();
        
        public static string Root = "Content";
        
        
        // Load Content
        public static T Load<T>(string path) where T : IContentResource
        {
            // Resolve Path
            path = Path.Combine(FileSystem.BasePath, Path.Combine(Root, path));
            
            // Fetch Content
            if (Cache.TryGetValue(path, out IContentResource existing))
            {
                return (T)existing;
            }
            
            // Load Content Methods
            IContentResource content = typeof(T) switch
            {
                var t when t == typeof(Texture) => LoadTexture(path),
                _ => throw new Exception($"Unsupported asset type {typeof(T)}")
            };
            
            // Cache Content
            Cache[path] = content;
            
            // Return Content As Type
            return (T)content;
        }
        

        // Load Texture
        public static Texture LoadTexture(string path)
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

            // Create Texture
            SDL.Texture* texture = SDL.CreateTexture(GraphicsDevice.Renderer, SDL.PixelFormat.RGBA32, SDL.TextureAccess.Static, width, height);
            if(texture == null) throw new Exception($"Failed to create texture: {SDL.GetError()}");

            // Create Instance
            Texture instance = new Texture(width, height, TextureAccess.Static, TextureScaleMode.Pixel)
            {
                Handle = texture,
                Pixels = pixels,
            };
        
            // Clean up
            SDL.DestroySurface(converted);
            SDL.DestroySurface(surface);
            
            // Apply
            instance.Apply();
            
            // Return
            return instance;
        }
    }
}
