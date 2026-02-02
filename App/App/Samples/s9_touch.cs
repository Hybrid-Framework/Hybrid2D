// This is a simple program to show you how to get input from multiple touches
// Use touch to display circles on the screen

using Hybrid;

namespace App
{
    public class s9_touch : Hybrid.App
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
            Graphics.DrawBegin(new Color(0, 0, 0));

            for (int i = 0; i < MaxTouches; i++)
            {
                if (pressed[i])
                {
                    Graphics.DrawCircle(positions[i], 64, new Color(0, 1, 0));
                }
            }
            
            Graphics.DrawFps(10, 10, new Color(1, 1, 1));
            Graphics.DrawEnd();
        }
    }
}