using System;

namespace Hybrid
{
    // Engine
    internal static partial class Engine
    {
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

            // Create
            Audio.FindOrCreate();
            Window.FindOrCreate();
            Graphics.FindOrCreate();
            Resources.FindOrCreate();
            Scenes.FindOrCreate();
            
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
            foreach (var module in Module.GetModules())
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
            foreach (var module in Module.GetModules())
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
            foreach (var module in Module.GetModules())
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
            foreach (var module in Module.GetModules())
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
            foreach(var module in Module.GetModules().Reverse())
            {
                module.OnDestroy();
            }
            
            SDL.Quit();
        }
    }
}