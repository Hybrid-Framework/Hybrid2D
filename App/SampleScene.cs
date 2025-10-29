using Hybrid;
using Object = Hybrid.Object;

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

            Object obj1 = new Object();
            Object obj2 = Object.Instantiate(obj1);
            
            obj1.Destroy();
            
            Console.WriteLine($"Match: {obj1 == obj1}");
            Console.WriteLine($"Compare: {obj1 == obj2}");
            Console.WriteLine($"Obj1 Null: {obj1 == null}");
            Console.WriteLine($"Obj2 Null: {obj2 == null}");
            
            Console.WriteLine($"Match: {obj2.Equals(obj1)}");
            Console.WriteLine($"Compare: {obj1.Equals(obj2)}");
            Console.WriteLine($"Obj1 Null: {obj1.Equals(null)}");
            Console.WriteLine($"Obj2 Null: {obj2.Equals(null)}");
            
            Console.WriteLine($"Obj1 Bool: {(bool)!obj1}");
            Console.WriteLine($"Obj2 Bool: {(bool)obj2}");
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