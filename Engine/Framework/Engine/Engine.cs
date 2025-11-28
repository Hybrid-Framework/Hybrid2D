using System;

namespace Hybrid
{
    // Engine
    internal partial class Engine : Module<Engine>
    {
        internal bool Initialized { get; private set; }
        internal bool IsRunning { get; private set; }
        
        
        internal void StartMainLoop()
        {
            // Initialize
            if (Initialized) return;
            Initialized = true;
            IsRunning = true;

            // Create
            Register(Platform.FindOrCreate());
            Register(Storage.FindOrCreate());
            Register(Audio.FindOrCreate());
            Register(Window.FindOrCreate());
            Register(Graphics.FindOrCreate());
            Register(Resources.FindOrCreate());
            Register(Input.FindOrCreate());
            Register(Scenes.FindOrCreate());
            
            // Initialize
            OnInitialize();
        }
        
        internal void MainLoop()
        {
            // Frame Time
            Time.BeforeFrame();
            
            while (SDL.PollEvent(out SDL.Event e))
            {
                // Quit Application
                if(e.type == SDL.EventType.Quit)
                {
                    Quit();
                    return;
                }
                
                OnEvent(e);
            }
            
            OnUpdate();
            OnRender();
            
            // Frame Limit
            Time.AfterFrame();
        }
        
        internal void Quit()
        {
            // Quit Application
            if (!IsRunning) return;
            IsRunning = false;
            
            foreach(var module in GetModules().Reverse())
            {
                UnRegister(module);
            }
            
            SDL.Quit();
        }
    }

    // Initialize
    internal partial class Engine
    {
        internal override void OnInitialize()
        {
            foreach (var module in GetModules())
            {
                module.OnInitialize();
            }
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