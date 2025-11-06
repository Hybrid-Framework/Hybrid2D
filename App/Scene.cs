using System;
using Hybrid;

namespace App
{
    public class Scene : Hybrid.Scene
    {
        private Texture texture1;
        private Texture texture2;
        
        public override void OnOpened()
        {
            Window.Title = "Hello World!";

            var resource = Resources.Load<TextureResource>("Images/Image.png");
            
            texture1 = new Texture(resource);
            texture2 = new Texture(resource);
            
            texture1.SetPixel(0,0, Color.Red);
            texture1.SetPixel(1,0, Color.Green);
            texture1.SetPixel(2,0, Color.Blue);
            texture1.Apply();
        }

        public override void OnUpdate()
        {
            
        }

        public override void OnRender()
        {
            Graphics.ClearColor(Color.CornFlowerBlue);
            Graphics.DrawStats(Color.White);
            
            Graphics.DrawTexture(texture2, null);
            
            Graphics.Present();
        }

        public override void OnClosed()
        {
            
        }
    }
}