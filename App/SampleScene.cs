using Hybrid;

namespace App
{
    public class SampleScene : Scene
    {
        private Texture texture;
        private Texture texture2;
        

        public override void OnOpened()
        {
            GraphicsDevice.Resizable = true;
            GraphicsDevice.VSync = true;
            
            texture = Content.Load<Texture>("Images/Image.jpg");
            
            texture.SetPixel(0,0, Color.Red);
            texture.SetPixel(1,0, Color.Green);
            texture.SetPixel(2,0, Color.Blue);
            texture.Apply();
            
            texture2 = new Texture(16, 16, TextureAccess.Static, TextureScaleMode.Pixel);
            
            Color[] colors = new Color[texture2.Width * texture2.Height];
            for(int i=0; i<colors.Length; i++)
            {
                colors[i] = Color.Magenta;
            }
            
            texture2.SetPixels(colors);
            
            texture2.SetPixel(0,0, Color.Red);
            texture2.SetPixel(1,0, Color.Green);
            texture2.SetPixel(2,0, Color.Blue);
            
            texture2.Apply();
        }

        public override void OnClosed()
        {
            
        }

        public override void Update()
        {
            
        }

        public override void Draw()
        {
            GraphicsDevice.ClearColor(Color.CornFlowerBlue);
            
            GraphicsDevice.DrawTexture(texture, new Rect(0, 0, 128, 128));
            
            GraphicsDevice.DrawTexture(texture2, new Rect(128, 0, 128, 128));
            
            GraphicsDevice.DrawStats(Color.White);
            
            GraphicsDevice.Present();
        }
    }
}