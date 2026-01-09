using Hybrid;
using System;

namespace App
{
    public class Game : Hybrid.App
    {
        private const int count = 100;
        private Circle[] Circles = new Circle[count];
        private Color[] Colors = new Color[count];
        
        public override void OnInitialize()
        {
            Window.SetSize(new Vector2(800, 800));
            Window.SetVSync(false);

            Random random = new Random();
            
            for (int i = 0; i < count; i++)
            {
                Circles[i] = new Circle(random.Next(0, Window.GetWidth()), random.Next(0, Window.GetHeight()), random.Next(16, 32));
                Colors[i] = new Color
                (
                    (float)random.NextDouble(),
                    (float)random.NextDouble(),
                    (float)random.NextDouble(),
                    1f
                );
            }
        }

        public override void OnUpdate()
        {
            
        }

        public override void OnRender()
        {
            Graphics.DrawBegin(Color.Black);
            
            Graphics.DrawCircles(Circles, Colors, 256);
            
            Graphics.DrawFps(10, 10, Color.White);
            
            Graphics.DrawEnd();
        }
    }
}