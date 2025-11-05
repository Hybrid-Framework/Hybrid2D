using System;

namespace Hybrid
{
    // Engine
    internal partial class Engine
    {
        internal bool Initialized { get; private set; } = false;
        internal bool IsRunning { get; private set; } = true;
        
        internal Config Config { get; private set; }
        

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
            
            // Frame Timing
            Time.Initialize();
            
            // Create Device
            GraphicsDevice.Create(Config);
            
            // Load Default Scene
            SceneManager.Load(Config.Scene);
        }
        
        // Engine Main Loop
        internal void MainLoop()
        {
            // Calculate Time
            Time.BeforeFrame();

            // Frame
            Events();
            Update();
            Render();

            // Calculate Time
            Time.AfterFrame();
        }
        
        internal void Quit()
        {
            // Quit Application
            if(!IsRunning) return;
            IsRunning = false;
            
            // Destroy Resources
            GraphicsDevice.Destroy();
            SDL.Quit();
        }
    }
    
    // Engine Events
    internal partial class Engine
    {
        // Update All Events
        internal void Events()
        {
            // Send SDL Events to Events
            while (SDL.PollEvent(out SDL.Event e))
            {
                Hybrid.Events.Event(e);
            }
        }
    }
    
    // Engine Update
    internal partial class Engine
    {
        internal void Update()
        {
            // For Each Scene GameObject
            foreach (var obj in SceneManager.ActiveScene.GetSceneObjects())
            {
                // Skip GameObject 
                if(!obj.Enabled) continue;
                
                // For Each Component In GameObject
                foreach (var component in obj.GetComponents())
                {
                    // Skip Component
                    if(!component.Enabled) continue;
                
                    // Start
                    if (!component.OnStarted)
                    {
                        component.OnStarted = true;
                        component.OnStart();
                    }
                
                    // Update
                    component.OnUpdate();
                }
            }
        }
    }
    
    // Engine Render
    internal partial class Engine
    {
        // Render All Objects
        internal void Render()
        {
            GraphicsDevice.ClearColor(Color.CornFlowerBlue);
            GraphicsDevice.DrawStats(Color.White);
            GraphicsDevice.Present();
        }
    }
}