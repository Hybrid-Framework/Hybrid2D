using System;

namespace Hybrid
{
    // Internal
    public abstract partial class Component : Behaviour
    {
        // Dispose
        internal override void OnDispose()
        {
            if (GameObject != null)
            {
                // Destroy Component
                if (GameObject.DestroyComponent(this))
                {
                    OnDestroy();
                    
                    GameObject = null;
                    Transform = null;
                }
            }
            
            base.OnDispose();
        }
    }
    
    // Component API
    public abstract partial class Component
    {
        public bool DidAwake { get; internal set; } = false;
        public bool DidStart { get; internal set; } = false;
        

        public virtual void OnAwake() { }

        public virtual void OnStart() { }

        public virtual void OnEnable() { }

        public virtual void OnDisable() { }

        public virtual void OnUpdate() { }

        public virtual void OnPhysics() { }

        public virtual void OnDestroy() { }
    }
}