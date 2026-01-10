using Hybrid;

namespace App
{
    public class Game : Hybrid.App
    {
        private Audio audio;
        
        public override void OnInitialize()
        {
            Time.SetFps(60);

            audio = Audio.LoadAudio("Sounds/Sound.mp3");
            Audio.SetMasterVolume(1);
            Audio.SetAudioVolume(audio, 1f);
            Audio.PlayAudio(audio);
        }

        public override void OnUpdate()
        {
            if (Input.GetMouseButtonDown(MouseButton.Left))
            {
                Debug.Log("Down");
            }
            
            if (Input.GetMouseButton(MouseButton.Left))
            {
                Debug.Log("Press");
            }
            
            if (Input.GetMouseButtonUp(MouseButton.Left))
            {
                Debug.Log("Up");
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