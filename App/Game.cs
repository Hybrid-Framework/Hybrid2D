using Hybrid;

namespace App
{
    public class Game : Hybrid.App
    {
        private Font font1;
        private Font font2;
        private Font font3;
        
        public override void OnInitialize()
        {
            font1 = Font.CreateFont("Fonts/Font1.ttf");
            font2 = Font.CreateFont("Fonts/Font2.ttf");
            font3 = Font.CreateFont("Fonts/Font3.ttf");
        }

        public override void OnUpdate()
        {
            
        }

        public override void OnRender()
        {
            Graphics.DrawBegin(Color.Black);
            
            Graphics.DrawText(font1, Time.GetFps().ToString("N0"), 10, 0, 32, Color.White);
            
            Graphics.DrawEnd();
        }
    }
}