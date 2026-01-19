using System.Collections.Generic;
using System.Linq;
using System;

namespace Hybrid
{
    public abstract partial class App
    {
        internal bool Initialized { get; private set; } = false;
        internal bool IsRunning { get; private set; } = false;
        
        internal TouchKeyboard TouchKeyboard { get; set; }
        internal Keyboard Keyboard { get; set; }
        internal Graphics Graphics { get; set; }
        internal Gamepad Gamepad { get; set; }
        internal Window Window { get; set; }
        internal Mouse Mouse { get; set; }
        internal Touch Touch { get; set; }
        internal Mixer Mixer { get; set; }
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
                
                OnEngineDestroy();
                SDL.Quit();
            }
        }

        internal void MainInitialize()
        {
            if (Initialized)
            {
                try
                {
                    Mixer = new Mixer();
                    Window = new Window();
                    Graphics = new Graphics();
                    TouchKeyboard = new TouchKeyboard();
                    Keyboard = new Keyboard();
                    Gamepad = new Gamepad();
                    Mouse = new Mouse();
                    Touch = new Touch();
                    Time = new Time();
                    
                    OnEngineInitialize();
                    {
                        Window.Show();
                    }
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
        
        internal void OnEngineInitialize()
        {
            foreach (Module module in Module.Modules)
            {
                module.OnInitialize();
            }

            OnInitialize();
        }
        
        internal void OnEngineUpdate()
        {
            foreach (Module module in Module.Modules)
            {
                module.OnUpdate();
            }
            
            OnUpdate();
        }
        
        internal void OnEngineRender()
        {
            foreach (Module module in Module.Modules)
            {
                module.OnRender();
            }
            
            OnRender();
        }
        
        internal void OnEngineStartOfFrame()
        {
            foreach (Module module in Module.Modules)
            {
                module.OnStartOfFrame();
            }
        }
        
        internal void OnEngineEvent(SDL.Event e)
        {
            foreach (Module module in Module.Modules)
            {
                module.OnEvent(e);
            }
        }
        
        internal void OnEngineEndOfFrame()
        {
            foreach (Module module in Module.Modules)
            {
                module.OnEndOfFrame();
            }
        }
        
        internal void OnEngineDestroy()
        {
            foreach (Module module in Module.Modules)
            {
                module.Destroy();
            }
        }
    }
}