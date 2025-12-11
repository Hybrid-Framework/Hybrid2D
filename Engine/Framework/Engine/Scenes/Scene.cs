using System;

namespace Hybrid
{
    // Scene API
    public abstract class Scene
    {
        internal HashSet<GameObject> RootGameObjects { get; private set; } = new HashSet<GameObject>();
        public string Name => GetType().Name;
        
        
        internal void AddObject(GameObject gameObject)
        {
            // Debug.Log($"Added '{gameObject.Name}' to scene root objects");
            RootGameObjects.Add(gameObject);
        }

        internal void RemoveObject(GameObject gameObject)
        {
            // Debug.Log($"Removed '{gameObject.Name}' from scene root objects");
            RootGameObjects.Remove(gameObject);
        }
        
        public List<GameObject> GetRootGameObjects()
        {
            return RootGameObjects.ToList();
        }
        
        public virtual void OnSceneOpen()
        {
            // Called when scene finished opening
        }

        public virtual void OnSceneClose()
        {
            // Called when scene finished closing
        }
    }
}