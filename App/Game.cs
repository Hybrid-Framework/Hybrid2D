using Hybrid;

namespace App
{
    public class Game : Hybrid.Game
    {
        private Texture texture;
        private Texture texture2;
        
        public override void Initialize()
        {
            Window.Create(title: "Hybrid", width: 800, height: 600, fullscreen: false, resizable: true);
            Window.TargetFPS = 0;
            Window.VSync = true;
            
            texture = Content.Load<Texture>("Images/Image.jpg");
            
            texture.SetPixel(0,0, Color.Red);
            texture.SetPixel(1,0, Color.Green);
            texture.SetPixel(2,0, Color.Blue);
            texture.Apply();
            
            texture2 = new Texture(256, 256, TextureAccess.Static, TextureScaleMode.Pixel);
            
            Color[] colors = new Color[texture2.Width * texture2.Height];
            for(int i=0; i<colors.Length; i++)
            {
                colors[i] = Color.Magenta;
            }
            
            texture2.SetPixels(colors);
            texture2.Apply();
        }

        public override void Update()
        {
            // Update logic here
        }

        public override void Draw()
        {
            Graphics.ClearColor(Color.CornFlowerBlue);
            
            Graphics.DrawTexture(texture, new Rect(0, 0, 128, 128));
            
            Graphics.DrawTexture(texture2, new Rect(128, 0, 128, 128));
            
            Graphics.DrawDebugStats(Color.White);
            
            Graphics.Present();
        }
    }
}