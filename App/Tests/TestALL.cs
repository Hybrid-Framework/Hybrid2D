using System.Text;
using Hybrid;
using SDL;

namespace App
{
    public unsafe class TestALL : Behaviour
    {
        private SDL_Window* window;
        private SDL_Renderer* renderer;
        
        private string teststring = "Hello World!";
        public SDL_Texture* fontTexture;
        public TTF_Font* font;
        
        public MIX_Mixer* mixer;
        public MIX_Audio* mp3;
        public MIX_Audio* wav;
        public MIX_Audio* ogg;
        
        public SDL_Texture* image;
        public SDL_Texture* png;
        public SDL_Texture* bmp;
        public SDL_Texture* jpg;
        private int test = -1;
        
        public override void Init()
        {
            if (!SDL3.SDL_Init(SDL_InitFlags.SDL_INIT_VIDEO | SDL_InitFlags.SDL_INIT_VIDEO))
            {
                throw new Exception($"SDL failed to initialize: {SDL3.SDL_GetError()}");
            }
            
            if (!SDL3_mixer.MIX_Init())
            {
                throw new Exception($"SDL failed to initialize mixer: {SDL3.SDL_GetError()}");
            }
            
            if (!SDL3_ttf.TTF_Init())
            {
                throw new Exception($"SDL failed to initialize ttf: {SDL3.SDL_GetError()}");
            }

            window = SDL3.SDL_CreateWindow("SDL3", 800, 600, SDL_WindowFlags.SDL_WINDOW_HIGH_PIXEL_DENSITY);
            if (window == null)
            {
                throw new Exception($"SDL failed create window: {SDL3.SDL_GetError()}");
            }

            renderer = SDL3.SDL_CreateRenderer(window, (Utf8String)null);
            if (renderer == null)
            {
                throw new Exception($"SDL failed create renderer: {SDL3.SDL_GetError()}");
            }
            
            png = SDL3_image.IMG_LoadTexture(renderer, FileSystem.LoadAsset("Image.png"));
            if (png == null) throw new Exception($"SDL failed load png: {SDL3.SDL_GetError()}");
            SDL3.SDL_SetTextureScaleMode(png, SDL_ScaleMode.SDL_SCALEMODE_PIXELART);
            
            jpg = SDL3_image.IMG_LoadTexture(renderer, FileSystem.LoadAsset("Image.jpg"));
            if (jpg == null) throw new Exception($"SDL failed load jpg: {SDL3.SDL_GetError()}");
            SDL3.SDL_SetTextureScaleMode(jpg, SDL_ScaleMode.SDL_SCALEMODE_PIXELART);
            
            bmp = SDL3_image.IMG_LoadTexture(renderer, FileSystem.LoadAsset("Image.bmp"));
            if (bmp == null) throw new Exception($"SDL failed load bmp: {SDL3.SDL_GetError()}");
            SDL3.SDL_SetTextureScaleMode(bmp, SDL_ScaleMode.SDL_SCALEMODE_PIXELART);
            
            SDL_AudioSpec audioSpec = new SDL_AudioSpec()
            {
                format = SDL3_mixer.MIX_DEFAULT_FORMAT,
                freq = 44100,
                channels = 2
            };

            mixer = SDL3_mixer.MIX_CreateMixerDevice(SDL3.SDL_AUDIO_DEVICE_DEFAULT_PLAYBACK, &audioSpec);
            if(mixer == null) throw new Exception($"SDL failed create mixer: {SDL3.SDL_GetError()}");
            
            fixed (byte* ptr = Encoding.UTF8.GetBytes(FileSystem.LoadAsset("Sound.mp3") + '\0'))
            {
                mp3 = SDL3_mixer.MIX_LoadAudio(mixer, ptr, false);
                if (mp3 == null) throw new Exception($"SDL failed load mp3: {SDL3.SDL_GetError()}");
            }
            
            fixed (byte* ptr = Encoding.UTF8.GetBytes(FileSystem.LoadAsset("Sound.wav") + '\0'))
            {
                wav = SDL3_mixer.MIX_LoadAudio(mixer, ptr, false);
                if (wav == null) throw new Exception($"SDL failed load wav: {SDL3.SDL_GetError()}");
            }
            
            fixed (byte* ptr = Encoding.UTF8.GetBytes(FileSystem.LoadAsset("Sound.ogg") + '\0'))
            {
                ogg = SDL3_mixer.MIX_LoadAudio(mixer, ptr, false);
                if (ogg == null) throw new Exception($"SDL failed load ogg: {SDL3.SDL_GetError()}");
            }
            
            font = SDL3_ttf.TTF_OpenFont(FileSystem.LoadAsset("Font.ttf"), 128);
            if (font == null) throw new Exception($"SDL failed to load Font.ttf: {SDL3.SDL_GetError()}");
        }
        
        public override void Update(SDL_Event @event)
        {
            var e = (SDL_EventType)@event.type;
            Console.WriteLine($"SDL Event: {e}");

            if (e == SDL_EventType.SDL_EVENT_QUIT)
            {
                Platform.Current.IsRunning = false;
                return;
            }
            
            if (e == SDL_EventType.SDL_EVENT_MOUSE_BUTTON_DOWN)
            {
                test++; if (test > 5) test = 0;

                if (test == 0)
                {
                    teststring = "PNG";
                    image = png;
                }
                else if (test == 1)
                {
                    teststring = "JPG";
                    image = jpg;
                }
                else if (test == 2)
                {
                    teststring = "BMP";
                    image = bmp;
                }
                else if (test == 3)
                {
                    teststring = "MP3";
                    SDL3_mixer.MIX_PlayAudio(mixer, mp3);
                }
                else if (test == 4)
                {
                    teststring = "WAV";
                    SDL3_mixer.MIX_PlayAudio(mixer, wav);
                }
                else if (test == 5)
                {
                    teststring = "OGG";
                    SDL3_mixer.MIX_PlayAudio(mixer, ogg);
                }
            }
        }
        
        public override void Render()
        {
            SDL3.SDL_SetRenderDrawColor(renderer, 255, 128, 128, 255);
            SDL3.SDL_RenderClear(renderer);
            
            var src = new SDL_FRect() { x = 0, y = 0, w = 800, h = 600};
            var dst = new SDL_FRect() { x = 0, y = 0, w = 800, h = 600};
            SDL3.SDL_RenderTexture(renderer, image, &src, &dst);
            
            var fontSurface = SDL3_ttf.TTF_RenderText_Solid(font, teststring, 0, new SDL_Color { r = 255, g = 255, b = 255, a = 255 });
            
            if (fontSurface != null)
            {
                fontTexture = SDL3.SDL_CreateTextureFromSurface(renderer, fontSurface);
                SDL3.SDL_SetTextureScaleMode(fontTexture, SDL_ScaleMode.SDL_SCALEMODE_PIXELART);
                
                SDL3.SDL_DestroySurface(fontSurface);

                float w = 0, h = 0;
                SDL3.SDL_GetTextureSize(fontTexture, &w, &h);
                
                SDL_FRect srcRect = new SDL_FRect { x = 0, y = 0, w = w, h = h };
                SDL_FRect dstRect = new SDL_FRect { x = 20, y = 20, w = w, h = h };
                SDL3.SDL_RenderTexture(renderer, fontTexture, &srcRect, &dstRect);
            }

            SDL3.SDL_RenderPresent(renderer);
            SDL3.SDL_DestroyTexture(fontTexture);
        }
    }
}