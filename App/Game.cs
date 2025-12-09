using Hybrid;

namespace App
{
    public class Game : Scene
    {
        public override void OnSceneOpen()
        {
            GameObject parent = new GameObject("Parent");

            Debug.Log(parent);
            Debug.Log(parent.Name);
            Debug.Log(parent.Transform.GameObject.Transform.GameObject.Name);
            Debug.Log(parent.GameObject.Transform.GameObject.Name);
        }

        public override void OnSceneClose()
        {
            
        }
    }
}