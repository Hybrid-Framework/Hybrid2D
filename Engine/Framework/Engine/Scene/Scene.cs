using System;

namespace Hybrid
{
    public class Scene
    {
        public string Name
        {
            get => GetType().Name;
        }
        
        public virtual void OnOpened()
        {
            
        }

        public virtual void OnClosed()
        {
            
        }

        public virtual void Update()
        {
            
        }

        public virtual void Draw()
        {
            
        }

        protected Scene()
        {
            
        }
    }
}