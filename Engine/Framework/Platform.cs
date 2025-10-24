using System;

namespace Hybrid
{
    #region Platform Creation
    public partial class Platform : IDisposable
    {
        internal static GameBehaviour GameBehaviour { get; set; }
        internal static Platform Current { get; set; }

        public static void Create(Platform platform)
        {
            Current = platform;
            Current?.Bootstrap();
        }
    }
    #endregion

    
    #region Platform Behaviour
    public unsafe partial class Platform
    {
        internal virtual PlatformType PlatformType { get; set; }
        internal virtual PlatformDevice PlatformDevice { get; set; }
        internal static bool Initialized { get; set; }
        internal static bool IsRunning { get; set; }
        ulong _startCounter;
        ulong _lastCounter;
        ulong _frequency;
        float _smoothed;
        

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
                Time.deltaTime = 0f;
                Time.frameTime = 0f;
                Time.time = 0f;
                Time.fps = 0f;
                
                // Initialize
                GameBehaviour?.Initialize();
                Initialized = true;
                IsRunning = true;
            }
        }
        
        internal void MainLoop()
        {
            // Invalid Window
            if (Window.GetWindow() == null || Window.GetRenderer() == null) throw new Exception("Please create a window using Window.Create(...);");
            
            // Frame Timing
            ulong frameStart = SDL.GetPerformanceCounter();
            double elapsed = (frameStart - _lastCounter) / (double)_frequency;
            _lastCounter = frameStart;
            
            // Time Calculating
            Time.unscaledDeltaTime = (float)Math.Min(elapsed, 0.1);
            Time.deltaTime = Time.unscaledDeltaTime * Time.timeScale;
            Time.fps = _smoothed = (_smoothed * 0.9f) + ((1f / Time.unscaledDeltaTime) * 0.1f);
            Time.frameTime = Time.unscaledDeltaTime * 1000f;
            Time.unscaledTime += Time.unscaledDeltaTime;
            Time.time += Time.deltaTime;
            
            // Events
            while (SDL.PollEvent(out SDL.Event e))
            {
                var type = (SDL.EventType)e.type;

                if (type == SDL.EventType.Quit)
                {
                    Current?.Quit();
                    return;
                }
            }
            
            // Main Loop
            GameBehaviour?.Update();
            GameBehaviour?.Draw();
            
            // Frame Limiting
            if (Window.VSync == false && Window.TargetFPS != 0)
            {
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

        internal void Quit()
        {
            IsRunning = false;
            Dispose(true);
        }
    }
    #endregion
    

    #region Platform Dispose
    public abstract partial class Platform
    {
        internal static bool disposed { get; set; }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public static void Dispose(bool dispose)
        {
            if (disposed) return;
            disposed = true;

            if (dispose)
            {
                // Dispose
                Window.Dispose();
            }
        }
    }
    #endregion
}