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
                if (GameObject.DestroyComponentInternal(this))
                {
                    OnComponentDestroy();
                    
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
        internal bool DidAwake { get; set; } = false;
        internal bool DidStart { get; set; } = false;
        

        internal virtual void OnComponentAwake()
        {
            if (this is Script script)
            {
                script.OnAwake();
            }
        }

        internal virtual void OnComponentStart()
        {
            if (this is Script script)
            {
                script.OnStart();
            }
        }

        internal virtual void OnComponentEnable()
        {
            if (this is Script script)
            {
                script.OnEnable();
            }
        }

        internal virtual void OnComponentDisable()
        {
            if (this is Script script)
            {
                script.OnDisable();
            }
        }

        internal virtual void OnComponentUpdate()
        {
            if (this is Script script)
            {
                script.OnUpdate();
            }
        }

        internal virtual void OnComponentFixedUpdate()
        {
            if (this is Script script)
            {
                script.OnFixedUpdate();
            }
        }

        internal virtual void OnComponentLateUpdate()
        {
            if (this is Script script)
            {
                script.OnLateUpdate();
            }
        }

        internal virtual void OnComponentDestroy()
        {
            if (this is Script script)
            {
                script.OnDestroy();
            }
        }
    }
}