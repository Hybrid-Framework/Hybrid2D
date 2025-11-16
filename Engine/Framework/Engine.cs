using System;

namespace Hybrid
{
    // Engine
    internal partial class Engine
    {
        internal bool Initialized { get; private set; }
        internal bool IsRunning { get; private set; }
        
        internal Config Config { get; }
        
        internal Engine(Config config)
        {
            Config = config;
        }
    }
    
    // Engine Core
    internal partial class Engine
    {
        // Engine Initialize
        internal void Initialize()
        {
            // Initialize
            if (Initialized) return;
            Initialized = true;
            IsRunning = true;
            
            // Initialize
            OnInitialize();
        }
        
        // Engine Main Loop
        internal void MainLoop()
        {
            // Frame
            OnEvent();
            OnUpdate();
            OnRender();
        }
        
        // Engine Quit
        internal void Quit()
        {
            // Quit Application
            if(!IsRunning) return;
            IsRunning = false;
            
            // Quit
            SDL.Quit();
        }
    }
    
    // Engine Events
    internal partial class Engine
    {
        internal void OnEvent()
        {
            while (SDL.PollEvent(out SDL.Event e))
            {
                // Quit Application
                if (e.type == SDL.EventType.Quit)
                {
                    Quit();
                    return;
                }
            }
        }
    }
    
    // Engine Initialize
    internal partial class Engine
    {
        internal void OnInitialize()
        {
            // Initialize Game
            Config.Game.OnInitialize();
        }
    }
    
    // Engine Update
    internal partial class Engine
    {
        internal void OnUpdate()
        {
            // Update Game
            Config.Game.OnUpdate();
        }
    }
    
    // Engine Render
    internal partial class Engine
    {
        internal void OnRender()
        {
            // Render Game
            Config.Game.OnRender();
        }
    }
}