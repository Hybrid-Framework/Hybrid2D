using Hybrid;

namespace App
{
    [Scene("Game", index: 0)]
    public class GameScene : Scene
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