using System;

namespace Hybrid
{
    // Internal API
    public partial class Resources : Module<Resources>
    {
        private Resources() { }

        // Initialize
        internal override void OnInitialize()
        {
            base.OnInitialize();
        }

        // Dispose
        internal override void OnDispose()
        {
            base.OnDispose();
            
            // For Each Resource In Cache
            foreach (var resource in Cache)
            {
                // Unload
                Unload(resource.Key);
            }
            
            // Empty
            Cache.Clear();
        }
    }
    
    // Resources API
    public partial class Resources
    {
        private static readonly Dictionary<string, Resource> Cache = new Dictionary<string, Resource>();
        
        
        public static T Load<T>(string path) where T : Resource
        {
            // Fetch Resource From Cache
            if (Cache.TryGetValue(path, out var cached))
            {
                // If Not Destroyed
                if (cached != null)
                {
                    // Return Cache
                    return cached as T;
                }
            }

            // Create Resource
            Resource instance = Create<T>(path);
            Cache[path] = instance;

            // Return
            return (T)instance;
        }
        
        public static void Unload(string path)
        {
            // Fetch Resource From Cache
            if (Cache.TryGetValue(path, out var cached))
            {
                // Destroy & Remove
                Object.Destroy(cached);
                Cache.Remove(path);
            }
        }

        private static T Create<T>(string path) where T : Resource
        {
            Resource instance;
            
            // Create Texture Resource
            if (typeof(T) == typeof(Texture))
            {
                instance = CreateTexture(path);
            }
            
            // Create Audio Resource
            else if (typeof(T) == typeof(Sound))
            {
                instance = CreateSound(path);
            }
            
            // Create Font Resource
            else if (typeof(T) == typeof(Font))
            {
                instance = CreateFont(path);
            }

            // Fallback
            else
            {
                throw new Exception($"Unsupported resource type {typeof(T)}");
            }
            
            instance.Name = path;
            return instance as T;
        }
    }
    
    // Texture Resources
    public unsafe partial class Resources
    {
        private static Texture CreateTexture(string path)
        {
            // Load surface
            var surface = SDL_image.Load(path);
            if (surface == null) throw new Exception($"Failed to load texture '{path}': {SDL.GetError()}");

            // Convert surface to RGBA32 format
            var converted = SDL.ConvertSurface(surface, SDL.PixelFormat.RGBA32);
            if (converted == null) throw new Exception($"Failed to convert texture '{path}' to RGBA32: {SDL.GetError()}");

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
            return new Texture(pixels, width, height);
        }
    }
    
    // Sound Resources
    public unsafe partial class Resources
    {
        private static Sound CreateSound(string path)
        {
            // Load Audio
            var sound = SDL_mixer.LoadAudio(Audio.Handle, path, false);
            if (sound == null) throw new Exception($"Failed to load audio '{path}': {SDL.GetError()}");

            // Create Audio
            return new Sound(sound);
        }
    }
    
    // Font Resources
    public unsafe partial class Resources
    {
        private static Font CreateFont(string path)
        {
            // Load Font From File
            var font = SDL_ttf.OpenFont(path, 32);
            if (font == null) throw new Exception($"Failed to load font '{path}': {SDL.GetError()}");

            // Create Font
            return new Font(font);
        }
    }
}