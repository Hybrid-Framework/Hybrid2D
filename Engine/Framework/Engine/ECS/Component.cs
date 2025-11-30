using System;

namespace Hybrid
{
    // Component
    public abstract class Component : Behaviour
    {
        internal bool ComponentInitialized { get; set; } = false;
        
        internal override void OnDispose()
        {
            OnDestroy();
            
            base.OnDispose();

            if (GameObject != null)
            {
                // Remove From GameObject
                GameObject.RemoveComponent(this);
            }

            // Remove
            GameObject = null;
            Transform = null;
        }
        
        public virtual void OnAwake() { }
        public virtual void OnStart() { }
        public virtual void OnEnable() { }
        public virtual void OnDisable() { }
        public virtual void OnUpdate() { }
        public virtual void OnDestroy() { }
    }
}