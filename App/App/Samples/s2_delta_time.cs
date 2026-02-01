// This is a simple program to show you how to use delta time

using Hybrid;

namespace App
{
    public class s2_delta_time : Hybrid.App
    {
        private float speed = 40f;
        private float size = 128f;
        private Rect deltaRect;
        private Rect frameRect;
        
    
        public override void OnInitialize()
        {
            deltaRect = new Rect(0, 0, size, size);
            frameRect = new Rect(0, Window.GetHeight()-size, size, size);
        }

        public override void OnUpdate()
        {
            deltaRect.x += speed * Time.GetDeltaTime();
            frameRect.x += speed * 0.02f;

            if (deltaRect.x > Window.GetWidth()) deltaRect.x = 0 - size;
            if (frameRect.x > Window.GetWidth()) frameRect.x = 0 - size;
        }

        public override void OnRender()
        {
            Graphics.DrawBegin(Color.Black);
            Graphics.DrawRectangle(deltaRect, Color.Red);
            Graphics.DrawRectangle(frameRect, Color.Blue);
            Graphics.DrawFps(10, 10, Color.White);
            Graphics.DrawEnd();
        }
    }
}