using System.Collections.Generic;
using System.Linq;
using System;

namespace Hybrid
{
    // Game
    public abstract partial class Game
    {
        private readonly List<Module> Modules = new List<Module>();
        internal bool Initialized { get; private set; }
        internal bool IsRunning { get; private set; }
        
        
        internal void StartMainLoop()
        {
            // Initialize
            if (Initialized) return;
            Initialized = true;
            IsRunning = true;

            // Modules
            Modules.Add(new Storage());
            Modules.Add(new Audio());
            Modules.Add(new Window());
            Modules.Add(new Graphics());
            Modules.Add(new Resources());
            Modules.Add(new Input());

            // Initialize
            OnEngineInitialize();
        }
        
        internal void MainLoop()
        {
            // Frame Time
            Time.BeforeFrame();
            
            // Start Frame
            OnEngineStartOfFrame();
            
            // Events
            while (Platform.GetEvents().PollEvents(out SDL.Event e))
            {
                // Quit Application
                if(e.type == SDL.EventType.Quit)
                {
                    Quit();
                    return;
                }
                
                OnEngineEvent(e);
            }
            
            // Fixed Update
            while (Time.FixedFrameTime >= Time.FixedDeltaTime)
            {
                Time.InFixedTimeStep = true;
                
                OnEngineFixedUpdate();
                {
                    Time.FixedUnscaledTimer += Time.FixedUnscaledDeltaTime;
                    Time.FixedTimer += Time.FixedDeltaTime;
                }
                
                Time.FixedFrameTime -= Time.FixedDeltaTime;
                Time.InFixedTimeStep = false;
            }
            
            // Update
            OnEngineUpdate();

            // Late Update
            OnEngineLateUpdate();
            
            // Render
            OnEngineRender();
            
            // End Frame
            OnEngineEndOfFrame();
            
            // Frame Limit
            Time.AfterFrame();
        }
        
        internal void Quit()
        {
            // Quit Application
            if (!IsRunning) return;
            IsRunning = false;
            
            // Unregister & Dispose Modules
            foreach(var module in Modules.ToArray().Reverse())
            {
                module.OnDispose();
            }
            
            SDL.Quit();
        }
    }
    
    // Events
    public partial class Game
    {
        internal void OnEngineEvent(SDL.Event e)
        {
            foreach (var module in Modules)
            {
                module.OnEvent(e);
            }
        }
        
        internal virtual void OnEvent(SDL.Event e) { }
    }
    
    // Initialize
    public partial class Game
    {
        internal void OnEngineInitialize()
        {
            foreach (var module in Modules)
            {
                module.OnInitialize();
            }

            OnInitialize();
        }

        public virtual void OnInitialize() { }
    }
    
    // Start Of Frame
    public partial class Game
    {
        internal void OnEngineStartOfFrame()
        {
            foreach (var module in Modules)
            {
                module.OnStartOfFrame();
            }
            
            OnStartOfFrame();
        }

        public virtual void OnStartOfFrame() { }
    }

    // Update
    public partial class Game
    {
        internal void OnEngineUpdate()
        {
            foreach (var module in Modules)
            {
                module.OnUpdate();
            }

            OnUpdate();
        }

        public virtual void OnUpdate() { }
    }
    
    // Fixed Update
    public partial class Game
    {
        internal void OnEngineFixedUpdate()
        {
            foreach (var module in Modules)
            {
                module.OnFixedUpdate();
            }

            OnFixedUpdate();
        }

        public virtual void OnFixedUpdate() { }
    }
    
    // Late Update
    public partial class Game
    {
        internal void OnEngineLateUpdate()
        {
            foreach (var module in Modules)
            {
                module.OnLateUpdate();
            }

            OnLateUpdate();
        }

        public virtual void OnLateUpdate() { }
    }

    // Render
    public partial class Game
    {
        internal void OnEngineRender()
        {
            foreach (var module in Modules)
            {
                module.OnRender();
            }

            OnRender();
        }

        public virtual void OnRender() { }
    }
    
    // End Of Frame
    public partial class Game
    {
        internal void OnEngineEndOfFrame()
        {
            foreach (var module in Modules)
            {
                module.OnEndOfFrame();
            }

            OnEndOfFrame();
        }

        public virtual void OnEndOfFrame() { }
    }
}