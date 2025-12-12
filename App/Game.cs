using Hybrid;

namespace App
{
    public class Game : Scene
    {
        public override void OnSceneOpen()
        {
            var transform = new GameObject("Parent").Transform;
            var child = new GameObject("Child").Transform;
            Object.Destroy(transform.GameObject);
        }

        public override void OnSceneClose()
        {
            
        }
    }
}