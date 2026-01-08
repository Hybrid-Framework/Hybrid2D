using System;
using System.Diagnostics;

namespace Hybrid
{
    public abstract unsafe class Application
    {
        private Stopwatch Stopwatch = new Stopwatch();
        private static int Frames = 0;
        
        private static double FrameFrequency { get; set; }
        private static long FramePrevious { get; set; }
        private static long FrameStart  { get; set; }
        private static float Fps { get; set; }
        
        public bool Initialized { get; internal set; }
        public bool IsRunning { get; internal set; }
        
        internal Graphics Graphics { get; set; }
        internal Window Window { get; set; }

        
        public void Run()
        {
            if(Initialized) return;
            Initialized = true;
            IsRunning = true;
            
            Bootstrap.Execute(this);
        }

        internal void StartMainLoop()
        {
            FrameFrequency = SDL.GetPerformanceFrequency();
            FramePrevious = SDL.GetPerformanceCounter();
            FrameStart = FramePrevious;
            
            Window = new Window(600, 400);
            Graphics = new Graphics();
            Stopwatch.Start();
        }

        internal void MainLoop()
        {
            FrameStart = SDL.GetPerformanceCounter();
            float elapsed = (float)((FrameStart - FramePrevious) / FrameFrequency);
            FramePrevious = FrameStart;

            Fps = (Fps * 0.9f) + ((1f / elapsed) * 0.1f);
            Frames += 1;

            if (Stopwatch.Elapsed.TotalMilliseconds > 1000)
            {
                Debug.Log("Frames In a second: " + Frames);
                Stopwatch.Restart();
                Frames = 0;
            }

            SDL.SetRenderDrawColor(Graphics.Handle, 255, 128, 128, 255);
            SDL.RenderClear(Graphics.Handle);

            SDL.SetRenderDrawColor(Graphics.Handle, 255, 255, 255, 255);
            SDL.RenderDebugText(Graphics.Handle, 10, 10, Fps.ToString("N0"));
            SDL.RenderPresent(Graphics.Handle);
        }

        internal void Events(SDL.Event e)
        {
            if (e.type == SDL.EventType.Quit)
            {
                IsRunning = false;
                return;
            }
        }

        internal void Quit()
        {
            Debug.Log("Quit");
            SDL.DestroyRenderer(Graphics.Handle);
            SDL.DestroyWindow(Window.Handle);
            SDL.Quit();
        }
    }
}