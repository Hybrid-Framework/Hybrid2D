// This is a simple program to open & clear the window and also draw the frame rate

using Hybrid;

namespace App
{
    public class Game : Hybrid.App
    {
        public override void OnInitialize()
        {
        
        }

        public override void OnUpdate()
        {
        
        }

        public override void OnRender()
        {
            Graphics.DrawBegin(Color.White);
            Graphics.DrawFps(10, 10, Color.Black);
            Graphics.DrawEnd();
        }
    }
}