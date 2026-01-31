using Hybrid;

namespace App
{
    public class Game : Hybrid.App
    {
        private Point[] velocities = new Point[count];
        private Color[] colors = new Color[count];
        private Rect[] rects = new Rect[count];
        private const int count = 256;
        

        public override void OnInitialize()
        {
            var rng = new System.Random();
            int h = Window.GetHeight();
            int w = Window.GetWidth();

            for (int i = 0; i < count; i++)
            {
                colors[i] = new Color
                {
                    r = (float)rng.NextDouble(),
                    g = (float)rng.NextDouble(),
                    b = (float)rng.NextDouble(),
                    a = 1,
                };

                rects[i] = new Rect
                {
                    x = rng.Next(0, w - 32),
                    y = rng.Next(0, h - 32),
                    width = 32,
                    height = 32,
                };

                velocities[i] = new Point()
                {
                    x = (float)(rng.NextDouble() * 200 - 100),
                    y = (float)(rng.NextDouble() * 200 - 100),
                };
            }
        }

        public override void OnUpdate()
        {
            float dt = Time.GetDeltaTime();
            int h = Window.GetHeight();
            int w = Window.GetWidth();

            for (int i = 0; i < count; i++)
            {
                rects[i].x += velocities[i].x * dt;
                rects[i].y += velocities[i].y * dt;

                if (rects[i].x < 0)
                {
                    rects[i].x = 0;
                    velocities[i].x *= -1;
                }
                else if (rects[i].x + rects[i].width > w)
                {
                    rects[i].x = w - rects[i].width;
                    velocities[i].x *= -1;
                }

                if (rects[i].y < 0)
                {
                    rects[i].y = 0;
                    velocities[i].y *= -1;
                }
                else if (rects[i].y + rects[i].height > h)
                {
                    rects[i].y = h - rects[i].height;
                    velocities[i].y *= -1;
                }
            }
        }

        public override void OnRender()
        {
            Graphics.DrawBegin(Color.Black);

            for (int i = 0; i < count; i++)
            {
                Graphics.DrawRectangle(rects[i], colors[i]);
            }

            Graphics.DrawFps(10, 10, Color.White);
            Graphics.DrawEnd();
        }
    }
}
