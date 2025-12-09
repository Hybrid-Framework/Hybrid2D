using Hybrid;

namespace App
{
    public class Game : Scene
    {
        public override void OnSceneOpen()
        {
            GameObject obj1 = new GameObject("Object 1");
            GameObject obj2 = new GameObject("Object 2");
            obj2.Transform.SetParent(obj1.Transform);

            Debug.Log($"FOUND: {obj1.Transform.Find("Object 2")?.Name}");
        }

        public override void OnSceneClose()
        {
            
        }
    }
}