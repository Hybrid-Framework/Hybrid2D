using Hybrid;

namespace App
{
    public class Game : Hybrid.Game
    {
        private Color background = new (100, 149, 237, 255);
        private Color text = new (255, 255, 255, 255);
        private Color black = new (0, 0, 0, 255);
        private Texture texture;
        private Texture texture2;
        
        
        public override void Initialize()
        {
            Window.Create(title: "Hybrid", width: 800, height: 600, fullscreen: false, resizable: true);
            Window.TargetFPS = 0;
            Window.VSync = true;

            texture = Content.Load<Texture>("Images/Image.jpg");
            texture2 = new Texture(256, 256, TextureAccess.Target, TextureScaleMode.Pixel);
            
            Color[] colors = new Color[texture2.Width * texture2.Height];
            for(int i=0; i<colors.Length; i++)
            {
                colors[i] = black;
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
            Graphics.ClearColor(background);
            
            Graphics.DrawTexture(texture, new Rect(0, 0, 128, 128));
            Graphics.DrawTexture(texture2, new Rect(128, 0, 128, 128));
            
            Graphics.DrawDebugStats(text);
            
            Graphics.Present();
        }
    }
}