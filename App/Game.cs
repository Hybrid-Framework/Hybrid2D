using Hybrid;

namespace App
{
    public class Game : Hybrid.App
    {
        private Sound _sound;
        
        public override void OnInitialize()
        {
            Window.SetTitle("My window");
            Window.SetIcon("Icon.png");

            _sound = Sound.CreateAudio(445, 0.5f);
            Sound.SetPitch(_sound, 1.2f);
            Sound.Play(_sound);
        }

        public override void OnUpdate()
        {
            Sound.SetPitch(_sound, Maths.PingPong(Time.GetTime(), 0.5f, 1.5f));
            
            if (Input.GetMouseButtonDown(MouseButton.Left))
            {
                Debug.Log("Pressed mouse");
            }
        }

        public override void OnRender()
        {
            Graphics.DrawBegin(Color.Black);
            Graphics.DrawFps(10, 10, Color.White);
            
            float[] positions =
            {
                300f, 0f,
                600, 400f,
                0f, 400f
            };
            
            Color[] colors =
            {
                Color.Red,
                Color.Green,
                Color.Blue
            };
            
            int[] indices =
            {
                0, 1, 2
            };
            
            Graphics.DrawGeometry(positions, colors, indices);
            Graphics.DrawEnd();
        }
    }
}