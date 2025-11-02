using Hybrid;

namespace App
{
    public class Scene : Hybrid.Scene
    {
        private Texture texture;
        private Texture texture2;
        

        public override void OnOpened()
        {
            GraphicsDevice.Resizable = true;
            GraphicsDevice.VSync = true;
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
            
            GraphicsDevice.DrawStats(Color.White);
            
            GraphicsDevice.Present();
        }
    }
}