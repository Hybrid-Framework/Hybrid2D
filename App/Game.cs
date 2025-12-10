using Hybrid;

namespace App
{
    public class Game : Scene
    {
        public override void OnSceneOpen()
        {
            Transform parent = new GameObject("ParentObj").Transform;
            Transform child = new GameObject("ChildObj").Transform;
        }

        public override void OnSceneClose()
        {
            
        }
    }
}