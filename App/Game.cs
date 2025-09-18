using Hybrid;

namespace App
{
    public class Game : GameBehaviour
    {
        public override void Init()
        {
            Window.CreateWindow("Hello World", 800, 600);
        }
        
        public override void Update()
        {
            // Here
        }
        
        public override void Render()
        {
            Graphics.ClearColor(255, 128, 128, 128);
            Graphics.Begin();
            Graphics.End();
        }
    }
}