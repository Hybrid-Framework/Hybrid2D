using System;
using Hybrid;

namespace App
{
    public class Game : Hybrid.App
    {
        private Triangle[] Triangles = new Triangle[Count];
        private Color[] Colors = new Color[Count];
        private Random RNG = new Random();
        private const int Count = 16000;
        
        public override void OnInitialize()
        {
            int width = Window.GetWidth();
            int height = Window.GetHeight();

            for (int i = 0; i < Count; i++)
            {
                // Random base position
                var basePos = new Point(RNG.Next(width), RNG.Next(height));

                // Random small offsets for triangle points
                float offset1X = RNG.Next(-20, 20);
                float offset1Y = RNG.Next(-20, 20);
                float offset2X = RNG.Next(-20, 20);
                float offset2Y = RNG.Next(-20, 20);
                float offset3X = RNG.Next(-20, 20);
                float offset3Y = RNG.Next(-20, 20);

                Triangles[i] = new Triangle
                (
                    new Point(basePos.x + offset1X, basePos.y + offset1Y),
                    new Point(basePos.x + offset2X, basePos.y + offset2Y),
                    new Point(basePos.x + offset3X, basePos.y + offset3Y)
                );

                Colors[i] = new Color
                {
                    r = (float)RNG.NextDouble(),
                    g = (float)RNG.NextDouble(),
                    b = (float)RNG.NextDouble(),
                };
            }
        }

        public override void OnUpdate()
        {
            
        }

        public override void OnRender()
        {
            Graphics.DrawBegin(Color.Black);
            
            Graphics.DrawTriangles(Triangles, Colors);
            
            Graphics.DrawFps(10, 10, Color.White);
            
            Graphics.DrawEnd();
        }
    }
}