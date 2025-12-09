using Hybrid;

namespace App
{
    public class Game : Scene
    {
        public override void OnSceneOpen()
        {
            GameObject obj1 = new GameObject("Object 1");
            GameObject obj2 = new GameObject("Object 1");
            GameObject obj3 = new GameObject("Object 3");

            foreach (var found in GameObject.FindObjectsOfType<Component>())
            {
                Debug.Log("Found: " + found.Name + " " + found);
            }
        }

        public override void OnSceneClose()
        {
            
        }
    }
}