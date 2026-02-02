// This is a simple program to show you how to get input from the mouse
// Use the mouse to move the circle around and click to change the color

using Hybrid;

namespace App
{
    public class s8_mouse : Hybrid.App
    {
        private Point position;
        private bool pressed;

        public override void OnUpdate()
        {
            pressed = Mouse.GetButton(0) || Mouse.GetButton(1) || Mouse.GetButton(2);
            position = Mouse.GetPositon();
        }

        public override void OnRender()
        {
            Graphics.DrawBegin(new Color(0, 0, 0));
            Graphics.DrawCircle(position, 64, pressed ? new Color(0, 1, 0) : new Color(1, 0, 0));
            Graphics.DrawFps(10, 10, new Color(1, 1, 1));
            Graphics.DrawEnd();
        }
    }
}