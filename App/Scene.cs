using Hybrid;

namespace App
{
    public class Scene : Hybrid.Scene
    {
        public override void OnOpened()
        {
            GameObject obj1 = new GameObject("Hello");

            foreach (var obj in Object.FindObjectsOfType<Object>())
            {
                System.Console.WriteLine(obj.Name);
            }
        }

        public override void OnClosed()
        {
            
        }
    }
}