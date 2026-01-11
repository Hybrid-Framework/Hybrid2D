using Hybrid;

namespace App
{
    public class Game : Hybrid.App
    {
        private Audio audio;
        private Texture texture;
        
        public override void OnInitialize()
        {
            Time.SetFps(60);

            audio = Audio.Create("Sounds/Sound.mp3");
            audio.SetVolume(1f);
            audio.Play();

            texture = Texture.Create("Images/Image.png");
            texture.SetPixel(0, 0, new Color(1, 0, 0));
            texture.SetPixel(1, 0, new Color(0, 1, 0));
            texture.SetPixel(2, 0, new Color(0, 0, 1));
            texture.Apply();
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
            
            Graphics.DrawTexture(texture, null, new Rect() { X=0, Y=0, W=128, H=128 });
            
            Graphics.DrawEnd();
        }
    }
}