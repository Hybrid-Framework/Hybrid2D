using Hybrid;

namespace App
{
    public class Game : Scene
    {
        public override void OnSceneOpen()
        {
            GameObject parent = new GameObject("Parent");

            for (int g = 0; g < 16; g++)
            {
                GameObject group = new GameObject($"Group({g})");
                group.Transform.SetParent(parent.Transform);
                
                for (int i = 0; i < 500; i++)
                {
                    GameObject child = new GameObject($"Group({g}) Child({i})");
                    child.Transform.SetParent(group.Transform);
                }
            }

            // foreach (var child in parent.Transform.GetChildrenRecursive(true))
            // {
            //     // Debug.Log(child.Name);
            // }
        }

        public override void OnSceneClose()
        {
            
        }
    }
}