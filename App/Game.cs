using Hybrid;

namespace App
{
    [Scene("Game", index: 0)]
    public class Game : Scene
    {
        public override void OnSceneOpen()
        {
            Application.TargetFrameRate = 60;
            
            GameObject gameObject = new GameObject();
            Object.Destroy(gameObject, 1.5f);
        }

        public override void OnSceneClose()
        {
            
        }
    }
}