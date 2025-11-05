using Hybrid;

namespace App
{
    public class Scene : Hybrid.Scene
    {
        public override void OnOpened()
        {
            GameObject obj1 = new GameObject("Hello World");
            var transform = obj1.GetComponent<Transform>();
            Object.Destroy(transform);
        }

        public override void OnClosed()
        {
            
        }
    }
}