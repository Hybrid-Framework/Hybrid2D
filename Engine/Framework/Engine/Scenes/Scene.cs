using System;

namespace Hybrid
{
    // Scene
    public class Scene
    {
        private readonly List<GameObject> GameObjects = new List<GameObject>();
        
        public string Name => GetType().Name;
        

        public virtual void OnSceneClose()
        {
            // Called When Scene Closed
        }

        public virtual void OnSceneOpen()
        {
            // Called When Scene Opened
        }
        
        public GameObject[] GetSceneGameObjects()
        {
            return GameObjects.ToArray();
        }

        internal void Add(GameObject gameObject)
        {
            Console.WriteLine($"GameObject '{gameObject.Name}' added to scene");
            GameObjects.Add(gameObject);
        }
        
        internal void Remove(GameObject gameObject)
        {
            Console.WriteLine($"GameObject '{gameObject.Name}' removed from scene");
            GameObjects.Remove(gameObject);
        }

        protected Scene()
        {
            
        }
    }
}