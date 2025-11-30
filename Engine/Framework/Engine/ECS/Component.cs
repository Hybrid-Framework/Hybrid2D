using System;

namespace Hybrid
{
    // Internal
    public abstract partial class Component : Behaviour
    {
        // Dispose
        internal override void OnDispose()
        {
            OnDestroy();

            if (GameObject != null)
            {
                // Remove From GameObject
                GameObject.RemoveComponent(this);
            }
            
            base.OnDispose();
        }
    }
    
    public abstract partial class Component
    {
        internal bool ComponentInitialized { get; set; } = false;
        
        public virtual void OnAwake() { }
        public virtual void OnStart() { }
        public virtual void OnEnable() { }
        public virtual void OnDisable() { }
        public virtual void OnUpdate() { }
        public virtual void OnDestroy() { }
    }
}