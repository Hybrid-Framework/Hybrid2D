using System;

namespace Hybrid
{
    // Engine
    internal partial class Engine
    {
        internal bool Initialized { get; private set; } = false;
        internal bool IsRunning { get; private set; } = true;
        
        internal Game Game { get; private set; }

        private ulong _startCounter;
        private ulong _lastCounter;
        private ulong _frequency;
        private float _smoothed;
        private float _fpsTimer;
        

        internal Engine(Game game)
        {
            Game = game;
        }

        internal void Quit()
        {
            // Dispose
            IsRunning = false;
            Renderer.Destroy();
            Window.Destroy();
            SDL.Quit();
        }
    }
    
    // Engine Core
    internal partial class Engine
    {
        // Engine Initialize
        internal void Initialize()
        {
            if (Initialized) return;
            Initialized = true;

            // Frame Timing
            _startCounter = SDL.GetPerformanceCounter();
            _frequency = SDL.GetPerformanceFrequency();
            _lastCounter = _startCounter;
            
            // Run
            Game?.Initialize();
        }
        
        // Engine Main Loop
        internal void MainLoop()
        {
            // Frame Timing
            ulong frameStart = SDL.GetPerformanceCounter();
            double elapsed = (frameStart - _lastCounter) / (double)_frequency;
            _lastCounter = frameStart;

            // Frame Calculating
            Time.UnscaledDeltaTime = (float)Math.Min(elapsed, 0.1);
            Time.DeltaTime = Time.UnscaledDeltaTime * Time.TimeScale;
            Time.FrameTime = Time.UnscaledDeltaTime * 1000f;
            Time.UnscaledTimer += Time.UnscaledDeltaTime;
            Time.Timer += Time.DeltaTime;

            // Frames Per Second
            float instantFps = 1f / Time.UnscaledDeltaTime;
            _smoothed = (_smoothed * 0.9f) + (instantFps * 0.1f);
            _fpsTimer += Time.DeltaTime;
            if (_fpsTimer >= 1f)
            {
                _fpsTimer = 0f;
                Time.Fps = _smoothed;
            }

            // Frame
            Events();
            Update();
            Draw();

            // Frame Limiting
            if (Window.Fps > 0 && !Window.VSync)
            {
                ulong frameEnd = SDL.GetPerformanceCounter();
                float frameTarget = 1f / Window.Fps;
                double frameElapsed = (frameEnd - frameStart) / (double)_frequency;
                double remainingTime = frameTarget - frameElapsed;

                if (remainingTime > 0.0)
                {
                    SDL.DelayPrecise((ulong)(remainingTime * 1_000_000_000.0));
                }
            }
        }
    }
    
    // Engine Events
    internal partial class Engine
    {
        internal void Events()
        {
            while (SDL.PollEvent(out SDL.Event e))
            {
                Hybrid.Events.Event(e);
            }
        }
    }
    
    // Engine Update
    internal partial class Engine
    {
        internal void Update()
        {
            Game?.Update();
        }
    }
    
    // Engine Draw
    internal partial class Engine
    {
        internal void Draw()
        {
            Game?.Draw();
        }
    }
}