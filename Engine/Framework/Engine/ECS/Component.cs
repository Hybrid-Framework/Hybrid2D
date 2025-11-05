using System;

namespace Hybrid
{
    // Component
    public class Component : Behaviour
    {
        protected internal bool ComponentHasBeenInitialized { get; set; } = false;
        

        public virtual void OnStart()
        {
            
        }

        public virtual void OnUpdate()
        {
            
        }

        public virtual void OnEnable()
        {
            
        }

        public virtual void OnDisable()
        {
            
        }
        
        public virtual void OnDestroy()
        {
            
        }

        internal override void Dispose()
        {
            base.Dispose();
            
            if (GameObject != null)
            {
                OnDestroy();
                
                GameObject.RemoveComponent(this);
                GameObject = null;
                Transform = null;
            }
        }
    }
}