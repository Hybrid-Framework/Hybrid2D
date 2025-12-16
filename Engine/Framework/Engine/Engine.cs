using System;

namespace Hybrid
{
    // Engine
    internal sealed partial class Engine : Module<Engine>
    {
        internal bool Initialized { get; private set; }
        internal bool IsRunning { get; private set; }

        
        internal bool Run()
        {
            try
            {
                StartMainLoop();
                MainLoop();
            }
            catch (Exception exception)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{exception.Message} at [{exception.TargetSite}]\n{exception.StackTrace}");
                Quit();
            }
            
            return IsRunning;
        }
        
        private void StartMainLoop()
        {
            // Initialize
            if (Initialized) return;
            Initialized = true;
            IsRunning = true;

            // Create & Initialize Modules
            Register(Storage.FindOrCreate());
            Register(Audio.FindOrCreate());
            Register(Window.FindOrCreate());
            Register(Graphics.FindOrCreate());
            Register(Resources.FindOrCreate());
            Register(Coroutines.FindOrCreate());
            Register(Invoking.FindOrCreate());
            Register(Input.FindOrCreate());
            Register(Scenes.FindOrCreate());

            // Initialize
            OnInitialize();
        }
        
        private void MainLoop()
        {
            // Frame Time
            Time.BeforeFrame();
            
            // Start Frame
            OnStartOfFrame();
            
            // Events
            while (Platform.GetEvents().PollEvents(out SDL.Event e))
            {
                // Quit Application
                if(e.type == SDL.EventType.Quit)
                {
                    Quit();
                    return;
                }
                
                OnEvent(e);
            }
            
            // Fixed Update
            while (Time.FixedFrameTime >= Time.FixedDeltaTime)
            {
                OnFixedUpdate();
                Time.FixedFrameTime -= Time.FixedDeltaTime;
            }
            
            // Update
            OnUpdate();

            // Late Update
            OnLateUpdate();
            
            // Render
            OnRender();
            
            // End Frame
            OnEndOfFrame();
            
            // Frame Limit
            Time.AfterFrame();
        }
        
        internal void Quit()
        {
            // Quit Application
            if (!IsRunning) return;
            IsRunning = false;
            
            // Unregister & Dispose Modules
            foreach(var module in GetModules().Reverse())
            {
                UnRegister(module);
            }
            
            SDL.Quit();
        }
    }
    
    // Initialize
    internal partial class Engine
    {
        internal override void OnInitialize()
        {
            foreach (var module in GetModules())
            {
                module.OnInitialize();
            }
        }
    }
    
    // Start Of Frame
    internal partial class Engine
    {
        internal override void OnStartOfFrame()
        {
            foreach (var module in GetModules())
            {
                module.OnStartOfFrame();
            }
        }
    }
    
    // Events
    internal partial class Engine
    {
        internal override void OnEvent(SDL.Event e)
        {
            foreach (var module in GetModules())
            {
                module.OnEvent(e);
            }
        }
    }

    // Update
    internal partial class Engine
    {
        internal override void OnUpdate()
        {
            foreach (var module in GetModules())
            {
                module.OnUpdate();
            }
        }
    }
    
    // Fixed Update
    internal partial class Engine
    {
        internal override void OnFixedUpdate()
        {
            foreach (var module in GetModules())
            {
                module.OnFixedUpdate();
            }
        }
    }
    
    // Late Update
    internal partial class Engine
    {
        internal override void OnLateUpdate()
        {
            foreach (var module in GetModules())
            {
                module.OnLateUpdate();
            }
        }
    }

    // Render
    internal partial class Engine
    {
        internal override void OnRender()
        {
            foreach (var module in GetModules())
            {
                module.OnRender();
            }
        }
    }
    
    // End Of Frame
    internal partial class Engine
    {
        internal override void OnEndOfFrame()
        {
            foreach (var module in GetModules())
            {
                module.OnEndOfFrame();
            }
        }
    }
}