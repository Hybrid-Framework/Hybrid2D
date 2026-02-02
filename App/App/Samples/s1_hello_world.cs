// This is a simple program to show you how to start using hybrid
// Window, Graphics, Audio creation is automatically handled

using Hybrid;

namespace App
{
    public class s1_hello_world : Hybrid.App
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
            Graphics.DrawBegin(new Color(0, 0, 0));
            Graphics.DrawFps(10, 10, new Color(1, 1, 1));
            Graphics.DrawEnd();
        }
    }
}