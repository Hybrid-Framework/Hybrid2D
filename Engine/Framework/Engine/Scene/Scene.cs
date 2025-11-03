using System;

namespace Hybrid
{
    public abstract class Scene
    {
        private readonly HashSet<Object> SceneObjects = new HashSet<Object>();
        
        public abstract void OnOpened();
        public abstract void OnClosed();

        internal void Add(Object obj)
        {
            SceneObjects.Add(obj);
        }

        internal void Remove(Object obj)
        {
            SceneObjects.Remove(obj);
        }

        public Object[] GetSceneObjects()
        {
            return SceneObjects.ToArray();
        }
        
        public override string ToString()
        {
            return GetType().Name;
        }
        
        protected Scene()
        {
            
        }
    }
}