using System;

namespace Hybrid
{
    // Platform
    public partial class Platform : IDisposable
    {
        public static Platform Current { get; set; }
        

        public static void Create(Platform platform)
        {
            if (platform == null)
            {
                throw new Exception("Invalid Platform");
            }
            
            Current = platform;
            Current?.Bootstrap();
        }
    }
    
    // Behaviour
    public partial class Platform
    {
        public virtual PlatformDevice PlatformDevice { get; set; }
        public virtual PlatformType PlatformType { get; set; }
        
        public virtual bool Initialized { get; set; }
        public virtual bool IsRunning { get; set; }
        
        public virtual Game Game { get; set; }
        
        ulong _startCounter;
        ulong _lastCounter;
        ulong _frequency;
        float _smoothed;
        float _fpsTimer;
        

        internal virtual void Bootstrap()
        {
            // Platform Specific Bootstrap
        }
        
        internal void Initialize()
        {
            if (!Initialized)
            {
                // Frame Timing
                _startCounter = SDL.GetPerformanceCounter();
                _frequency = SDL.GetPerformanceFrequency();
                _lastCounter = _startCounter;
                
                // Time
                Time.DeltaTime = 0f;
                Time.FrameTime = 0f;
                Time.Timer = 0f;
                Time.Fps = 0f;
                
                // Initialize
                Game?.Initialize();
                Initialized = true;
                IsRunning = true;
            }
        }
        
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
            if (Window.TargetFPS > 0)
            {
                // Disable vsync if set target fps
                if (Window.VSync) Window.VSync = false;
                
                ulong frameEnd = SDL.GetPerformanceCounter();
                float frameTarget = 1f / Window.TargetFPS;
                double frameElapsed = (frameEnd - frameStart) / (double)_frequency;
                double remainingTime = frameTarget - frameElapsed;
            
                if (remainingTime > 0.0)
                {
                    SDL.DelayPrecise((ulong)(remainingTime * 1_000_000_000.0));
                }
            }
        }

        private void Events()
        {
            // Engine Event Logic
            
            while (SDL.PollEvent(out SDL.Event e))
            {
                Hybrid.Events.Event(e);
            }
        }

        private void Update()
        {
            // Engine Update Logic
            
            Game?.Update();
        }

        private void Draw()
        {
            // Engine Draw Logic
            
            Game?.Draw();
        }

        public void Quit()
        {
            IsRunning = false;
            Dispose(true);
        }
    }
    
    // Dispose
    public abstract partial class Platform
    {
        internal static bool Disposed { get; set; }
        
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool dispose)
        {
            if (Disposed) return;
            Disposed = true;

            if (dispose)
            {
                Window.Destroy();
                Renderer.Destroy();
            }
        }

        ~Platform()
        {
            Dispose(true);
        }
    }
}