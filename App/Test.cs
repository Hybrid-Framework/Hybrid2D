using Hybrid;

namespace App
{
    [Scene("Test", index: 1)]
    public class Test : Scene
    {
        public override void OnSceneOpen()
        {
            GameObject gameObject = new GameObject("TestObj");
        }

        public override void OnSceneClose()
        {
            
        }
    }
}