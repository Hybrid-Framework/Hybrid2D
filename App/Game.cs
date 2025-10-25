using Hybrid;

namespace App
{
    public class Game : Hybrid.Game
    {
        private Color background = new (100, 149, 237, 255);
        private Color text = new (255, 255, 255, 255);
        
        private AudioClip audioClip;
        private Texture texture;
        private Font font;
        
        
        public override void Initialize()
        {
            Window.Create(title: "Hybrid", width: 800, height: 600, fullscreen: false, resizable: true);
            Window.TargetFPS = 0;
            Window.VSync = true;

            audioClip = Content.Load<AudioClip>(FileSystem.assetPath + "Sound.mp3");
            texture = Content.Load<Texture>(FileSystem.assetPath + "Image.png");
            font = Content.Load<Font>(FileSystem.assetPath + "Font.ttf");
            
            Audio.Play(audioClip);
        }

        public override void Update()
        {
            // Update logic here
        }

        public override void Draw()
        {
            Graphics.ClearColor(background);
            
            Graphics.DrawTexture(texture, null);
            
            Graphics.DrawText(font, 20, 100, "Hello World", text);
            
            Graphics.DebugStats(text);
            
            Graphics.Present();
        }
    }
}