using System;
using Hybrid;
using Object = Hybrid.Object;

namespace App
{
    public class Scene : Hybrid.Scene
    {
        public override void OnOpened()
        {
            Window.Title = "Hello World!";
            GameObject obj1 = new GameObject("Hello World");
            Texture texture = new Texture(16, 16);
        }

        public override void OnClosed()
        {
            
        }
    }
}