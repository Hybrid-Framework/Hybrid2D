using Hybrid;

namespace App
{
    public class Game : Hybrid.App
    {
        private Wave wave;
        private Texture texture;
        
        public override void OnInitialize()
        {
            Window.SetTitle("My window");
            Window.SetIcon("Icon.png");

            wave = Audio.CreateWave(200, 0.25f);
            Audio.SetWavePitch(wave, 1.2f);
            Audio.PlayWave(wave);

            texture = Texture.CreateTexture("Images/Image.png");
            texture.SetPixel(0, 0, new Color(1, 0, 0));
            texture.Apply();
        }

        public override void OnUpdate()
        {
            Audio.SetWavePitch(wave, Maths.PingPong(Time.GetTime(), 0.5f, 1.5f));
            
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
            Graphics.DrawTexture(texture, null);
            Graphics.DrawEnd();
        }
    }
}