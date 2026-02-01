// This is a simple program to show you how to get input from a touch

using Hybrid;

namespace App
{
    public class s8_touch : Hybrid.App
    {
        public override void OnInitialize()
        {
            // Initialize logic here
        }

        public override void OnUpdate()
        {
            // Update logic here
        }

        public override void OnRender()
        {
            // Render logic here
            Graphics.DrawBegin(Color.Black);
            Graphics.DrawFps(10, 10, Color.White);
            Graphics.DrawEnd();
        }
    }
}