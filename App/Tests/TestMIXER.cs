using System.Text;
using Hybrid;
using SDL;

namespace App
{
    public unsafe class TestMIXER : Behaviour
    {
        private SDL_Window* window;
        private SDL_Renderer* renderer;

        public MIX_Mixer* mixer;
        public MIX_Audio* audio;
        public MIX_Audio* mp3;
        public MIX_Audio* wav;
        public MIX_Audio* ogg;
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
                test++; if (test > 2) test = 0;

                if (test == 0)
                {
                    SDL3_mixer.MIX_PlayAudio(mixer, mp3);
                }
                else if (test == 1)
                {
                    SDL3_mixer.MIX_PlayAudio(mixer, wav);
                }
                else if (test == 2)
                {
                    SDL3_mixer.MIX_PlayAudio(mixer, ogg);
                }
            }
        }
        
        public override void Render()
        {
            SDL3.SDL_SetRenderDrawColor(renderer, 255, 128, 128, 255);
            SDL3.SDL_RenderClear(renderer);
            
            // Draw Code Here

            SDL3.SDL_RenderPresent(renderer);
        }
    }
}