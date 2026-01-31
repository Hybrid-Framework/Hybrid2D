// This is a simple program to show you how to use delta time in your application

using Hybrid;

namespace App
{
    public class Game : Hybrid.App
    {
        private float speed = 40f;
        private float size = 128f;
        private Rect deltaRect;
        private Rect frameRect;
        
    
        public override void OnInitialize()
        {
            // Setup Delta Rect
            deltaRect = new Rect(0, 0, size, size);
            
            // Setup Frame Rect
            frameRect = new Rect(0, Window.GetHeight()-size, size, size);
        }

        public override void OnUpdate()
        {
            // Delta Rect is moving at a rate of speed by delta time which is consistent across different frame rates
            deltaRect.x += speed * Time.GetDeltaTime();
            
            // Frame Rect is moving at a constant based on frame rate
            frameRect.x += speed * 0.02f;

            // Wrap Delta Rect around
            if (deltaRect.x > Window.GetWidth()) deltaRect.x = 0 - size;
            
            // Wrap Frame Rect around
            if (frameRect.x > Window.GetWidth()) frameRect.x = 0 - size;
        }

        public override void OnRender()
        {
            // Begin
            Graphics.DrawBegin(Color.Black);
            
            // Draw Delta Rect
            Graphics.DrawRectangle(deltaRect, Color.Red);
            
            // Draw Frame Rect
            Graphics.DrawRectangle(frameRect, Color.Blue);
            
            // End
            Graphics.DrawFps(10, 10, Color.White);
            Graphics.DrawEnd();
        }
    }
}