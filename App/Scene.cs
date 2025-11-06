using System;
using Hybrid;

namespace App
{
    public class Scene : Hybrid.Scene
    {
        private Texture texture1;
        private Texture texture2;
        private Texture texture3;
        
        public override void OnOpened()
        {
            Window.Title = "Hello World!";
            
            texture1 = Assets.Load<Texture>("Images/Image.png");
            texture2 = Assets.Load<Texture>("Images/Image.png");
            texture3 = new Texture(texture1);
            
            texture1.SetPixel(0,0, Color.Red);
            texture1.SetPixel(1,0, Color.Green);
            texture1.SetPixel(2,0, Color.Blue);
            texture1.Apply();
            
            Graphics.ClearColor(Color.CornFlowerBlue);
            Graphics.DrawTexture(texture3);
            Graphics.Present();
        }

        public override void OnClosed()
        {
            
        }
    }
}