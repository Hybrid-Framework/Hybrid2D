using System;

namespace Hybrid
{
    // Engine
    internal partial class Engine
    {
        internal static Graphics Graphics { get; private set; }
        internal static Window Window { get; private set; }
        internal static Scenes Scenes { get; private set; }
        
        internal bool Initialized { get; private set; }
        internal bool IsRunning { get; private set; }
        
        private static Config Config { get; set; }
        
        internal Engine(Config config)
        {
            Config = config;
        }
    }
    
    // Engine Core
    internal partial class Engine
    {
        // Engine Start Main Loop
        internal void StartMainLoop()
        {
            // Already Initialized
            if (Initialized)return;
            Initialized = true;
            IsRunning = true;

            // Initialize Engine Modules
            Window = Module.Register(new Window(Config));
            Graphics = Module.Register(new Graphics(Config));
            Scenes = Module.Register(new Scenes(Config));
            
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
            // Destroy Modules
            foreach (var module in Module.GetModules().Reverse())
            {
                Object.Destroy(module);
            }
            
            // Quit
            SDL.Quit();
        }
    }
    
    // Engine Initialize
    internal partial class Engine
    {
        internal void OnInitialize()
        {
            // Initialize Modules
            foreach (var module in Module.GetModules())
            {
                module.OnInitialize();
            }
        }
    }
    
    // Engine Events
    internal partial class Engine
    {
        internal void OnEvent()
        {
            while (SDL.PollEvent(out SDL.Event e))
            {
                // Event Modules
                foreach (var module in Module.GetModules())
                {
                    module.OnEvent(e);
                }
            }
        }
    }
    
    // Engine Update
    internal partial class Engine
    {
        internal void OnUpdate()
        {
            // Update Modules
            foreach (var module in Module.GetModules())
            {
                module.OnUpdate();
            }
        }
    }
    
    // Engine Render
    internal partial class Engine
    {
        internal void OnRender()
        {
            // Render Modules
            foreach (var module in Module.GetModules())
            {
                module.OnRender();
            }
        }
    }
}