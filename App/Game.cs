using Hybrid;

namespace App
{
    public class Game : Scene
    {
        public override void OnSceneOpen()
        {
            GameObject parent = new GameObject("Parent");
            GameObject child = new GameObject("child");
            child.Transform.SetParent(parent.Transform);
            parent.AddComponent<Player>();
            
            child.BroadcastMessageUpwards("Hello", 2, SendMessageOptions.DontRequireReceiver);
        }

        public override void OnSceneClose()
        {
            
        }
    }
}