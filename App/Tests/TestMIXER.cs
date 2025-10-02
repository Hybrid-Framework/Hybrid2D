using Hybrid;
using SDL3;

namespace App
{
    public class TestMIXER : Behaviour
    {
        private IntPtr window;
        private IntPtr renderer;
        
        public IntPtr mixer;
        public IntPtr mp3;
        public IntPtr wav;
        public IntPtr ogg;
        private int test = -1;
        
        public override void Init()
        {
            if (!SDL.SDL_Init(SDL.SDL_InitFlags.SDL_INIT_VIDEO | SDL.SDL_InitFlags.SDL_INIT_AUDIO))
            {
                throw new Exception($"SDL failed to initialize: {SDL.SDL_GetError()}");
            }
            
            if (!MIXER.MIX_Init())
            {
                throw new Exception($"SDL failed to initialize mixer: {SDL.SDL_GetError()}");
            }

            window = SDL.SDL_CreateWindow("SDL3", 800, 600, SDL.SDL_WindowFlags.SDL_WINDOW_HIGH_PIXEL_DENSITY | SDL.SDL_WindowFlags.SDL_WINDOW_RESIZABLE);
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
                test++; if (test > 2) test = 0;

                if (test == 0)
                {
                    MIXER.MIX_PlayAudio(mixer, mp3);
                }
                else if (test == 1)
                {
                    MIXER.MIX_PlayAudio(mixer, wav);
                }
                else if (test == 2)
                {
                    MIXER.MIX_PlayAudio(mixer, ogg);
                }
            }
        }
        
        public override void Render()
        {
            SDL.SDL_SetRenderDrawColor(renderer, 255, 128, 128, 255);
            SDL.SDL_RenderClear(renderer);

            SDL.SDL_RenderPresent(renderer);
        }
    }
}