using System;
using Hybrid;

namespace App
{
    public class Game : Hybrid.Game
    {
        private Texture Texture;
        
        public override void OnInitialize()
        {
            Texture = Content.Load<Texture>("Images/Image.png");
        }

        public override void OnUpdate()
        {
            
        }

        public override void OnRender()
        {
            Graphics.ClearColor(Color.CornFlowerBlue);
            Graphics.DrawTexture(Texture);
            Graphics.DrawStats(Color.White);
            Graphics.Present();
        }
    }
}