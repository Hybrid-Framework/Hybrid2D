using System;

namespace Hybrid
{
    // Scene
    public abstract class Scene
    {
        private readonly List<Object> Objects = new List<Object>();
        
        public string Name => GetType().Name;
        

        public virtual void OnSceneClose()
        {
            // Called When Scene Closed
        }

        public virtual void OnSceneOpen()
        {
            // Called When Scene Opened
        }
        
        public Object[] GetSceneObjects()
        {
            return Objects.ToArray();
        }

        internal void Add(Object obj)
        {
            Objects.Add(obj);
        }
        
        internal void Remove(Object obj)
        {
            Objects.Remove(obj);
        }
    }
}