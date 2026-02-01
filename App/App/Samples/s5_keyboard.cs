// This is a simple program to show you how to get input from the keyboard

using Hybrid;

namespace App
{
    public class s5_keyboard : Hybrid.App
    {
        private float speed = 100;
        private Rect rect;

        public override void OnInitialize()
        {
            rect = new Rect(Window.GetWidth() / 2, Window.GetHeight() / 2, 128, 128);
        }

        public override void OnUpdate()
        {
            if (Keyboard.GetButton(Key.W))
            {
                rect.y -= speed * Time.GetDeltaTime();
            }
            
            if (Keyboard.GetButton(Key.S))
            {
                rect.y += speed * Time.GetDeltaTime();
            }
            
            if (Keyboard.GetButton(Key.A))
            {
                rect.x -= speed * Time.GetDeltaTime();
            }
            
            if (Keyboard.GetButton(Key.D))
            {
                rect.x += speed * Time.GetDeltaTime();
            }
            
            rect.x = Maths.Clamp(rect.x, 0, Window.GetWidth() - rect.width);
            rect.y = Maths.Clamp(rect.y, 0, Window.GetHeight() - rect.height);
        }

        public override void OnRender()
        {
            Graphics.DrawBegin(Color.Black);
            Graphics.DrawRectangle(rect, Color.Red);
            Graphics.DrawFps(10, 10, Color.White);
            Graphics.DrawEnd();
        }
    }
}