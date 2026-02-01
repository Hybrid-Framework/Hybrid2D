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
            if (Keyboard.GetButtonDown(Key.Space))
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