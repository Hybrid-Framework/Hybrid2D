using System;
using Hybrid;

namespace App
{
    public class Game : Hybrid.Game
    {
        public override void OnInitialize()
        {
            var sound1 = Content.Load<Sound>("Sounds/Sound.mp3");
            sound1.Dispose();
            
            var sound2 = Content.Load<Sound>("Sounds/Sound.mp3");
            Audio.Play(sound2);
        }

        public override void OnUpdate()
        {
            
        }

        public override void OnRender()
        {
            Graphics.ClearColor(Color.CornFlowerBlue);
            Graphics.DrawStats(Color.White);
            Graphics.Present();
        }
    }
}