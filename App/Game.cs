using Hybrid;

namespace App
{
    public class Game : Scene
    {
        public override void OnSceneOpen()
        {
            GameObject parent = new GameObject("Parent");
            GameObject child = new GameObject("child");
            
            var t1 = parent.AddComponent<TestComponent>();
            var t2 = parent.AddComponent<TestComponent>();

            foreach (var found in GameObject.FindObjectsByType<Object>())
            {
                Debug.Log(found);
            }
        }

        public override void OnSceneClose()
        {
            
        }
    }
}