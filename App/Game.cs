using System;
using Hybrid;

namespace App
{
    public class Game : Hybrid.Game
    {
        private Font Font;
        private Sound Sound;
        
        public override void OnInitialize()
        {
            Sound = Content.Load<Sound>("Sounds/Sound.wav");
            Font = Content.Load<Font>("Fonts/Font.ttf");
            
            Audio.Play(Sound);
        }

        public override void OnUpdate()
        {
            
        }

        public override void OnRender()
        {
            Graphics.ClearColor(Color.CornFlowerBlue);
            Graphics.DrawText(Font, $"{(int)Time.Fps}", 20, 0, Color.White);
            Graphics.Present();
        }
    }
}