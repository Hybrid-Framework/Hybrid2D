using System;

namespace Hybrid.Internal
{
    // Engine
    internal static partial class Engine
    {
        internal static Modules Modules { get; private set; } = new Modules();
        
        internal static Resources Resources { get; private set; }
        internal static Graphics Graphics { get; private set; }
        internal static Window Window { get; private set; }
        internal static Scenes Scenes { get; private set; }
        internal static Audio Audio { get; private set; }
        
        internal static bool Initialized { get; private set; }
        internal static bool IsRunning { get; private set; }
        
        internal static Config Config { get; set; }
        
        
        internal static void Create(Config config)
        {
            Config = config;
        }
    }

    // Main Loop
    internal partial class Engine
    {
        internal static void StartMainLoop()
        {
            // Initialize
            if (Initialized) return;
            Initialized = true;
            IsRunning = true;

            // Initialize Modules
            Audio = Modules.Register(new Audio());
            Window = Modules.Register(new Window());
            Graphics = Modules.Register(new Graphics());
            Resources = Modules.Register(new Resources());
            Scenes = Modules.Register(new Scenes());
            
            OnInitialize();
        }
        
        internal static void MainLoop()
        {
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
        }
        
        internal static void Quit()
        {
            // Quit Application
            if (!IsRunning) return;
            IsRunning = false;
            
            OnQuit();
        }
    }

    // Initialize
    internal partial class Engine
    {
        internal static void OnInitialize()
        {
            foreach (var module in Modules.GetModules())
            {
                module.OnInitialize();
            }
        }
    }

    // Events
    internal partial class Engine
    {
        internal static void OnEvent(SDL.Event e)
        {
            foreach (var module in Modules.GetModules())
            {
                module.OnEvent(e);
            }
        }
    }

    // Update
    internal partial class Engine
    {
        internal static void OnUpdate()
        {
            foreach (var module in Modules.GetModules())
            {
                module.OnUpdate();
            }
        }
    }

    // Render
    internal partial class Engine
    {
        internal static void OnRender()
        {
            foreach (var module in Modules.GetModules())
            {
                module.OnRender();
            }
        }
    }
    
    // Quit
    internal partial class Engine
    {
        internal static void OnQuit()
        {
            foreach(var module in Modules.GetModules().Reverse())
            {
                Modules.UnRegister(module);
            }
            
            SDL.Quit();
        }
    }
}