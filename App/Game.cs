using System;
using Hybrid;

namespace App
{
    public class Game : Hybrid.Game
    {
        private readonly Color32 color = new Color32(255, 128, 128, 255);
        private readonly Rect[] rects = new Rect[100];
        private readonly Random random = new Random();
        
        public override void OnInitialize()
        {
            Application.TargetFrameRate = 60;

            for (int i = 0; i < 100; i++)
            {
                rects[i] = new Rect(random.Next(0, 600), random.Next(random.Next(0, 480)), 32, 32);
            }
        }

        public override void OnUpdate()
        {
            
        }

        public override void OnRender()
        {
            Graphics.Color(color);
            Graphics.Clear();
            
            Graphics.Color(new Color32(255, 255, 255, 255));
            Graphics.DrawRects(rects);
            
            Graphics.Present();
        }
    }
}