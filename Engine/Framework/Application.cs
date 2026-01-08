using System.Linq;
using System;

namespace Hybrid
{
    public abstract partial class Application
    {
        internal bool Initialized { get; private set; }
        internal bool IsRunning { get; private set; }
        
        internal Graphics Graphics { get; set; }
        internal Window Window { get; set; }
        internal Time Time { get; set; }

        
        public void Run()
        {
            Bootstrap.Execute(this);
        }

        internal void StartMainLoop()
        {
            if(Initialized) return;
            Initialized = true;
            IsRunning = true;
            
            Window = new Window(600, 400);
            Graphics = new Graphics();
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
            if(!IsRunning) return;
            IsRunning = false;
            
            OnEngineDispose();
            SDL.Quit();
        }
    }

    public partial class Application
    {
        internal virtual void OnEvent(SDL.Event e) { }
        internal virtual void OnStartOfFrame() { }
        internal virtual void OnEndOfFrame() { }
        internal virtual void OnDispose() { }
        public virtual void OnInitialize() { }
        public virtual void OnRender() { }
        public virtual void OnUpdate() { }
        
        
        internal void OnEngineStartOfFrame()
        {
            foreach (Module module in Module.GetModules())
            {
                module.OnStartOfFrame();
            }
            
            OnStartOfFrame();
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
            
            OnEvent(e);
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

            OnEndOfFrame();
        }
        
        internal void OnEngineDispose()
        {
            foreach (Module module in Module.GetModules().Reverse())
            {
                module.OnDispose();
            }
            
            OnDispose();
        }
    }
}