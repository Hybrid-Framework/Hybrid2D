using System;
using Hybrid;

namespace App
{
    public class Game : Hybrid.App
    {
        private Texture texture;
        private Audio audio;
        private Font font;
        
        public override void OnInitialize()
        {
            Window.SetTitle("Hello");

            texture = Texture.CreateTexture("Resources/Images/Image.png");
            audio = Audio.CreateAudio("Resources/Sounds/Sound.wav");
            font = Font.CreateFont("Resources/Fonts/Font1.ttf");
            
            Audio.PlayAudio(audio);
        }

        public override void OnUpdate()
        {
            if (Mouse.GetButtonDown(1))
            {
                Debug.Log("Mouse");
            }

            if (Keyboard.GetButtonDown(Key.A))
            {
                Debug.Log("Keyboard");
            }
        }

        public override void OnRender()
        {
            Graphics.DrawBegin(Color.Black);
            Graphics.DrawTexture(texture, null);
            Graphics.DrawText(font, "hello world", 10, 10, 128, Color.White);
            Graphics.DrawFps(10, 10, Color.White);
            Graphics.DrawEnd();
        }
    }
}