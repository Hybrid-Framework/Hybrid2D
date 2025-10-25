using System;

namespace Hybrid
{
    public static unsafe class Content
    {
        private static readonly Dictionary<string, IContentResource> cache = new();
        

        public static T Load<T>(string path) where T : IContentResource
        {
            // Find Asset In Cache
            if (cache.TryGetValue(path, out IContentResource existing))
            {
                return (T)existing;
            }
            
            // Load Asset
            IContentResource content;
            
            if (typeof(T) == typeof(Texture))
            {
                content = LoadTexture(path);
            }
            else if (typeof(T) == typeof(AudioClip))
            {
                content = LoadAudio(path);
            }
            else if (typeof(T) == typeof(Font))
            {
                content = LoadFont(path);
            }
            else
            {
                throw new Exception($"Unsupported asset type {typeof(T)}");
            }

            cache[path] = content;
            return (T)content;
        }

        public static Texture LoadTexture(string path)
        {
            SDL.Texture* resource = SDL_image.LoadTexture(Renderer.Handle, path);

            if (resource == null)
            {
                throw new Exception($"Could not find asset {path}");
            }
            else
            {
                SDL.SetTextureScaleMode(resource, SDL.ScaleMode.Pixel);
                
                Texture texture = new Texture()
                {
                    Handle = resource
                };

                return texture;
            }
        }

        public static AudioClip LoadAudio(string path)
        {
            SDL.Audio* resource = SDL_mixer.LoadAudio(Audio.AudioListener.Handle, path, false);

            if (resource == null)
            {
                throw new Exception($"Could not find asset {path}");
            }
            else
            {
                AudioClip audioClip = new AudioClip()
                {
                    Handle = resource
                };

                return audioClip;
            }
        }

        public static Font LoadFont(string path)
        {
            SDL.Font* resource = SDL_ttf.OpenFont(path, 32);

            if (resource == null)
            {
                throw new Exception($"Could not find asset {path}");
            }
            else
            {
                Font font = new Font()
                {
                    Handle = resource
                };

                return font;
            }
        }
    }
}