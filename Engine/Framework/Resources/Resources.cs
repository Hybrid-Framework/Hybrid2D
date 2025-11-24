using System;

namespace Hybrid
{
    // Resources
    public partial class Resources : Module
    {
        private static readonly Dictionary<string, Resource> Cache = new Dictionary<string, Resource>();
        
        
        internal Resources()
        {
            // Config
        }

        internal override void OnDestroy()
        {
            Console.WriteLine("Resources Disposed");

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
            Resource resource = typeof(T) switch
            {
                // Texture
                _ when typeof(T) == typeof(Texture) => CreateTexture(path),

                // Sounds
                _ when typeof(T) == typeof(Sound) => CreateSound(path),

                // Font
                _ when typeof(T) == typeof(Font) => CreateFont(path),

                // Unsupported
                _ => throw new Exception($"Unsupported resource type {typeof(T)}")
            };

            // Information
            resource.Path = path;
            
            // Return
            return (T)resource;
        }
    }
    
    // Texture Resources
    public partial class Resources
    {
        private static Texture CreateTexture(string path)
        {
            return new Texture();
        }
    }
    
    // Sound Resources
    public partial class Resources
    {
        private static Sound CreateSound(string path)
        {
            return new Sound();
        }
    }
    
    // Font Resources
    public partial class Resources
    {
        private static Font CreateFont(string path)
        {
            return new Font();
        }
    }
}