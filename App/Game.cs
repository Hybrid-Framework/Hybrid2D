using Hybrid;

namespace App
{
    public class Game : Hybrid.App
    {
        public override void OnInitialize()
        {
            Window.SetTitle("My Game!");
            Window.SetIcon("Icon.png");
            Window.SetVSync(true);

            var audio = Audio.CreateAudio("Sounds/Sound.mp3");
            Audio.SetMasterVolume(1);
            Audio.SetVolume(audio, 1f);
            Audio.Play(audio);
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