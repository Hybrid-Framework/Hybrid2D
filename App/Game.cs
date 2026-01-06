using System;
using Hybrid;

namespace App
{
    public class Game : Hybrid.Game
    {
        private readonly Color32 color = new Color32(255, 128, 128, 255);
        private readonly Color32 pixel = new Color32(0, 0, 128, 255);
        private readonly Rect[] rects = new Rect[100];
        private readonly Random random = new Random();
        private Texture texture;
        
        public override void OnInitialize()
        {
            Application.TargetFrameRate = 60;
            texture = new Texture(16, 16);
            for (int x = 0; x < 16; x++)
            {
                for (int y = 0; y < 16; y++)
                {
                    texture.SetPixel(x, y, pixel);
                }
            }
            texture.Apply();

            for (int i = 0; i < 100; i++)
            {
                rects[i] = new Rect(random.Next(0, 600), random.Next(random.Next(0, 480)), 32, 32);
            }
            
            Window.SetResizable(true);
        }

        public override void OnUpdate()
        {
            if (Input.GetKeyboardButtonDown(KeyboardButton.F))
            {
                Window.SetFullscreen(!Window.GetFullscreen());
            }
            
            if (Input.GetKeyboardButtonDown(KeyboardButton.M))
            {
                Window.SetMaximized(!Window.GetMaximized());
            }
        }

        public override void OnRender()
        {
            Graphics.Color(color);
            Graphics.Clear();
            
            Graphics.Color(new Color32(255, 255, 255, 255));
            Graphics.DrawTexture(texture, new Rect(0, 0, texture.Width, texture.Height), rects[0]);
            
            Graphics.Present();
        }
    }
}