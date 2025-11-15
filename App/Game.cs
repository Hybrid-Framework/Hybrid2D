using System;
using Hybrid;

namespace App
{
    public class Game : Hybrid.Game
    {
        private Texture texture;
        public override void OnInitialize()
        {
            texture = new Texture(16, 16);

            for (int x = 0; x < texture.Width; x++)
            {
                for (int y = 0; y < texture.Height; y++)
                {
                    texture.SetPixel(x, y, Color.Purple);
                }
            }
            texture.Apply();
            
            texture.Dispose();
            
            
        }

        public override void OnUpdate()
        {
            
        }

        public override void OnRender()
        {
            Graphics.ClearColor(Color.CornFlowerBlue);
            Graphics.DrawStats(Color.White);
            Graphics.DrawTexture(texture);
            Graphics.Present();
        }
    }
}