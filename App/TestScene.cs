using Hybrid;

namespace App
{
    [Scene("Test", index: 1)]
    public class TestScene : Scene
    {
        public override void OnSceneOpen()
        {
            Debug.Log(Scenes.GetActiveScene().GetRootGameObjects().Count);
        }

        public override void OnSceneClose()
        {
            
        }
    }
}