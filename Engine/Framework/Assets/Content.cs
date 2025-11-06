using System;

namespace Hybrid
{
    public static unsafe class Content
    {
        public static string Root = "Content";
        
        
        // Generic Load Method
        public static T Load<T>(string path) where T : Object
        {
            // Resolve Path
            path = Path.Combine(FileSystem.BasePath, Path.Combine(Root, path));
            
            // Load Content Type
            Object content = typeof(T) switch
            {
                var t when t == typeof(Texture) => LoadTexture(path),
                _ => throw new Exception($"Unsupported asset type {typeof(T)}")
            };
            
            // Return
            return content as T;
        }
        
        // Texture
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
            SDL.Texture* texture = SDL.CreateTexture(Engine.GraphicsDevice.Renderer, SDL.PixelFormat.RGBA32, SDL.TextureAccess.Static, width, height);
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
