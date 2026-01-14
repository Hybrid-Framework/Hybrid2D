using Hybrid;

namespace App
{
    public class Game : Hybrid.App
    {
        private Texture texture;
        
        public override void OnInitialize()
        {
            texture = Texture.CreateTexture("Images/Image.png");
            texture.SetPixel(0, 0, new Color(1, 0, 0));
            texture.SetPixel(1, 0, new Color(0, 1, 0));
            texture.SetPixel(2, 0, new Color(0, 0, 1));
            texture.Apply();
            
            Debug.Log(texture.GetFormat());
        }

        public override void OnUpdate()
        {
            
        }

        public override void OnRender()
        {
            Graphics.DrawBegin(Color.Black);
            Graphics.DrawFps(10, 10, Color.White);
            Graphics.DrawTexture(texture, null);
            Graphics.DrawEnd();
        }
    }
}