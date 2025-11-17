using System;

namespace Hybrid
{
    // Engine
    internal partial class Engine
    {
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
        private SDL.Window* window;
        private SDL.Renderer* renderer;
        private SDL.Texture* texture;
        
        // Engine Initialize
        internal void Initialize()
        {
            // Initialize
            if (Initialized) return;
            Initialized = true;
            IsRunning = true;
            
            // Temp Window For Testing
            SDL.WindowFlags flags = SDL.WindowFlags.HighPixelDensity;
            
            if (Platform.Current.PlatformDevice == PlatformDevice.Mobile)
            {
                flags |= SDL.WindowFlags.Fullscreen | SDL.WindowFlags.Resizable;
            }
            
            window = SDL.CreateWindow("test", 600, 600, flags);
            renderer = SDL.CreateRenderer(window, null);

            Debug.Files();
            
            texture = SDL_image.LoadTexture(renderer, Path.Combine(SDL.GetBasePath(), "Images/Image.png"));
            
            if (texture == null)
                Console.WriteLine("Failed to load texture: " + SDL.GetError());
            
            SDL.SetTextureScaleMode(texture, SDL.ScaleMode.Pixel);
            
            var icon = SDL_image.Load(Path.Combine(SDL.GetBasePath(), "Icon.png"));
            
            if (icon == null)
                Console.WriteLine("Failed to load icon: " + SDL.GetError());
            
            if (!SDL.SetWindowIcon(window, icon))
                Console.WriteLine("Failed to set icon: " + SDL.GetError());
            
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
    
    // Engine Events
    internal partial class Engine
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
    internal unsafe partial class Engine
    {
        internal void OnRender()
        {
            SDL.SetRenderDrawColor(renderer, 255, 128, 128, 255);
            SDL.RenderClear(renderer);
            SDL.RenderTexture(renderer, texture, null, null);
            SDL.RenderPresent(renderer);
            
            // Render Game
            Config.Game.OnRender();
        }
    }
}