using Hybrid;

namespace App
{
    public class Game : Hybrid.App
    {
        public Font font1;
        public Font font2;
        public Font font3;
        public Text text;
        
        public override void OnInitialize()
        {
            font1 = Font.CreateFont("Fonts/Font1.ttf");
            font2 = Font.CreateFont("Fonts/Font2.ttf");
            font3 = Font.CreateFont("Fonts/Font3.ttf");
            text = Text.CreateText(font1, "Hello World");
        }

        public override void OnUpdate()
        {
            if (Touch.GetTouch(0))
            {
                Debug.Log($"Touch 0: {Touch.GetTouchPosition(0).x}, {Touch.GetTouchPosition(0).y}");
            }
        }

        public override void OnRender()
        {
            Graphics.DrawBegin(Color.Black);
            Graphics.DrawText(text, new Rectangle(10, 0, 256, 48));
            Graphics.DrawEnd();
        }
    }
}