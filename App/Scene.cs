using Hybrid;

namespace App
{
    public class Scene : Hybrid.Scene
    {
        public override void OnOpened()
        {
            GameObject obj1 = new GameObject("Hello");
            GameObject obj2 = Object.Instantiate(obj1);
        }

        public override void OnClosed()
        {
            
        }
    }
}