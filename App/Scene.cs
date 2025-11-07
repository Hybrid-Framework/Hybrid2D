using Hybrid;

namespace App
{
    public class Scene : Hybrid.Scene
    {
        public override void OnOpened()
        {
            GameObject obj1 = new GameObject("Hello");
        }

        public override void OnClosed()
        {
            
        }
    }
}