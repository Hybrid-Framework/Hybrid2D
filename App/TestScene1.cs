using Hybrid;

namespace App
{
    [Scene("Test Scene 1", index: 1)]
    public class TestScene1 : Scene
    {
        public override void OnSceneOpen()
        {
            Application.TargetFrameRate = 60;
        }

        public override void OnSceneClose()
        {
            
        }
    }
}