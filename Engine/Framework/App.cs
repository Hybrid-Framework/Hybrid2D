using System.Linq;
using System;

namespace Hybrid
{
    public abstract partial class App
    {
        internal bool Initialized { get; private set; } = false;
        internal bool IsRunning { get; private set; } = false;
        
        internal Graphics Graphics { get; set; }
        internal Window Window { get; set; }
        internal Time Time { get; set; }

        
        public void Run()
        {
            if (Initialized) return;
            Initialized = true;
            IsRunning = true;
            
            Bootstrap.Execute(this);
        }

        internal void StartMainLoop()
        {
            Window = new Window("Hybrid", 600, 400);
            Graphics = new Graphics(true);
            Time = new Time();
            
            OnInitialize();
        }

        internal void MainLoop()
        {
            OnEngineStartOfFrame();
            
            OnEngineUpdate();
            OnEngineRender();
            
            OnEngineEndOfFrame();
        }

        internal void Events(SDL.Event e)
        {
            if (e.type == SDL.EventType.Quit)
            {
                Quit(); return;
            }
            
            OnEngineEvent(e);
        }

        public void Quit()
        {
            if (!IsRunning) return;
            IsRunning = false;
            
            OnEngineDispose();
            SDL.Quit();
        }
    }

    public partial class App
    {
        public virtual void OnInitialize() { }
        public virtual void OnRender() { }
        public virtual void OnUpdate() { }
        
        
        internal void OnEngineStartOfFrame()
        {
            foreach (Module module in Module.GetModules())
            {
                module.OnStartOfFrame();
            }
        }
        
        internal void OnEngineInitialize()
        {
            foreach (Module module in Module.GetModules())
            {
                module.OnInitialize();
            }

            OnInitialize();
        }
        
        internal void OnEngineEvent(SDL.Event e)
        {
            foreach (Module module in Module.GetModules())
            {
                module.OnEvent(e);
            }
        }
        
        internal void OnEngineUpdate()
        {
            foreach (Module module in Module.GetModules())
            {
                module.OnUpdate();
            }
            
            OnUpdate();
        }
        
        internal void OnEngineRender()
        {
            foreach (Module module in Module.GetModules())
            {
                module.OnRender();
            }
            
            OnRender();
        }
        
        internal void OnEngineEndOfFrame()
        {
            foreach (Module module in Module.GetModules())
            {
                module.OnEndOfFrame();
            }
        }
        
        internal void OnEngineDispose()
        {
            foreach (Module module in Module.GetModules().Reverse())
            {
                module.OnDispose();
            }
        }
    }
}