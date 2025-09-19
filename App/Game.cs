using Hybrid;

namespace App
{
    public class Game : Behaviour
    {
        public override void Init()
        {
            Window.CreateWindow("Hybrid", 800, 600);
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