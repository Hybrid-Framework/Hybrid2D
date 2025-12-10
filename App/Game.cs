using Hybrid;

namespace App
{
    public class Game : Scene
    {
        public override void OnSceneOpen()
        {
            for (int i = 0; i < 8192; i++)
            {
                GameObject gameObject = new GameObject($"{i}");
            }
        }

        public override void OnSceneClose()
        {
            
        }
    }
}