using Hybrid;

namespace App
{
    public class Game : Hybrid.Game
    {
        public override void OnStart()
        {
            
        }

        public override void OnUpdate()
        {
            
        }

        public override void OnRender()
        {
            Graphics.ClearColor(Color.CornFlowerBlue);
            Graphics.DrawStats(Color.White);
            Graphics.Present();
        }
    }
}