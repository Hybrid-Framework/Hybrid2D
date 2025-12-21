using Hybrid;

namespace App
{
    [Scene("Game", index: 0)]
    public class Game : Scene
    {
        public override void OnSceneOpen()
        {
            GameObject gameObject = new GameObject();
            Object.DontDestroyOnLoad(gameObject);
            
            Scenes.LoadScene(1, LoadSceneMode.Single);
        }

        public override void OnSceneClose()
        {
            
        }
    }
}