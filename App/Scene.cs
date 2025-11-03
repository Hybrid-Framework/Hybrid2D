using Hybrid;

namespace App
{
    public class Scene : Hybrid.Scene
    {
        public override void OnOpened()
        {
            GraphicsDevice.Resizable = true;
            GraphicsDevice.VSync = true;

            Hybrid.Object obj1 = new Hybrid.Object("Hello 1");
            Hybrid.Object obj2 = new Hybrid.Object();
            obj1.Destroy();
            obj2.Destroy();
        }

        public override void OnClosed()
        {
            
        }
    }
}