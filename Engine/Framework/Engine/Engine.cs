using System;

namespace Hybrid
{
    // Engine
    internal partial class Engine
    {
        internal static List<Module> Modules = new List<Module>(); // Populated by constructors
        
        internal bool HasStarted { get; private set; }
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
        }
        
        // Engine Main Loop
        internal void MainLoop()
        {
            // Calculate Time
            Time.BeforeFrame();
            
            // Frame
            OnFrameStart();
            OnEvent();
            OnStart();
            OnUpdate();
            OnRender();
            OnFrameEnd();
            
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

        internal void OnFrameStart()
        {
            foreach (var module in Modules)
            {
                module.OnFrameStart();
            }
        }

        internal void OnFrameEnd()
        {
            foreach (var module in Modules)
            {
                module.OnFrameEnd();
            }
        }
    }
    
    // Engine Events
    internal partial class Engine
    {
        internal void OnEvent()
        {
            // Process SDL Events
            while (SDL.PollEvent(out SDL.Event e))
            {
                // Quit Application
                if (e.type == SDL.EventType.Quit)
                {
                    Quit();
                    return;
                }
                
                // Event Modules
                foreach (var module in Modules)
                {
                    module.OnEvent(e);
                }
            }
        }
    }
    
    // Engine Start
    internal partial class Engine
    {
        internal void OnStart()
        {
            if(HasStarted) return;
            HasStarted = true;
            
            // Start Modules
            foreach (var module in Modules)
            {
                module.OnStart();
            }
            
            // Start Game
            Config.Game.OnStart();
        }
    }
    
    // Engine Update
    internal partial class Engine
    {
        internal void OnUpdate()
        {
            // Start Modules
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