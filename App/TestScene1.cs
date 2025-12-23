using Hybrid;

namespace App
{
    [Scene("Test Scene 1", index: 1)]
    public class TestScene1 : Scene
    {
        public override void OnSceneOpen()
        {
            GameObject gameObject = new GameObject("Obj");
        }

        public override void OnSceneClose()
        {
            
        }
    }
}