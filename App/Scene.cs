using System;
using Hybrid;

namespace App
{
    public class Scene : Hybrid.Scene
    {
        public override void OnSceneOpen()
        {
            Window.OnResized += DisplayResize;
            Window.OnOrientation += DisplayOrientation;
        }
        
        private void DisplayResize(Vector2 size)
        {
            Console.WriteLine($"Resized: ({size.X} {size.Y})");
        }

        private void DisplayOrientation(Orientation orientation)
        {
            Console.WriteLine($"Orientation: {orientation}");
        }

        public override void OnSceneClose()
        {
            
        }
    }
}