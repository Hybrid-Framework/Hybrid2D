using static Engine.SDL2.SDL;
using Engine;

namespace App
{
    public class Game : GameBehaviour
    {
        public override void Init()
        {
            Console.WriteLine("Platform Init");
            // Window.Create(Hello World, 1280, 768);
            // Window.isFullscreen = false;
            // Window.vsync = false;
            // Window.fps = 60;
        }
        
        public override void Update()
        {
            Console.WriteLine("Platform Update");
            // Input.GetKeyDown(Key.Space);
        }
        
        public override void Render()
        {
            Console.WriteLine("Platform Render");
            // Graphics.Begin();
            
            // Graphics.DrawSprite(10, 10, name);
            
            // Graphics.End();
        }
    }
}