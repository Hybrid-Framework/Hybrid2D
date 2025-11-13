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
        internal static Resources Resources;
        internal static Input Input;
        
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
            Resources = new Resources(Config);
            Input = new Input(Config);
            
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
            // Gather SDL Events
            List<SDL.Event> events = new List<SDL.Event>();
            
            while (SDL.PollEvent(out SDL.Event e))
            {
                // Quit Application
                if (e.type == SDL.EventType.Quit)
                {
                    Quit();
                    return;
                }
                
                events.Add(e);
            }
            
            // Foreach Module
            events.Add(default);
            foreach (var module in Modules)
            {
                foreach (var e in events)
                {
                    module.OnEvent(e);
                }
            }
        }
    }
    
    // Engine Initialize
    internal partial class Engine
    {
        internal void OnInitialize()
        {
            // Initialize Modules
            foreach (var module in Modules)
            {
                module.OnInitialize();
            }
            
            // Initialize Game
            Config.Game.OnInitialize();
        }
    }
    
    // Engine Update
    internal partial class Engine
    {
        internal void OnUpdate()
        {
            // Update Modules
            foreach (var module in Modules)
            {
                module.OnUpdate();
            }
            
            // Update Game
            Config.Game.OnUpdate();
        }
    }
    
    // Engine Render
    internal partial class Engine
    {
        internal void OnRender()
        {
            // Render Modules
            foreach (var module in Modules)
            {
                module.OnRender();
            }
            
            // Render Game
            Config.Game.OnRender();
        }
    }
}