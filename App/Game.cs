using Hybrid;

namespace App
{
    public class Game : Scene
    {
        public override void OnSceneOpen()
        {
            GameObject parent = new GameObject("Parent");

            for (int i = 0; i < 50000; i++)
            {
                GameObject child = new GameObject($"Child ({i})");
                child.Transform.SetParent(parent.Transform);
            }
        }

        public override void OnSceneClose()
        {
            
        }
    }
}