using Hybrid;

namespace App
{
    public class Scene : Hybrid.Scene
    {
        public override void OnOpened()
        {
            GameObject obj1 = new GameObject("Hello");
            Texture texture = Assets.Load<Texture>("Images/Image.png");
        }

        public override void OnClosed()
        {
            
        }
    }
}