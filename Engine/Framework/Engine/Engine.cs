using System;

namespace Hybrid
{
    // Engine
    internal sealed partial class Engine : Module<Engine>
    {
        internal bool Initialized { get; private set; }
        internal bool IsRunning { get; private set; }
        
        
        internal void StartMainLoop()
        {
            // Initialize
            if (Initialized) return;
            Initialized = true;
            IsRunning = true;

            // Create & Initialize Modules
            Register(Storage.FindOrCreate());
            Register(Audio.FindOrCreate());
            Register(Window.FindOrCreate());
            Register(Graphics.FindOrCreate());
            Register(Resources.FindOrCreate());
            Register(Coroutines.FindOrCreate());
            Register(Input.FindOrCreate());
            Register(Scenes.FindOrCreate());
        }
        
        internal void MainLoop()
        {
            // Frame Time
            Time.BeforeFrame();
            
            // Events
            while (Platform.GetEvents().PollEvents(out SDL.Event e))
            {
                // Quit Application
                if(e.type == SDL.EventType.Quit)
                {
                    Quit();
                    return;
                }
                
                OnEvent(e);
            }
            
            // Fixed Update
            while (Time.FixedFrameTime >= Time.FixedDeltaTime)
            {
                OnFixedUpdate();
                Time.FixedFrameTime -= Time.FixedDeltaTime;
            }
            
            // Update
            OnUpdate();
            
            // Render
            OnRender();
            
            // Frame Limit
            Time.AfterFrame();
        }
        
        internal void Quit()
        {
            // Quit Application
            if (!IsRunning) return;
            IsRunning = false;
            
            // Unregister & Dispose Modules
            foreach(var module in GetModules().Reverse())
            {
                UnRegister(module);
            }
            
            SDL.Quit();
        }
    }
    
    // Events
    internal partial class Engine
    {
        internal override void OnEvent(SDL.Event e)
        {
            foreach (var module in GetModules())
            {
                module.OnEvent(e);
            }
        }
    }

    // Update
    internal partial class Engine
    {
        internal override void OnUpdate()
        {
            foreach (var module in GetModules())
            {
                module.OnUpdate();
            }
        }
    }
    
    // Fixed Update
    internal partial class Engine
    {
        internal override void OnFixedUpdate()
        {
            foreach (var module in GetModules())
            {
                module.OnFixedUpdate();
            }
        }
    }

    // Render
    internal partial class Engine
    {
        internal override void OnRender()
        {
            foreach (var module in GetModules())
            {
                module.OnRender();
            }
        }
    }
}