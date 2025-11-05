using Hybrid;

namespace App
{
    public class Scene : Hybrid.Scene
    {
        public override void OnOpened()
        {
            GameObject obj1 = new GameObject("Hello");
            obj1.AddComponent<Transform>();
            obj1.AddComponent<Transform>();
            obj1.AddComponent<Transform>();
            obj1.AddComponent<Transform>();
            obj1.RemoveComponents<Transform>();
        }

        public override void OnClosed()
        {
            
        }
    }
}