using Hybrid;

namespace App
{
    [Scene("Test Scene 1", index: 1)]
    public class TestScene1 : Scene
    {
        public override void OnSceneOpen()
        {
            Application.TargetFrameRate = 30;
            
            GameObject gameObject = new GameObject("Inputs");
            gameObject.AddComponent<Inputs>();
        }

        public override void OnSceneClose()
        {
            
        }
    }
}