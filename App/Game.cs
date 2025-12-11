using Hybrid;

namespace App
{
    public class Game : Scene
    {
        public override void OnSceneOpen()
        {
            GameObject parent = new GameObject("Parent");
            var t1 = parent.AddComponent<TestComponent>();
            var t2 = parent.AddComponent<TestComponent>();

            for (int g = 0; g < 32; g++)
            {
                GameObject group = new GameObject($"Group({g})");
                group.Transform.SetParent(parent.Transform);
                
                for (int i = 0; i < 250; i++)
                {
                    GameObject child = new GameObject($"Group({g}) Child({i})");
                    child.Transform.SetParent(group.Transform);
                }
            }
        }

        public override void OnSceneClose()
        {
            
        }
    }
}