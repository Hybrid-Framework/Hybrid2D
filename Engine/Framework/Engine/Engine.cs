using System;

namespace Hybrid
{
    // Engine
    internal partial class Engine
    {
        internal static List<Module> Modules = new List<Module>(); // Populated by constructors
        
        internal bool Initialized { get; private set; }
        internal bool IsRunning { get; private set; }
        
        internal static GraphicsDevice GraphicsDevice;
        internal static Content Content;
        
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
            
            // Create Modules
            // Auto Added To Modules List
            GraphicsDevice = new GraphicsDevice(Config);
            Content = new Content(Config);
            
            // Initialize
            OnInitialize();
        }
        
        // Engine Main Loop
        internal void MainLoop()
        {
            // Calculate Time
            Time.BeforeFrame();
            
            // Frame
            OnEvent();
            OnUpdate();
            OnRender();
            
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
            
            // Quit
            SDL.Quit();
        }
    }
    
    // Engine Events
    internal partial class Engine
    {
        internal void OnEvent()
        {
            // Gather SDL events
            List<SDL.Event> events = new List<SDL.Event>();
    
            while (SDL.PollEvent(out SDL.Event e))
            {
                // Quit Application
                if (e.type == SDL.EventType.Quit)
                {
                    Quit();
                    return;
                }
        
                // Add
                events.Add(e);
            }
            
            // Event Modules
            foreach (var module in Modules)
            {
                if(events.Count > 0)
                {
                    // Send Events
                    foreach(var e in events)
                    {
                        module.OnEvent(e);
                    }
                }
                else
                {
                    // Call Per Frame
                    module.OnEvent(default);
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