using System;

namespace Hybrid
{
    // Content API
    public partial class Content : Module
    {
        private static readonly Dictionary<string, Resource> Resources = new();
        public static string Root = "Content";
        
        internal Content(Config config)
        {
            
        }
        
        
        internal override void OnDispose()
        {
            Console.WriteLine("Resources Disposed");

            foreach (var resource in Resources)
            {
                resource.Value.OnDispose();
            }

            Resources.Clear();
        }
    }
    
    // Content API
    public partial class Content
    {
        // Generic Load Resource
        public static T Load<T>(string path) where T : Resource
        {
            // Resolve path
            path = Path.Combine(FileSystem.BasePath, Path.Combine(Root, path));

            // Fetch resource from cache
            if (Resources.TryGetValue(path, out var cached))
            {
                // If not disposed
                if (!cached.Disposed)
                {
                    // Return cached
                    return cached as T;
                }
            }

            // Create new resource
            Resource resource = CreateResource<T>(path);
            
            // Cache new resource
            Resources[path] = resource;

            // Return new resource
            return resource as T;
        }
        
        // Generic Unload Resource
        public static void Unload(string path)
        {
            // Find Resource
            if (Resources.ContainsKey(path))
            {
                // Unload Resource
                var resource = Resources[path];
                resource.Dispose();
                
                // Remove
                Resources.Remove(path);
            }
        }

        // Generic Create Resource
        private static T CreateResource<T>(string path) where T : Resource
        {
            // Create Texture Resource
            if (typeof(T) == typeof(Texture))
            {
                var instance = CreateTextureResource(path);
                
                if (instance != null)
                    instance.Name = path;
                
                return instance as T;
            }
            
            // Create Audio Resource
            if (typeof(T) == typeof(Sound))
            {
                var instance = CreateAudioResource(path);
                
                if (instance != null)
                    instance.Name = path;
                
                return instance as T;
            }
            
            // Create Font Resource
            if (typeof(T) == typeof(Font))
            {
                var instance = CreateFontResource(path);
                
                if (instance != null)
                    instance.Name = path;
                
                return instance as T;
            }
            
            // Unknown Resource
            throw new Exception($"Unsupported resource type {typeof(T)}");
        }
    }
    
    // Texture Resources
    public unsafe partial class Content
    {
        private static Texture CreateTextureResource(string path)
        {
            // Load surface From File
            var surface = SDL_image.Load(path);
            
            // Invalid Surface
            if (surface == null)
                throw new Exception($"Could not load texture '{path}': {SDL.GetError()}");

            // Convert surface
            var converted = SDL.ConvertSurface(surface, SDL.PixelFormat.RGBA32);
            
            // Invalid Surface
            if (converted == null)
                throw new Exception($"Failed to convert texture '{path}' to RGBA32: {SDL.GetError()}");
            
            // Create Texture
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
    
    // Audio Resources
    public unsafe partial class Content
    {
        private static Sound CreateAudioResource(string path)
        {
            // Load Audio From File
            var sound = SDL_mixer.LoadAudio(Engine.AudioDevice.Handle, path, false);
            
            // Invalid Audio
            if (sound == null)
                throw new Exception($"Could not load audio '{path}': {SDL.GetError()}");

            // Create Audio
            Sound instance = new Sound(sound);
            
            // Return
            return instance;
        }
    }
    
    // Font Resources
    public unsafe partial class Content
    {
        private static Font CreateFontResource(string path)
        {
            // Load Font From File
            var font = SDL_ttf.OpenFont(path, 32);
            
            // Invalid Font
            if (font == null)
                throw new Exception($"Could not load font '{path}': {SDL.GetError()}");

            // Create Font
            Font instance = new Font(font);
            
            // Return
            return instance;
        }
    }
}