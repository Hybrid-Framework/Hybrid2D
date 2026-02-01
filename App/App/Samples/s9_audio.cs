// This is a simple program to show you how to get load and play audio
// Press SPACE on the keyboard to play the sound

using Hybrid;

namespace App
{
    public class s9_audio : Hybrid.App
    {
        private Audio audio;
        
        public override void OnInitialize()
        {
            audio = Audio.CreateAudio("Resources/Sounds/Sound.wav");
        }

        public override void OnUpdate()
        {
            if (Mouse.GetButtonDown(0))
            {
                Audio.Play(audio);
            }
            
            if (Touch.GetTouchDown(0))
            {
                Audio.Play(audio);
            }

            if (Keyboard.GetButtonDown(Key.Space))
            {
                Audio.Play(audio);
            }
            
            if (Gamepad.GetButtonDown(0, Button.South))
            {
                Audio.Play(audio);
            }
        }

        public override void OnRender()
        {
            Graphics.DrawBegin(Color.Black);
            Graphics.DrawFps(10, 10, Color.White);
            Graphics.DrawEnd();
        }
    }
}