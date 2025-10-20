using Hybrid;

namespace App
{
    public class Game : GameBehaviour
    {
        public override void Init()
        {
            Window.Create(title: "Hybrid", width: 800, height: 600, fullscreen: false, resizable: true, borderless: false);
        }

        public override void Update()
        {
            
        }

        public override void Draw()
        {
            Graphics.Clear(Color.Salmon);
            
            Graphics.Present();
        }
    }
}