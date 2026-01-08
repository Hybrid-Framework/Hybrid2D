using System;
using Hybrid;

namespace App
{
    public class Game : Hybrid.Application
    {
        public override void OnInitialize()
        {
            Time.SetFPS(60);
        }

        public override void OnUpdate()
        {
            
        }

        public override void OnRender()
        {
            Graphics.DrawColor(new Color32(255, 128, 128, 255));
            Graphics.DrawClear();
            
            Graphics.DrawColor(new Color32(255, 255, 255, 255));
            Graphics.DrawFPS(10, 10);
            
            Graphics.DrawPresent();
        }
    }
}