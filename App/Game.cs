using Hybrid;

namespace App
{
    public class Game : Scene
    {
        public override void OnSceneOpen()
        {
            for (int i = 0; i < 16000; i++)
            {
                GameObject gameObject = new GameObject($"Child ({i})");
            }
        }

        public override void OnSceneClose()
        {
            
        }
    }
}