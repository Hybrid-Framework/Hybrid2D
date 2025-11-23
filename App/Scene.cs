using System;
using Hybrid;

namespace App
{
    public class Scene : Hybrid.Scene
    {
        public override void OnSceneOpen()
        {
            Window.OnOrientation += DisplayOrientation;
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