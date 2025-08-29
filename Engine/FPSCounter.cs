using static SDL2.SDL;

namespace Engine
{
    public class FPSCounter
    {
        private ulong _lastTime = SDL_GetPerformanceCounter();
        private int _frameCount;
        private double _fps;

        public double FPS => _fps;
        public ulong startCounter;
        public ulong frequency;


        public void Start()
        {
            startCounter = SDL_GetPerformanceCounter();
            frequency = SDL_GetPerformanceFrequency();
        }

        public void Update()
        {
            _frameCount++;
            var currentTime = SDL_GetPerformanceCounter();
            var elapsedTime = (currentTime - _lastTime) / (double)SDL_GetPerformanceFrequency();

            if (!(elapsedTime >= 0.1)) return;

            _fps = _frameCount / elapsedTime;
            _frameCount = 0;
            _lastTime = currentTime;
        }
    }
}