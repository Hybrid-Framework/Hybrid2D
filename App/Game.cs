using System;
using Hybrid;

namespace App
{
    public class Game : Hybrid.Game
    {
        public override void OnInitialize()
        {
            Window.OnOrientation += orientation => Console.WriteLine(orientation);
            Window.OnMoved += position => Console.WriteLine(position);
            Window.OnResized += size => Console.WriteLine(size);
        }

        public override void OnUpdate()
        {
            foreach (var touch in Input.TouchScreen.GetTouches())
            {
                Console.WriteLine($"Touch: {touch.TouchID} Phase: {touch.X} {touch.Y}");
            }
        }

        public override void OnRender()
        {
            Graphics.ClearColor(Color.CornFlowerBlue);
            Graphics.DrawStats(Color.White);
            Graphics.Present();
        }
    }
}