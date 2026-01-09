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
            if (!Initialized)
            {
                IsRunning = true;
                Initialized = true;
                
                Bootstrap.Execute(this);
            }
        }
        
        public void Quit()
        {
            if (IsRunning)
            {
                IsRunning = false;
                
                OnEngineDispose();
                SDL.Quit();
            }
        }

        internal void StartMainLoop()
        {
            if (Initialized)
            {
                try
                {
                    Window = new Window("Hybrid", 600, 400);
                    Graphics = new Graphics(true);
                    Time = new Time();

                    OnInitialize();
                }
                catch (Exception ex)
                {
                    Exceptions.Throw(ex, this);
                }
            }
        }

        internal void MainLoop()
        {
            if (IsRunning)
            {
                try
                {
                    OnEngineStartOfFrame();

                    OnEngineUpdate();
                    OnEngineRender();

                    OnEngineEndOfFrame();
                }
                catch (Exception ex)
                {
                    Exceptions.Throw(ex, this);
                }
            }
        }

        internal void Events(SDL.Event e)
        {
            if (IsRunning)
            {
                try
                {
                    if (e.type == SDL.EventType.Quit)
                    {
                        Quit();
                        return;
                    }

                    OnEngineEvent(e);
                }
                catch (Exception ex)
                {
                    Exceptions.Throw(ex, this);
                }
            }
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