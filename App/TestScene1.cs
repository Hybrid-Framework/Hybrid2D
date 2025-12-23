using Hybrid;

namespace App
{
    [Scene("Test Scene 1", index: 1)]
    public class TestScene1 : Scene
    {
        public override void OnSceneOpen()
        {
            Application.TargetFrameRate = 60;
            
            GameObject gameObject = new GameObject("Obj");
            gameObject.Tag = Tags.CreateTag("Hello");
            
            Debug.Log(gameObject.Tag);
            
            Tags.DeleteTag("Hello");
            
            Debug.Log(gameObject.Tag);
        }

        public override void OnSceneClose()
        {
            
        }
    }
}