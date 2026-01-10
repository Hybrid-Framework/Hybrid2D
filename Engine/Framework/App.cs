using System.Collections.Generic;
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

        internal void MainInitialize()
        {
            if (Initialized)
            {
                try
                {
                    Window = new Window();
                    Graphics = new Graphics();
                    Time = new Time();

                    OnEngineInitialize();
                }
                catch (Exception ex)
                {
                    Exceptions.Throw(ex, this);
                }
            }
        }

        internal void MainLoop(Queue<SDL.Event> Events)
        {
            if (IsRunning)
            {
                try
                {
                    OnEngineStartOfFrame();

                    while (Events.Count > 0)
                    {
                        var e = Events.Dequeue();
                        {
                            if (e.type == SDL.EventType.Quit)
                            {
                                Quit();
                                return;
                            }

                            OnEngineEvent(e);
                        }
                    }

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