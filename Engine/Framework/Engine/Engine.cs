using System;

namespace Hybrid
{
    // Engine
    internal partial class Engine : Module<Engine>
    {
        internal bool Initialized { get; private set; }
        internal bool IsRunning { get; private set; }
        
        
        internal void StartMainLoop()
        {
            // Initialize
            if (Initialized) return;
            Initialized = true;
            IsRunning = true;

            // Initialize Modules
            Register(Storage.FindOrCreate());
            Register(Audio.FindOrCreate());
            Register(Window.FindOrCreate());
            Register(Graphics.FindOrCreate());
            Register(Resources.FindOrCreate());
            Register(Input.FindOrCreate());
            Register(Scenes.FindOrCreate());
        }
        
        internal void MainLoop()
        {
            // Frame Time
            Time.BeforeFrame();
            
            while (Platform.GetEvents().PollEvents(out SDL.Event e))
            {
                // Quit Application
                if(e.type == SDL.EventType.Quit)
                {
                    Quit();
                    return;
                }

                // Fullscreen
                if (e.type == SDL.EventType.KeyboardButtonDown)
                {
                    if (e.keyboard.keyCode == SDL.KeyCode.F)
                    {
                        Window.Fullscreen =! Window.Fullscreen;
                    }
                    
                    if (e.keyboard.keyCode == SDL.KeyCode.Num1)
                    {
                        Window.Size = new Vector2(400, 400);
                    }
                    
                    if (e.keyboard.keyCode == SDL.KeyCode.Num2)
                    {
                        Window.Size = new Vector2(800, 600);
                    }
                    
                    if (e.keyboard.keyCode == SDL.KeyCode.R)
                    {
                        Window.Restore();
                    }
                }
                
                OnEvent(e);
            }
            
            OnUpdate();
            OnRender();
            
            // Frame Limit
            Time.AfterFrame();
        }
        
        internal void Quit()
        {
            // Quit Application
            if (!IsRunning) return;
            IsRunning = false;
            
            foreach(var module in GetModules().Reverse())
            {
                UnRegister(module);
            }
            
            SDL.Quit();
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
}