using Hybrid;

namespace App
{
    public class Game : Scene
    {
        public override void OnSceneOpen()
        {
            var transform = new GameObject("Parent").Transform;
            var child = new GameObject("Child").Transform;
            child.SetParent(transform);
        }

        public override void OnSceneClose()
        {
            
        }
    }
}