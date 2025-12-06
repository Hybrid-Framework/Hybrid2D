using System;

namespace Hybrid
{
    // Internal
    public abstract partial class Scene
    {
        private readonly List<GameObject> SceneGameObjects = new List<GameObject>();
        

        internal void Add(GameObject gameObject)
        {
            Console.WriteLine($"Added {gameObject.Name} to scene");
            SceneGameObjects.Add(gameObject);
        }

        internal void Remove(GameObject gameObject)
        {
            Console.WriteLine($"Removed {gameObject.Name} from scene");
            SceneGameObjects.Remove(gameObject);
        }
    }

    // Scene API
    public abstract partial class Scene
    {
        public string Name
        {
            get => GetType().Name;
        }
        
        
        public GameObject[] GetSceneGameObjects()
        {
            return SceneGameObjects.ToArray();
        }
        
        public virtual void OnSceneOpen()
        {
            
        }

        public virtual void OnSceneClose()
        {
            
        }
    }
}