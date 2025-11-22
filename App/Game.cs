using Hybrid;
using System;

namespace App
{
    public class Game : Hybrid.Game
    {
        public override void OnInitialize()
        {
            Console.WriteLine("Graphics: " + Window.GraphicsDriver);
            Console.WriteLine("System: " + Platform.System);
            Console.WriteLine("Device: " + Platform.Device);
            
            Debug.FileSystem();
        }

        public override void OnUpdate()
        {
            
        }

        public override void OnRender()
        {
            
        }
    }
}