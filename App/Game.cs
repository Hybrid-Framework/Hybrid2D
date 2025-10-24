using Hybrid;

namespace App
{
    public class Game : Hybrid.Game
    {
        Color text = new (255, 255, 255, 255);
        Color background = new (100, 149, 237, 255);
        
        public override void Initialize()
        {
            Window.Create(title: "Hybrid", width: 800, height: 600, fullscreen: false, resizable: true);
            Window.TargetFPS = 0;
            Window.VSync = true;
        }

        public override void Update()
        {
            // Update logic here
        }

        public override void Draw()
        {
            Graphics.ClearColor(background);
            
            Graphics.DebugStats(text);
            
            Graphics.Present();
        }
    }
}