using System;

namespace Hybrid
{
    // Engine
    internal unsafe partial class Engine
    {
        internal static GraphicsDevice GraphicsDevice { get; private set; }
        
        internal bool Initialized { get; private set; }
        internal bool IsRunning { get; private set; }
        
        internal Config Config { get; }
        
        internal Engine(Config config)
        {
            Config = config;
        }
    }
    
    // Engine Core
    internal unsafe partial class Engine
    {
        private SDL.Texture* Texture;
        
        
        // Engine Initialize
        internal void Initialize()
        {
            // Initialize
            if (Initialized) return;
            Initialized = true;
            IsRunning = true;

            // Modules
            GraphicsDevice = new GraphicsDevice(Config);
            Texture = SDL_image.LoadTexture(GraphicsDevice.Renderer, SDL.GetBasePath() + "Images/Image.png");
            SDL.SetTextureScaleMode(Texture, SDL.ScaleMode.Pixel);
            
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
            // Quit Application
            if(!IsRunning) return;
            IsRunning = false;
            
            // Quit
            SDL.Quit();
        }
    }
    
    // Engine Initialize
    internal unsafe partial class Engine
    {
        internal void OnInitialize()
        {
            // Initialize Game
            Config.Game.OnInitialize();
        }
    }
    
    // Engine Events
    internal unsafe partial class Engine
    {
        internal void OnEvent()
        {
            while (SDL.PollEvent(out SDL.Event e))
            {
                // Quit Application
                if (e.type == SDL.EventType.Quit)
                {
                    Quit();
                    return;
                }
            }
        }
    }
    
    // Engine Update
    internal unsafe partial class Engine
    {
        internal void OnUpdate()
        {
            // Update Game
            Config.Game.OnUpdate();
        }
    }
    
    // Engine Render
    internal unsafe partial class Engine
    {
        internal void OnRender()
        {
            SDL.SetRenderDrawColor(GraphicsDevice.Renderer, 255, 128, 128, 255);
            SDL.RenderClear(GraphicsDevice.Renderer);
            
            // Render Game
            Config.Game.OnRender();

            SDL.RenderTexture(GraphicsDevice.Renderer, Texture, null, null);

            SDL.RenderDebugText(GraphicsDevice.Renderer, 10, 10, "Graphics: " + GraphicsDevice.GraphicsDriver);
            SDL.RenderDebugText(GraphicsDevice.Renderer, 10, 20, "System: " + Platform.System);
            SDL.RenderDebugText(GraphicsDevice.Renderer, 10, 30, "Device: " + Platform.Device);
            
            SDL.RenderPresent(GraphicsDevice.Renderer);
        }
    }
}