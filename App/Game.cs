using Hybrid;

namespace App
{
    public class Game : GameBehaviour
    {
        public override void Init()
        {
            // Init Logic
            Window.Create(title: "Hybrid", width: 800, height: 600, fullscreen: false, resizable: true);
        }

        public override void Update()
        {
            // Update Logic
        }

        public override void Draw()
        {
            Graphics.Clear(Color.Salmon);
            
            // Draw Logic
            
            Graphics.Present();
        }
    }
}