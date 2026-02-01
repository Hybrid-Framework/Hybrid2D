// This is a simple program to show you how to get input from multiple touches

using Hybrid;

namespace App
{
    public class s8_touch : Hybrid.App
    {
        private const int MaxTouches = 10;
        private Point[] positions = new Point[MaxTouches];
        private bool[] pressed = new bool[MaxTouches];

        public override void OnUpdate()
        {
            for (int i = 0; i < MaxTouches; i++)
            {
                pressed[i] = Touch.GetTouch(i);
                positions[i] = Touch.GetTouchPosition(i);
            }
        }

        public override void OnRender()
        {
            Graphics.DrawBegin(Color.Black);

            for (int i = 0; i < MaxTouches; i++)
            {
                if (pressed[i])
                {
                    Graphics.DrawCircle(positions[i], 64, Color.Green);
                }
            }
            
            Graphics.DrawFps(10, 10, Color.White);
            Graphics.DrawEnd();
        }
    }
}