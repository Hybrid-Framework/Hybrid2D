using Hybrid;
using SDL3;

namespace App
{
    public class TestALL : Behaviour
    {
        private IntPtr window;
        private IntPtr renderer;
        
        private string teststring = "Hello World!";
        public IntPtr fontTexture;
        public IntPtr font;
        
        public IntPtr image;
        public IntPtr png;
        public IntPtr bmp;
        public IntPtr jpg;
        
        public IntPtr mixer;
        public IntPtr mp3;
        public IntPtr wav;
        public IntPtr ogg;
        
        private int test = -1;
        
        public override void Init()
        {
            if (!SDL.SDL_Init(SDL.SDL_InitFlags.SDL_INIT_VIDEO | SDL.SDL_InitFlags.SDL_INIT_VIDEO))
            {
                throw new Exception($"SDL failed to initialize: {SDL.SDL_GetError()}");
            }
            
            if (!MIXER.MIX_Init())
            {
                throw new Exception($"SDL failed to initialize mixer: {SDL.SDL_GetError()}");
            }
            
            if (!TTF.TTF_Init())
            {
                throw new Exception($"SDL failed to initialize ttf: {SDL.SDL_GetError()}");
            }

            window = SDL.SDL_CreateWindow("SDL3", 800, 600, SDL.SDL_WindowFlags.SDL_WINDOW_HIGH_PIXEL_DENSITY);
            if (window == IntPtr.Zero)
            {
                throw new Exception($"SDL failed create window: {SDL.SDL_GetError()}");
            }

            renderer = SDL.SDL_CreateRenderer(window, null);
            if (renderer == IntPtr.Zero)
            {
                throw new Exception($"SDL failed create renderer: {SDL.SDL_GetError()}");
            }
            
            SDL.SDL_AudioSpec audioSpec = new SDL.SDL_AudioSpec()
            {
                format = SDL.SDL_AudioFormat.SDL_AUDIO_S32,
                freq = 44100,
                channels = 2
            };

            mixer = MIXER.MIX_CreateMixerDevice(MIXER.SDL_AUDIO_DEVICE_DEFAULT_PLAYBACK, ref audioSpec);
            if(mixer == IntPtr.Zero) throw new Exception($"SDL failed create mixer: {SDL.SDL_GetError()}");
            
            mp3 = MIXER.MIX_LoadAudio(mixer, FileSystem.LoadAsset("Sound.mp3"), false);
            if (mp3 == IntPtr.Zero) throw new Exception($"SDL failed load mp3: {SDL.SDL_GetError()}");
            
            wav = MIXER.MIX_LoadAudio(mixer, FileSystem.LoadAsset("Sound.wav"), false);
            if (wav == IntPtr.Zero) throw new Exception($"SDL failed load wav: {SDL.SDL_GetError()}");
            
            ogg = MIXER.MIX_LoadAudio(mixer, FileSystem.LoadAsset("Sound.ogg"), false);
            if (ogg == IntPtr.Zero) throw new Exception($"SDL failed load ogg: {SDL.SDL_GetError()}");
            
            png = IMAGE.IMG_LoadTexture(renderer, FileSystem.LoadAsset("Image.png"));
            if (png == IntPtr.Zero) throw new Exception($"SDL failed load png: {SDL.SDL_GetError()}");
            SDL.SDL_SetTextureScaleMode(png, SDL.SDL_ScaleMode.SDL_SCALEMODE_NEAREST);
            
            jpg = IMAGE.IMG_LoadTexture(renderer, FileSystem.LoadAsset("Image.jpg"));
            if (jpg == IntPtr.Zero) throw new Exception($"SDL failed load jpg: {SDL.SDL_GetError()}");
            SDL.SDL_SetTextureScaleMode(jpg, SDL.SDL_ScaleMode.SDL_SCALEMODE_NEAREST);
            
            bmp = IMAGE.IMG_LoadTexture(renderer, FileSystem.LoadAsset("Image.bmp"));
            if (bmp == IntPtr.Zero) throw new Exception($"SDL failed load bmp: {SDL.SDL_GetError()}");
            SDL.SDL_SetTextureScaleMode(bmp, SDL.SDL_ScaleMode.SDL_SCALEMODE_NEAREST);
            
            font = TTF.TTF_OpenFont(FileSystem.LoadAsset("Font.ttf"), 128);
            if (font == IntPtr.Zero) throw new Exception($"SDL failed to load Font.ttf: {SDL.SDL_GetError()}");
        }
        
        public override void Update(SDL.SDL_Event @event)
        {
            var e = (SDL.SDL_EventType)@event.type;
            Console.WriteLine($"SDL Event: {e}");

            if (e == SDL.SDL_EventType.SDL_EVENT_QUIT)
            {
                Platform.Current.IsRunning = false;
                return;
            }
            
            if (e == SDL.SDL_EventType.SDL_EVENT_MOUSE_BUTTON_DOWN)
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
                    MIXER.MIX_PlayAudio(mixer, mp3);
                }
                else if (test == 4)
                {
                    teststring = "WAV";
                    MIXER.MIX_PlayAudio(mixer, wav);
                }
                else if (test == 5)
                {
                    teststring = "OGG";
                    MIXER.MIX_PlayAudio(mixer, ogg);
                }
            }
        }
        
        public override void Render()
        {
            SDL.SDL_SetRenderDrawColor(renderer, 255, 128, 128, 255);
            SDL.SDL_RenderClear(renderer);
            
            var src = new SDL.SDL_FRect() { x = 0, y = 0, w = 800, h = 600};
            var dst = new SDL.SDL_FRect() { x = 0, y = 0, w = 800, h = 600};
            SDL.SDL_RenderTexture(renderer, image, ref src, ref dst);
            
            var fontSurface = TTF.TTF_RenderText_Solid(font, teststring, 0, new SDL.SDL_Color { r = 255, g = 255, b = 255, a = 255 });
            
            if (fontSurface != IntPtr.Zero)
            {
                fontTexture = SDL.SDL_CreateTextureFromSurface(renderer, fontSurface);
                SDL.SDL_DestroySurface(fontSurface);

                SDL.SDL_GetTextureSize(fontTexture, out var w, out var h);
                
                SDL.SDL_FRect srcRect = new SDL.SDL_FRect { x = 0, y = 0, w = w, h = h };
                SDL.SDL_FRect dstRect = new SDL.SDL_FRect { x = 20, y = 20, w = w, h = h };
                SDL.SDL_RenderTexture(renderer, fontTexture, ref srcRect, ref dstRect);
            }

            SDL.SDL_RenderPresent(renderer);
            SDL.SDL_DestroyTexture(fontTexture);
        }
    }
}