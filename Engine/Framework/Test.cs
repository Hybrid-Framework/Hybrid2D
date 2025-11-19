using System;

namespace Hybrid
{
    public unsafe class Test
    {
        private string information = "Press any key to start";
        
        private SDL.Renderer* Renderer;
        private SDL.Window* Window;
        private SDL.Mixer* Mixer;

        private SDL.Texture* image;
        private SDL.Texture* png;
        private SDL.Texture* jpg;
        private SDL.Texture* bmp;
        
        private SDL.Audio* mp3;
        private SDL.Audio* wav;
        private SDL.Audio* ogg;
        
        private SDL.Font* font;
        private int test = -1;
        
        
        public void OnInitialize()
        {
            SDL.WindowFlags flags = SDL.WindowFlags.HighPixelDensity;
            if (Platform.Current.PlatformDevice == PlatformDevice.Mobile)
                flags |= SDL.WindowFlags.Fullscreen | SDL.WindowFlags.Resizable;
            
            Window = SDL.CreateWindow("test", 600, 600, flags);
            Renderer = SDL.CreateRenderer(Window, null);

            var spec = new SDL.AudioSpec()
            {
                format = SDL.AudioFormat.S16,
                channels = 2,
                freq = 44100,
            };

            string basePath = SDL.GetBasePath();
            Console.WriteLine("BasePath: " + basePath);
            
            Mixer = SDL_mixer.CreateMixerDevice(SDL.DefaultPlaybackDevice, spec);
            mp3 = SDL_mixer.LoadAudio(Mixer, Path.Combine(basePath, "Sounds/Sound.mp3"), false);
            wav = SDL_mixer.LoadAudio(Mixer, Path.Combine(basePath, "Sounds/Sound.wav"), false);
            ogg = SDL_mixer.LoadAudio(Mixer, Path.Combine(basePath, "Sounds/Sound.ogg"), false);
            font = SDL_ttf.OpenFont(Path.Combine(basePath, "Fonts/Font.ttf"), 32);
            png = LoadTexture(Path.Combine(basePath, "Images/Image.png"));
            jpg = LoadTexture(Path.Combine(basePath, "Images/Image.jpg"));
            bmp = LoadTexture(Path.Combine(basePath, "Images/Image.bmp"));

            SDL.SetTextureScaleMode(png, SDL.ScaleMode.Pixel);
            SDL.SetTextureScaleMode(jpg, SDL.ScaleMode.Pixel);
            SDL.SetTextureScaleMode(bmp, SDL.ScaleMode.Pixel);
        }

        internal void OnEvent(SDL.Event e)
        {
            switch (e.type)
            {
                case SDL.EventType.KeyboardButtonDown:
                case SDL.EventType.TouchFingerDown:
                    Perform();
                    break;
            }
        }

        public void OnUpdate()
        {
            
        }

        public void OnRender()
        {
            SDL.SetRenderDrawColor(Renderer, 255, 128, 128, 255);
            SDL.RenderClear(Renderer);
            
            SDL.RenderTexture(Renderer, image, null, null);

            var surface = SDL_ttf.RenderTextSolid(font, information, new SDL.Color() { r = 255, g = 255, b = 255, a = 255});
            
            if (surface != null)
            {
                var texture = SDL.CreateTextureFromSurface(Renderer, surface);

                if (texture != null)
                {
                    SDL.FRect rect = new SDL.FRect()
                    {
                        x = 10,
                        y = 10,
                        w = SDL.GetTextureWidth(texture),
                        h = SDL.GetTextureHeight(texture)
                    };

                    SDL.RenderTexture(Renderer, texture, null, rect);
                }
                
                SDL.DestroySurface(surface);
                SDL.DestroyTexture(texture);
            }
            
            SDL.RenderPresent(Renderer);
        }
        
        
        private SDL.Texture* LoadTexture(string path)
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
            var texture = SDL.CreateTextureFromSurface(Renderer, converted);
            
            // Invalid Texture
            if (texture == null)
                throw new Exception($"Failed to create texture '{path}': {SDL.GetError()}");
            
            // Destroy surfaces
            SDL.DestroySurface(converted);
            SDL.DestroySurface(surface);

            return texture;
        }

        private void Perform()
        {
            test += 1;
            if (test >= 6) test = 0;

            image = null;

            if (test == 0)
            {
                information = "png";
                image = png;
            }
            if (test == 1)
            {
                information = "jpg";
                image = jpg;
            }
            if (test == 2)
            {
                information = "bmp";
                image = bmp;
            }
            if (test == 3)
            {
                information = "mp3";
                SDL_mixer.PlayAudio(Mixer, mp3);
            }
            if (test == 4)
            {
                information = "wav";
                SDL_mixer.PlayAudio(Mixer, wav);
            }
            if (test == 5)
            {
                information = "ogg";
                SDL_mixer.PlayAudio(Mixer, ogg);
            }
        }
    }
}