using System;

namespace Hybrid
{
    // Engine
    internal partial class Engine
    {
        internal static List<Module> Modules = new List<Module>(); // Populated by constructors
        
        internal static SceneManagement SceneManagement;
        internal static GraphicsDevice GraphicsDevice;
        internal static Assets Assets;
        
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
            
            // Create Modules
            GraphicsDevice = new GraphicsDevice(Config);
            SceneManagement = new SceneManagement(Config);
            Assets = new Assets(Config);
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
        
        // Engine Quit
        internal void Quit()
        {
            // Quit Application
            if(!IsRunning) return;
            IsRunning = false;
            
            // Dispose Modules
            foreach (var module in Modules)
            {
                module.Dispose();
            }
            
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
            foreach (var obj in SceneManagement.ActiveScene.GetSceneObjects())
            {
                // Skip GameObject 
                if(!obj.Enabled) continue;
                
                // For Each Component In GameObject
                foreach (var component in obj.GetComponents())
                {
                    // Skip Component
                    if(!component.Enabled) continue;
                
                    // Call OnStart
                    if (!component.ComponentHasBeenInitialized)
                    {
                        component.ComponentHasBeenInitialized = true;
                        component.OnStart();
                    }
                
                    // Call OnUpdate
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
            // Graphics.ClearColor(Color.CornFlowerBlue);
            // Graphics.DrawStats(Color.White);
            // Graphics.Present();
        }
    }
}