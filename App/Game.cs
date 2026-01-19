using System;
using Hybrid;

namespace App
{
    public class Game : Hybrid.App
    {
        public override void OnInitialize()
        {
            Window.SetTitle("Hello");
            
            var sound = Audio.CreateAudio("Sounds/Sound.wav");
            Audio.PlayAudio(sound);
        }

        public override void OnUpdate()
        {
            
        }

        public override void OnRender()
        {
            Graphics.DrawBegin(Color.Black);
            Graphics.DrawFps(10, 10, Color.White);
            Graphics.DrawEnd();
        }
    }
}