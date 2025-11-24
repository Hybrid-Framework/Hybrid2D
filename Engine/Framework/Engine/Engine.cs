using System;

namespace Hybrid
{
    // Engine
    internal static partial class Engine
    {
        internal static List<Module> Modules { get; private set; } = new List<Module>();
        
        internal static Resources Resources { get; private set; }
        internal static Graphics Graphics { get; private set; }
        internal static Window Window { get; private set; }
        internal static Scenes Scenes { get; private set; }
        
        internal static bool Initialized { get; private set; }
        internal static bool IsRunning { get; private set; }
        
        private static Config Config { get; set; }
        
        
        internal static void Create(Config config)
        {
            Config = config;
        }
    }

    // Engine Main
    internal partial class Engine
    {
        internal static T Register<T>(T module) where T : Module
        {
            // Register Module
            Modules.Add(module);
            return module;
        }

        internal static T UnRegister<T>(T module) where T : Module
        {
            // UnRegister Modules
            Modules.Remove(module);
            module.OnDestroy();
            return module;
        }
        
        internal static void StartMainLoop()
        {
            // Already Initialized
            if (Initialized) return;
            Initialized = true;
            IsRunning = true;

            // Initialize Engine Modules
            Window = Register(new Window(Config));
            Graphics = Register(new Graphics(Config));
            Resources = Register(new Resources(Config));
            Scenes = Register(new Scenes(Config));
            
            // Initialize Modules
            foreach (var module in Modules)
            {
                module.OnInitialize();
            }
        }
        
        internal static void MainLoop()
        {
            // SDL Pump Events
            while (SDL.PollEvent(out SDL.Event e))
            {
                // Quit Application
                if(e.type == SDL.EventType.Quit)
                {
                    Quit(); return;
                }
                
                // Event Modules
                foreach (var module in Modules)
                {
                    module.OnEvent(e);
                }
            }
            
            // Update Modules
            foreach (var module in Modules)
            {
                module.OnUpdate();
            }
            
            // Render Modules
            foreach (var module in Modules)
            {
                module.OnRender();
            }
        }
        
        internal static void Quit()
        {
            // Quit
            if (IsRunning)
            {
                IsRunning = false;
            
                // UnRegister Modules
                foreach(var module in Modules.ToArray().Reverse())
                {
                    UnRegister(module);
                }
            
                SDL.Quit();
            }
        }
    }
}