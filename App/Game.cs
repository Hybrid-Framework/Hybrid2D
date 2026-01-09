using Hybrid;
using System;

namespace App
{
    public class Game : Hybrid.App
    {
        private Texture texture;
        
        public override void OnInitialize()
        {
            texture = Texture.Create("Images/Image.png");
            Texture.SetPixel(texture, 0, 0, Color.Red);
            Texture.SetPixel(texture, 1, 0, Color.Green);
            Texture.SetPixel(texture, 2, 0, Color.Blue);
            Texture.Apply(texture);
        }

        public override void OnUpdate()
        {
            
        }

        public override void OnRender()
        {
            Graphics.DrawBegin(Color.Black);
            
            Graphics.DrawFps(10, 10, Color.White);
            
            Graphics.DrawTexture(texture, null, null);
            
            Graphics.DrawEnd();
        }
    }
}